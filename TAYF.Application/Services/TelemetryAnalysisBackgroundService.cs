using Microsoft.EntityFrameworkCore;
using TAYF.Domain.Entities;
using TAYF.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TAYF.Application.Interfaces;

namespace TAYF.Application.Services
{
    /// <summary>
    /// Background service that processes new telemetry, computes expected power, detects anomalies,
    /// calculates financial loss, and persists AnalysisResult and Alert records.
    /// </summary>
    public class TelemetryAnalysisBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<TelemetryAnalysisBackgroundService> _logger;
        private readonly IMemoryCache _cache;

        // Cache keys
        private const string InverterMetadataKey = "InverterMetadata";
        private const string PlantTariffRateKey = "PlantTariffRate-{0}";
        private const string PlantCurrencyKey = "PlantCurrency-{0}";
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(10);

        public TelemetryAnalysisBackgroundService(
            IServiceProvider serviceProvider,
            ILogger<TelemetryAnalysisBackgroundService> logger,
            IMemoryCache cache)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Telemetry Analysis Background Service starting.");

            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(30)); // adjust interval as needed

            try
            {
                while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await ProcessNewTelemetryAsync(stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Graceful shutdown
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Telemetry Analysis Background Service encountered fatal error");
            }

            _logger.LogInformation("Telemetry Analysis Background Service stopping.");
        }

        private async Task ProcessNewTelemetryAsync(CancellationToken stoppingToken)
        {
            // Create a scope to resolve scoped services
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
            var expectedPowerService = scope.ServiceProvider.GetRequiredService<IExpectedPowerService>();
            var anomalyDetectionService = scope.ServiceProvider.GetRequiredService<IAnomalyDetectionService>();
            var rootCauseService = scope.ServiceProvider.GetRequiredService<IRootCauseService>();

            // Get all inverters with plant info (include plant for tariff/currency)
            var inverters = await context.Inverters
                .AsNoTracking()
                .Include(i => i.Plant)
                .ThenInclude(p => p.Tariffs) // we'll use Plant's TariffRate and Currency directly
                .ToListAsync(stoppingToken);

            if (!inverters.Any())
            {
                _logger.LogDebug("No inverters found.");
                return;
            }

            // Load inverter metadata into cache (MaxPowerKw, PlantId, Plant TariffRate, Currency)
            var inverterMetadata = await GetInverterMetadataAsync(inverters.Select(i => i.Id).ToList(), stoppingToken, scope.ServiceProvider);
            var plantTariffCache = await GetPlantTariffAndCurrencyAsync(inverters.Select(i => i.Plant.Id).Distinct().ToList(), stoppingToken, scope.ServiceProvider);

            // Get latest checkpoint per inverter
            var checkpoints = await context.TelemetryProcessingCheckpoints
                .AsNoTracking()
                .ToDictionaryAsync(c => c.InverterId, c => c.LastProcessedUtc, stoppingToken);

            foreach (var inverter in inverters)
            {
                var inverterId = inverter.Id;
                var lastProcessed = checkpoints.TryGetValue(inverterId, out var dt) ? dt : DateTime.MinValue;

                // Fetch new telemetry for this inverter since last processed
                var telemetryList = await context.TelemetryRecords
                    .AsNoTracking()
                    .Where(t => t.InverterId == inverterId && t.Timestamp > lastProcessed)
                    .OrderBy(t => t.Timestamp)
                    .ToListAsync(stoppingToken);

                if (!telemetryList.Any())
                    continue;

                _logger.LogInformation("Processing {Count} new telemetry records for Inverter {Id} (since {Last})",
                    telemetryList.Count, inverterId, lastProcessed);

                try
                {
                    var analysisResults = new List<AnalysisResult>();
                    var alerts = new List<Alert>();
                    DateTime maxTsInBatch = telemetryList.Min(t => t.Timestamp); // will update to max

                    // For energy loss calculation we need previous telemetry's timestamp to compute time delta.
                    // We'll fetch the previous telemetry (the one at or before lastProcessed) for each inverter.
                    // Simpler: assume regular interval; we can compute delta as difference between consecutive timestamps.
                    // We'll compute delta per record using previous timestamp in the list; for the first record we need the previous outside the list.
                    // We'll fetch the latest telemetry before lastProcessed (if any) to seed.
                    Telemetry? previousTelemetry = null;
                    if (lastProcessed > DateTime.MinValue)
                    {
                        previousTelemetry = await context.TelemetryRecords
                            .AsNoTracking()
                            .Where(t => t.InverterId == inverterId && t.Timestamp <= lastProcessed)
                            .OrderByDescending(t => t.Timestamp)
                            .FirstOrDefaultAsync(stoppingToken);
                    }

                    foreach (var telemetry in telemetryList)
                    {
                        // Determine time delta in hours since previous telemetry
                        double hoursSincePrevious = GetHoursSincePrevious(previousTelemetry, telemetry);
                        previousTelemetry = telemetry; // update for next iteration

                        // Get inverter metadata from cache
                        if (!inverterMetadata.TryGetValue(inverterId, out var meta))
                        {
                            _logger.LogWarning("Metadata missing for Inverter {Id}", inverterId);
                            continue;
                        }

                        // Expected power via PVWatts
                        var expectedPowerKw = await expectedPowerService.CalculateExpectedPower(
                            new Inverter { MaxPowerKw = meta.MaxPowerKw }, // we only need MaxPowerKw
                            telemetry.Irradiance,
                            (double)telemetry.ModuleTemperature);

                        // Deviation and anomaly detection
                        var deviationPct = anomalyDetectionService.CalculateDeviationPct(
                            (double)telemetry.AcPowerKw, (double)expectedPowerKw);
                        var isAnomaly = deviationPct <= -10.0;

                        // Energy loss kWh (positive when expected > actual)
                        double energyLossKwh = 0;
                        if ((double)telemetry.AcPowerKw < expectedPowerKw)
                        {
                            energyLossKwh = (expectedPowerKw - (double)telemetry.AcPowerKw) * hoursSincePrevious;
                        }

                        // Financial loss: energy loss * tariff rate
                        var plantId = meta.PlantId;
                        decimal tariffRate = 0m;
                        Currency plantCurrency = Currency.EGP;
                        if (plantTariffCache.TryGetValue(plantId, out var tariffInfo))
                        {
                            tariffRate = tariffInfo.Rate;
                            plantCurrency = tariffInfo.Currency;
                        }
                        var financialLoss = energyLossKwh * (double)tariffRate;

                        // Severity based on deviation
                        var severity = GetSeverityFromDeviation(deviationPct);

                        // Anomaly score and confidence (simple formulas)
                        var anomalyScore = isAnomaly ? CalculateAnomalyScore(deviationPct) : 0m;
                        var confidenceScore = isAnomaly ? CalculateConfidenceScore(deviationPct) : 0m;

                        // Primary cause and probabilities (if anomaly)
                        string? primaryCause = null;
                        string? causeProbabilitiesJson = null;
                        if (isAnomaly)
                        {
                            var diagnosis = await rootCauseService.GetRootCauseDiagnosisAsync(
                                inverter.PlantId, inverter.Id, telemetry.Timestamp);
                            primaryCause = diagnosis.PrimaryCause;
                            causeProbabilitiesJson = System.Text.Json.JsonSerializer.Serialize(diagnosis.CauseProbabilities);
                        }

                        // AnalysisResult
                        var analysis = new AnalysisResult
                        {
                            PlantId = inverter.PlantId,
                            InverterId = inverter.Id,
                            Timestamp = telemetry.Timestamp,
                            ActualPowerKw = telemetry.AcPowerKw,
                            ExpectedPowerKw = (decimal)expectedPowerKw,
                            DeviationPct = (decimal)deviationPct,
                            IsAnomaly = isAnomaly,
                            Severity = severity,
                            AnomalyScore = anomalyScore,
                            ConfidenceScore = confidenceScore,
                            EnergyLossKwh = (decimal)energyLossKwh,
                            ExpectedEnergyKwh = (decimal)(expectedPowerKw * hoursSincePrevious),
                            ActualEnergyKwh = (decimal)((double)telemetry.AcPowerKw * hoursSincePrevious),
                            EstimatedLoss = (decimal)financialLoss,
                            Currency = plantCurrency,
                            PrimaryCause = primaryCause ?? "None",
                            CauseProbabilities = causeProbabilitiesJson ?? "[]",
                            CreatedAt = DateTime.UtcNow
                        };
                        analysisResults.Add(analysis);

                        // Alert if anomaly
                        if (isAnomaly)
                        {
                            var rootCause = primaryCause ?? "Unknown";
                            var alert = new Alert
                            {
                                PlantId = inverter.PlantId,
                                InverterId = inverter.Id,
                                Severity = severity,
                                Problem = "Power deviation anomaly",
                                RootCause = rootCause,
                                FinancialLoss = (decimal)financialLoss,
                                EnergyLossKwh = (decimal)energyLossKwh,
                                Currency = plantCurrency,
                                RecommendedAction = GenerateRecommendation(primaryCause),
                                CreatedAt = DateTime.UtcNow,
                                IsResolved = false
                            };
                            alerts.Add(alert);
                        }

                        // Update max timestamp for checkpoint
                        if (telemetry.Timestamp > maxTsInBatch)
                            maxTsInBatch = telemetry.Timestamp;
                    }

                    // Persist analysis results
                    if (analysisResults.Any())
                    {
                        await context.AnalysisResults.AddRangeAsync(analysisResults, stoppingToken);
                    }

                    // Persist alerts
                    if (alerts.Any())
                    {
                        await context.Alerts.AddRangeAsync(alerts, stoppingToken);
                    }

                    await context.SaveChangesAsync(stoppingToken);

                    // Update checkpoint for this inverter
                    var checkpoint = await context.TelemetryProcessingCheckpoints
                        .FirstOrDefaultAsync(c => c.InverterId == inverter.Id, stoppingToken);
                    if (checkpoint == null)
                    {
                        checkpoint = new TelemetryProcessingCheckpoint
                        {
                            InverterId = inverter.Id,
                            LastProcessedUtc = maxTsInBatch,
                            UpdatedAt = DateTime.UtcNow
                        };
                        await context.TelemetryProcessingCheckpoints.AddAsync(checkpoint, stoppingToken);
                    }
                    else
                    {
                        checkpoint.LastProcessedUtc = maxTsInBatch;
                        checkpoint.UpdatedAt = DateTime.UtcNow;
                        context.TelemetryProcessingCheckpoints.Update(checkpoint);
                    }
                    await context.SaveChangesAsync(stoppingToken);

                    
                    _logger.LogInformation(
                        "Finished processing Inverter {Id}: {AnalysisCount} analysis results, {AlertCount} alerts.",
                        inverter.Id, analysisResults.Count, alerts.Count);
                }
                catch (Exception ex)
                {
                                        _logger.LogError(ex, "Error processing telemetry for Inverter {Id}", inverter.Id);
                }
            }
        }

        private async Task<Dictionary<int, (decimal MaxPowerKw, int PlantId)>> GetInverterMetadataAsync(
            List<int> inverterIds, CancellationToken cancellationToken, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<IApplicationDbContext>();
            // Try to get from cache
            if (_cache.TryGetValue(InverterMetadataKey, out Dictionary<int, (decimal MaxPowerKw, int PlantId)>? cached))
            {
                // Filter to requested ids
                return cached!.Where(kvp => inverterIds.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }

            // Fetch from DB
            var metadata = await context.Inverters
                .AsNoTracking()
                .Where(i => inverterIds.Contains(i.Id))
                .Select(i => new { i.Id, i.MaxPowerKw, i.PlantId })
                .ToDictionaryAsync(i => i.Id, i => (i.MaxPowerKw, i.PlantId), cancellationToken);

            // Cache
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(_cacheDuration)
                .SetPriority(CacheItemPriority.Normal);
            _cache.Set(InverterMetadataKey, metadata, cacheEntryOptions);

            return metadata;
        }

        private async Task<Dictionary<int, decimal>> GetPlantTariffRateAsync(List<int> plantIds, CancellationToken cancellationToken, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<IApplicationDbContext>();
            // We'll combine tariff rate and currency in one call to avoid multiple queries.
            var plantInfo = await GetPlantTariffAndCurrencyAsync(plantIds, cancellationToken, serviceProvider);
            return plantInfo.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Item1);
        }

        private async Task<Dictionary<int, (decimal Rate, Currency Currency)>> GetPlantTariffAndCurrencyAsync(
            List<int> plantIds, CancellationToken cancellationToken, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<IApplicationDbContext>();
            // Use a composite cache key? Simpler: cache each individually; we'll just fetch from DB each time for simplicity.
            // Given the small number of plants, we can query directly.
            var dict = await context.Plants
                .AsNoTracking()
                .Where(p => plantIds.Contains(p.Id))
                .Select(p => new { p.Id, p.TariffRate, p.Currency })
                .ToDictionaryAsync(p => p.Id, p => (p.TariffRate, p.Currency), cancellationToken);
            return dict;
        }

        private double GetHoursSincePrevious(Telemetry? previous, Telemetry current)
        {
            if (previous == null)
            {
                // No previous telemetry; assume a default interval (e.g., 1 hour) or compute based on typical frequency.
                // We'll fallback to 1 hour.
                return 1.0;
            }
            var delta = current.Timestamp - previous.Timestamp;
            return delta.TotalHours;
        }

        private Severity GetSeverityFromDeviation(double deviationPct)
        {
            if (deviationPct <= -20.0)
                return Severity.High;
            if (deviationPct <= -10.0)
                return Severity.Medium;
            return Severity.Low;
        }

        private decimal CalculateAnomalyScore(double deviationPct)
        {
            // Simple linear mapping: deviation -10% -> 0.3, -20% -> 0.6, etc. Cap at 1.0.
            var score = Math.Max(0, Math.Min(1.0, (-deviationPct - 10.0) / 10.0 * 0.5 + 0.3));
            return (decimal)score;
        }

        private decimal CalculateConfidenceScore(double deviationPct)
        {
            // Confidence increases with deviation magnitude beyond threshold.
            var confidence = Math.Min(0.9, (-deviationPct - 10.0) / 20.0 * 0.6);
            return (decimal)Math.Max(0, confidence);
        }

        private string GenerateRecommendation(string? primaryCause)
        {
            return primaryCause?.ToLowerInvariant() switch
            {
                "soiling" => "Clean the panels to remove soiling.",
                "temperature" => "Check ventilation and cooling; high temperature may be reducing efficiency.",
                "electricalfault" => "Inspect electrical connections and components for faults.",
                _ => "Investigate the cause of power deviation."
            };
        }
    }
}