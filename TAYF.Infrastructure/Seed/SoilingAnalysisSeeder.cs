using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TAYF.Domain.Entities;
using TAYF.Domain.Enums;
using TAYF.Infrastructure.Data;

namespace TAYF.Infrastructure.Seed
{
    /// <summary>
    /// Seeds the database with soiling analysis results based on meteorological data.
    /// </summary>
    public class SoilingAnalysisSeeder
    {
        private readonly TayfDbContext _context;
        private readonly ILogger<SoilingAnalysisSeeder> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoilingAnalysisSeeder"/> class.
        /// </summary>
        public SoilingAnalysisSeeder(
            TayfDbContext context,
            ILogger<SoilingAnalysisSeeder> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Seeds the database with soiling analysis results.
        /// </summary>
        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("SoilingAnalysisSeeder: Starting to seed soiling analysis results");

            // Get plant information for tariff rate and currency
            var plant = await _context.Plants
                .FirstOrDefaultAsync(p => p.Id == 1, cancellationToken);

            if (plant == null)
            {
                _logger.LogError("SoilingAnalysisSeeder: Plant with Id=1 not found");
                return;
            }

            // Remove existing soiling analysis results for this plant
            var existingSoiling = await _context.AnalysisResults
                .Where(a => a.PlantId == 1 && a.PrimaryCause == "Soiling")
                .ToListAsync(cancellationToken);

            if (existingSoiling.Any())
            {
                _context.AnalysisResults.RemoveRange(existingSoiling);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("SoilingAnalysisSeeder: Removed {Count} existing soiling analysis records", existingSoiling.Count);
            }

            // Read meteorological data
            var meteorologicalRecords = await ReadMeteorologicalCsvAsync(cancellationToken);
            _logger.LogInformation("SoilingAnalysisSeeder: Read {Count} meteorological records", meteorologicalRecords.Count);

            // Group meteorological data by day
            var meteoByDay = meteorologicalRecords
                .GroupBy(m => m.ReadingTime.Date)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Get telemetry data for energy calculations
            var telemetryRecords = await _context.TelemetryRecords
                .Where(t => t.PlantId == 1)
                .ToListAsync(cancellationToken);

            _logger.LogInformation("SoilingAnalysisSeeder: Loaded {Count} telemetry records for PlantId=1", telemetryRecords.Count);

            // Group telemetry by day
            var telemetryByDay = telemetryRecords
                .GroupBy(t => t.Timestamp.Date)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Kimber model parameters (simplified for demo: no rain reset)
            const double dailySoilingRate = 0.004;     // 0.4% per day
            const double maxSoilingLoss = 0.15;        // 15% maximum

            // Process each day
            var analysisResults = new List<AnalysisResult>();
            int processedDays = 0;

            // ✅ IMPORTANT: soilingLoss is declared OUTSIDE the loop so it ACCUMULATES
            double soilingLoss = 0.0;

            foreach (var dayEntry in meteoByDay.OrderBy(kvp => kvp.Key))
            {
                var date = dayEntry.Key;
                var dayMeteoRecords = dayEntry.Value;

                // Calculate average daily irradiance (GHI) in W/m²
                double avgGhiWm2 = dayMeteoRecords.Average(m => m.GhiWm2);

                // Calculate total daily precipitation in mm
                double dailyPrecipitationMm = dayMeteoRecords.Sum(m => m.PrecipitationMm);

                // Get telemetry for this day
                if (!telemetryByDay.TryGetValue(date, out var dayTelemetryRecords))
                {
                    _logger.LogWarning("SoilingAnalysisSeeder: No telemetry data found for date {Date}, skipping", date);
                    continue;
                }

                // Calculate daily energy production in kWh
                double dailyEnergyKwh = dayTelemetryRecords.Sum(t => (double)t.AcPowerKw);

                // Apply Kimber soiling model — accumulate daily (no rain reset for demo simplicity)
                soilingLoss += dailySoilingRate;
                if (soilingLoss > maxSoilingLoss)
                {
                    soilingLoss = maxSoilingLoss;
                }

                // Calculate energy loss
                double energyLossKwh = dailyEnergyKwh * soilingLoss;

                // Calculate expected energy production without soiling
                double expectedEnergyKwh = dailyEnergyKwh / (1 - soilingLoss);

                // Determine severity based on loss percentage
                Severity severity;
                if (soilingLoss < 0.05) // Less than 5%
                {
                    severity = Severity.Low;
                }
                else if (soilingLoss < 0.15) // 5% to 15%
                {
                    severity = Severity.Medium;
                }
                else if (soilingLoss < 0.30) // 15% to 30%
                {
                    severity = Severity.High;
                }
                else
                {
                    severity = Severity.Critical;
                }

                // For soiling analysis that affects the whole plant, we'll assign it to the first inverter
                int inverterIdForSoiling = 1;

                var analysisResult = new AnalysisResult
                {
                    PlantId = 1,
                    InverterId = inverterIdForSoiling,
                    Timestamp = date.Date.AddDays(1).AddTicks(-1), // End of day
                    ActualPowerKw = (decimal)dailyEnergyKwh,
                    ExpectedPowerKw = (decimal)(dailyEnergyKwh / (1 - soilingLoss)),
                    DeviationPct = (decimal)(-soilingLoss * 100),
                    IsAnomaly = soilingLoss > 0.05,
                    Severity = severity,
                    AnomalyScore = (decimal)soilingLoss,
                    PrimaryCause = "Soiling",
                    CauseProbabilities = "{\"Soiling\":1.0}",
                    ConfidenceScore = 0.8m,
                    EnergyLossKwh = (decimal)energyLossKwh,
                    ExpectedEnergyKwh = (decimal)expectedEnergyKwh,
                    ActualEnergyKwh = (decimal)dailyEnergyKwh,
                    EstimatedLoss = (decimal)energyLossKwh,
                    Currency = plant.Currency,
                    CreatedAt = DateTime.UtcNow
                };

                analysisResults.Add(analysisResult);
                processedDays++;
            }

            // Bulk insert analysis results
            if (analysisResults.Any())
            {
                await _context.AnalysisResults.AddRangeAsync(analysisResults, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("SoilingAnalysisSeeder: Inserted {Count} soiling analysis records", analysisResults.Count);
            }
            else
            {
                _logger.LogWarning("SoilingAnalysisSeeder: No analysis records to insert");
            }

            _logger.LogInformation("SoilingAnalysisSeeder: Seeding completed. Processed {Count} days", processedDays);
        }

        private async Task<List<MeteorologicalScadaRecord>> ReadMeteorologicalCsvAsync(CancellationToken cancellationToken)
        {
            var filePath = GetFilePath("Meteorological data.csv");

            if (!File.Exists(filePath))
            {
                _logger.LogWarning("Meteorological CSV file not found at {FilePath}", filePath);
                return new List<MeteorologicalScadaRecord>();
            }

            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null,
                BadDataFound = null,
                IgnoreBlankLines = true,
            };
            using var csv = new CsvReader(reader, config);

            var records = new List<MeteorologicalScadaRecord>();
            await foreach (var record in csv.GetRecordsAsync<MeteorologicalScadaRecord>(cancellationToken))
            {
                records.Add(record);
            }

            _logger.LogInformation("SoilingAnalysisSeeder: Read {Count} meteorological records from CSV", records.Count);
            return records;
        }

        private string GetFilePath(string fileName)
        {
            // We don't have IHostEnvironment here, so we'll use a relative path from the content root
            var contentRoot = AppDomain.CurrentDomain.BaseDirectory;

            // Navigate up to find the project root
            while (!Directory.Exists(Path.Combine(contentRoot, "TAYF.Infrastructure", "Seed", "pv_scada")) &&
                   contentRoot != Path.GetPathRoot(contentRoot))
            {
                contentRoot = Directory.GetParent(contentRoot)!.FullName;
            }

            return Path.Combine(contentRoot, "TAYF.Infrastructure", "Seed", "pv_scada", fileName);
        }

        // CSV record format for meteorological data (same as in ScadaCsvSeeder)
        private class MeteorologicalScadaRecord
        {
            [Name("station_id")] public string StationId { get; set; } = null!;
            [Name("reading_time")] public DateTime ReadingTime { get; set; }
            [Name("ghi_wm2")] public double GhiWm2 { get; set; }
            [Name("dni_wm2")] public double DniWm2 { get; set; }
            [Name("dhi_wm2")] public double DhiWm2 { get; set; }
            [Name("ambient_temp")] public double AmbientTemp { get; set; }
            [Name("temp_unit")] public string TempUnit { get; set; } = null!;
            [Name("wind_speed_ms")] public double WindSpeedMs { get; set; }
            [Name("relative_humidity_pct")] public double RelativeHumidityPct { get; set; }
            [Name("barometric_pressure_hpa")] public double BarometricPressureHpa { get; set; }
            [Name("solar_zenith_angle_deg")] public double SolarZenithAngleDeg { get; set; }
            [Name("cloud_opacity_pct")] public double CloudOpacityPct { get; set; }
            [Name("precipitation_mm")] public double PrecipitationMm { get; set; }
        }
    }
}