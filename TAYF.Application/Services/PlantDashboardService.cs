using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs.Dashboard;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;
using TAYF.Domain.Enums;

namespace TAYF.Application.Services
{
    public class PlantDashboardService : IPlantDashboardService
    {
        private readonly IApplicationDbContext _context;

        public PlantDashboardService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PlantSummaryDto> GetSummaryAsync(int plantId, CancellationToken ct = default)
        {
            var plant = await _context.Plants
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == plantId, ct);

            if (plant == null)
            {
                return new PlantSummaryDto
                {
                    PlantId = plantId,
                    LastUpdated = DateTime.UtcNow
                };
            }

            // Get latest telemetry for current power
            var latestTelemetry = await _context.TelemetryRecords
                .AsNoTracking()
                .Where(t => t.PlantId == plantId)
                .OrderByDescending(t => t.Timestamp)
                .FirstOrDefaultAsync(ct);

            // Today's aggregates (from today 00:00 UTC to now)
            var todayStart = DateTime.UtcNow.Date;
            var todayTelemetry = await _context.TelemetryRecords
                .AsNoTracking()
                .Where(t => t.PlantId == plantId && t.Timestamp >= todayStart)
                .ToListAsync(ct);

            decimal todayEnergyKwh = todayTelemetry.Sum(t => (decimal?)t.AcPowerKw) ?? 0;
            // For simplicity, we assume expected energy is not stored; we can compute from BaselineExpectedPowerService but that's complex.
            // Since we don't have expected energy in the telemetry, we'll set to 0 and deviation to 0.
            // In a real scenario, we would compute expected energy for today.
            decimal todayExpectedKwh = 0;
            decimal todayDeviationPct = todayExpectedKwh != 0 ? ((todayEnergyKwh - todayExpectedKwh) / todayExpectedKwh) * 100 : 0;

            // Active alerts count (unresolved)
            var activeAlerts = await _context.Alerts
                .AsNoTracking()
                .CountAsync(a => a.PlantId == plantId && !a.IsResolved, ct);

            // Critical alerts count (unresolved and severity High)
            var criticalAlerts = await _context.Alerts
                .AsNoTracking()
                .CountAsync(a => a.PlantId == plantId && !a.IsResolved && a.Severity == Severity.High, ct);

            // PvSharePct: we don't have this data, set to 0
            decimal pvSharePct = 0;

            return new PlantSummaryDto
            {
                PlantId = plant.Id,
                PlantName = plant.Name ?? string.Empty,
                Currency = plant.Currency.ToString(),
                CurrentPowerKw = latestTelemetry?.AcPowerKw ?? 0,
                TodayEnergyKwh = todayEnergyKwh,
                TodayExpectedKwh = todayExpectedKwh,
                TodayDeviationPct = todayDeviationPct,
                PvSharePct = pvSharePct,
                ActiveAlerts = activeAlerts,
                CriticalAlerts = criticalAlerts,
                LastUpdated = DateTime.UtcNow
            };
        }

        public async Task<IReadOnlyList<TelemetryPointDto>> GetLatestTelemetryAsync(int plantId, int count, CancellationToken ct = default)
        {
            var telemetry = await _context.TelemetryRecords
                .AsNoTracking()
                .Where(t => t.PlantId == plantId)
                .OrderByDescending(t => t.Timestamp)
                .Take(count)
                .Select(t => new TelemetryPointDto
                {
                    Timestamp = t.Timestamp,
                    AcPowerKw = t.AcPowerKw,
                    Irradiance = t.Irradiance,
                    ModuleTemp = t.ModuleTemperature
                })
                .ToListAsync(ct);

            return telemetry;
        }

        public async Task<PerformanceTrendDto> GetPerformanceTrendAsync(int plantId, int days, CancellationToken ct = default)
        {
            // Get the latest telemetry timestamp for this plant
            var latestTimestamp = await _context.TelemetryRecords
                .Where(t => t.PlantId == plantId)
                .MaxAsync(t => (DateTime?)t.Timestamp, ct);

            if (latestTimestamp == null)
            {
                return new PerformanceTrendDto { PlantId = plantId };
            }

            var toDate = latestTimestamp.Value.Date.AddDays(1); // exclusive upper bound
            var fromDate = toDate.AddDays(-days); // inclusive lower bound

            // First load the raw records (with Inverter.MaxPowerKw join)
            var raw = await _context.TelemetryRecords
                .AsNoTracking()
                .Where(t => t.PlantId == plantId
                         && t.Timestamp >= fromDate
                         && t.Timestamp < toDate
                         && t.Irradiance > 50)
                .Join(_context.Inverters,
                      t => t.InverterId,
                      i => i.Id,
                      (t, i) => new { t, i.MaxPowerKw })
                .ToListAsync(ct);

            var aggregates = raw
                .GroupBy(x => x.t.Timestamp.Date)
                .Select(g =>
                {
                    var actualKwh = g.Sum(x => (decimal)x.t.AcPowerKw);
                    var expectedKwh = g.Sum(x =>
                        (decimal)(x.t.Irradiance / 1000.0) * x.MaxPowerKw
                        * (1m - 0.004m * (x.t.ModuleTemperature - 25m)));
                    var deviationPct = expectedKwh != 0
                        ? ((actualKwh - expectedKwh) / expectedKwh) * 100m
                        : 0m;
                    return new PerformanceTrendDayDto
                    {
                        Date = g.Key,
                        ActualKwh = Math.Round(actualKwh, 2),
                        ExpectedKwh = Math.Round(expectedKwh, 2),
                        DeviationPct = Math.Round(deviationPct, 2)
                    };
                })
                .OrderBy(d => d.Date)
                .ToList();

            return new PerformanceTrendDto
            {
                PlantId = plantId,
                Days = aggregates
            };
        }

        public async Task<SoilingStatusDto> GetSoilingStatusAsync(int plantId, CancellationToken ct = default)
        {
            // Get the latest soiling analysis result for the plant
            var latestSoiling = await _context.AnalysisResults
                .AsNoTracking()
                .Where(a => a.PlantId == plantId && a.PrimaryCause.ToLower().Contains("soiling"))
                .OrderByDescending(a => a.Timestamp)
                .FirstOrDefaultAsync(ct);

            if (latestSoiling == null)
            {
                return new SoilingStatusDto
                {
                    PlantId = plantId,
                    Recommendation = "No soiling data available"
                };
            }

            // Calculate days since last cleaning (we don't have cleaning date, so we'll set to null and estimate)
            // For simplicity, we'll assume the last cleaning date is not stored, so we'll set DaysSinceLastCleaning to 0.
            // In a real scenario, we would have a cleaning event log.

            return new SoilingStatusDto
            {
                PlantId = plantId,
                CurrentSoilingLossPct = (decimal)latestSoiling.DeviationPct, // Assuming deviation percent is the soiling loss
                DaysSinceLastCleaning = 0, // Placeholder
                EstimatedRecoveryKwh = (decimal)latestSoiling.EnergyLossKwh, // Placeholder
                LastCleaningDate = null,
                Recommendation = "Clean the panels to recover soiling losses."
            };
        }
    }
}