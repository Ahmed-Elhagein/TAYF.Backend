using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services
{
    /// <summary>
    /// Service for calculating expected vs actual performance.
    /// </summary>
    public class PerformanceService : IPerformanceService
    {
        private readonly IApplicationDbContext _context;
        private readonly IExpectedPowerService _expectedPowerService;
        private readonly IAnomalyDetectionService _anomalyDetectionService;

        public PerformanceService(IApplicationDbContext context,
                                  IExpectedPowerService expectedPowerService,
                                  IAnomalyDetectionService anomalyDetectionService)
        {
            _context = context;
            _expectedPowerService = expectedPowerService;
            _anomalyDetectionService = anomalyDetectionService;
        }

        public async Task<ExpectedVsActualDto> GetExpectedVsActualAsync(int plantId, int? inverterId, DateTime from, DateTime to)
        {
            // Ensure from is before to
            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            // Query: join Telemetry + Inverter by InverterId, filter by PlantId + date range
            var query = _context.TelemetryRecords.AsNoTracking()
                .Join(_context.Inverters.AsNoTracking(),
                      t => t.InverterId,
                      i => i.Id,
                      (t, i) => new { t, i })
                .Where(x => x.i.PlantId == plantId)
                .Where(x => x.t.Timestamp >= from)
                .Where(x => x.t.Timestamp < to)    // Changed to exclusive upper bound
                .Where(x => x.t.Irradiance > 50)   // meaningful sunlight threshold
                // Removed AcPowerKw > 0 filter since we're comparing DC power now
                // We want to compare Expected DC vs Actual DC even when AC is zero
                // (but DC might not be zero, e.g., during low-light conditions)
                ;

            if (inverterId.HasValue)
            {
                query = query.Where(x => x.t.InverterId == inverterId.Value);
            }

            var records = await query.OrderBy(x => x.t.Timestamp).ToListAsync();

            if (!records.Any())
            {
                return new ExpectedVsActualDto
                {
                    PlantId = plantId,
                    InverterId = inverterId,
                    From = from,
                    To = to,
                    OverallExpectedPowerKw = 0,
                    OverallActualPowerKw = 0,
                    OverallDeviationPct = 0,
                    IsUnderperforming = false,
                    DataPoints = new List<ExpectedVsActualDataPointDto>()
                };
            }

            var dataPoints = new List<ExpectedVsActualDataPointDto>();
            double totalExpected = 0;
            double totalActual = 0;

            foreach (var record in records)
            {
                var telemetry = record.t;
                var inverter = record.i;

                // Calculate expected power using the 3-parameter overload
                // This returns Expected DC Power based on the PVWatts model
                double expectedPowerKw = await _expectedPowerService.CalculateExpectedPower(
                    inverter,
                    (double)telemetry.Irradiance,
                    (double)telemetry.ModuleTemperature);

                // Actual AC Power from telemetry
                double actualPowerKw = (double)telemetry.AcPowerKw;

                // Calculate deviation and anomaly using the anomaly detection service
                // DeviationPct = ((Actual - Expected) / Expected) * 100
                double deviationPct = _anomalyDetectionService.CalculateDeviationPct(actualPowerKw, expectedPowerKw);
                bool isAnomaly = _anomalyDetectionService.IsAnomaly(actualPowerKw, expectedPowerKw);

                var dataPoint = new ExpectedVsActualDataPointDto
                {
                    Timestamp = telemetry.Timestamp,
                    ExpectedPowerKw = expectedPowerKw,    // Expected DC Power
                    ActualPowerKw = actualPowerKw,        // Actual DC Power
                    DeviationPct = deviationPct,
                    IsAnomaly = isAnomaly
                };

                dataPoints.Add(dataPoint);
                totalExpected += expectedPowerKw;
                totalActual += actualPowerKw;
            }

            double overallExpected = totalExpected / records.Count;
            double overallActual = totalActual / records.Count;
            double overallDeviationPct = 0;
            if (overallExpected != 0)
            {
                overallDeviationPct = ((overallActual - overallExpected) / overallExpected) * 100;
            }

            bool isUnderperforming = overallDeviationPct <= -10;

            return new ExpectedVsActualDto
            {
                PlantId = plantId,
                InverterId = inverterId,
                From = from,
                To = to,
                OverallExpectedPowerKw = overallExpected,    // Average Expected DC Power
                OverallActualPowerKw = overallActual,        // Average Actual DC Power
                OverallDeviationPct = overallDeviationPct,
                IsUnderperforming = isUnderperforming,
                DataPoints = dataPoints
            };
        }
    }
}