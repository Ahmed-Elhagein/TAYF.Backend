using Microsoft.EntityFrameworkCore;
using TAYF.Application.Interfaces;
using TAYF.Application.Services;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services;

/// <summary>
/// Aggregates data for plant status dashboard (API 02).
/// </summary>
public class PlantStatusService : IPlantStatusService
{
    private readonly IApplicationDbContext _context;
    private readonly IExpectedPowerService _expectedPowerService;
    private readonly IAnomalyDetectionService _anomalyDetectionService;

    public PlantStatusService(
        IApplicationDbContext context,
        IExpectedPowerService expectedPowerService,
        IAnomalyDetectionService anomalyDetectionService)
    {
        _context = context;
        _expectedPowerService = expectedPowerService;
        _anomalyDetectionService = anomalyDetectionService;
    }

    /// <summary>
    /// Gets the current status of a plant for the dashboard.
    /// </summary>
    /// <param name="plantId">The ID of the plant.</param>
    /// <returns>Plant status data for the dashboard.</returns>
    public async Task<PlantStatusDto> GetPlantStatusAsync(int plantId)
    {
        // Get the plant with its inverters
        var plant = await _context.Plants
            .Include(p => p.Inverters)
            .FirstOrDefaultAsync(p => p.Id == plantId);

        if (plant == null)
        {
            throw new ArgumentException($"Plant with ID {plantId} not found");
        }

        // Get the latest telemetry for each inverter in the plant
        var inverterStatuses = new List<InverterStatus>();
        int anomalyCount = 0;
        double totalActualPower = 0;
        double totalExpectedPower = 0;

        foreach (var inverter in plant.Inverters.Where(i => i.IsActive))
        {
            // Get the most recent telemetry for this inverter
            var latestTelemetry = await _context.TelemetryRecords
                .Where(t => t.InverterId == inverter.Id)
                .OrderByDescending(t => t.Timestamp)
                .FirstOrDefaultAsync();

            if (latestTelemetry != null)
            {
                // Calculate expected power using PVWatts model with module temperature
                double expectedPower = await _expectedPowerService.CalculateExpectedPower(
                    inverter,
                    (double)latestTelemetry.Irradiance,
                    (double)latestTelemetry.ModuleTemperature);

                // Check for anomaly
                bool isAnomaly = _anomalyDetectionService.IsAnomaly(
                    (double)latestTelemetry.AcPowerKw,
                    expectedPower);

                if (isAnomaly)
                {
                    anomalyCount++;
                }

                // Accumulate totals
                totalActualPower += (double)latestTelemetry.AcPowerKw;
                totalExpectedPower += expectedPower;

                inverterStatuses.Add(new InverterStatus
                {
                    InverterId = inverter.Id,
                    SerialNumber = inverter.SerialNumber,
                    IsActive = inverter.IsActive,
                    LatestTelemetryTimestamp = latestTelemetry.Timestamp,
                    ActualPowerKw = (double)latestTelemetry.AcPowerKw,
                    ExpectedPowerKw = expectedPower,
                    DeviationPct = _anomalyDetectionService.CalculateDeviationPct(
                        (double)latestTelemetry.AcPowerKw,
                        expectedPower),
                    IsAnomaly = isAnomaly
                });
            }
        }

        // Calculate overall deviation
        double overallDeviationPct = 0;
        if (totalExpectedPower > 0)
        {
            overallDeviationPct = ((totalActualPower - totalExpectedPower) / totalExpectedPower) * 100.0;
        }

        // Determine if there are critical anomalies (for simplicity, any anomaly is considered critical in this baseline)
        bool hasCriticalAnomalies = anomalyCount > 0;

        return new PlantStatusDto
        {
            PlantId = plant.Id,
            PlantName = plant.Name,
            TotalInverters = plant.Inverters.Count(i => i.IsActive),
            ActiveInverters = plant.Inverters.Count(i => i.IsActive),
            AnomalyCount = anomalyCount,
            TotalActualPowerKw = totalActualPower,
            TotalExpectedPowerKw = totalExpectedPower,
            OverallDeviationPct = overallDeviationPct,
            HasCriticalAnomalies = hasCriticalAnomalies,
            LastUpdated = DateTime.UtcNow
        };
    }
}

/// <summary>
/// Helper class to hold inverter status information.
/// </summary>
public class InverterStatus
{
    public int InverterId { get; set; }
    public string SerialNumber { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime LatestTelemetryTimestamp { get; set; }
    public double ActualPowerKw { get; set; }
    public double ExpectedPowerKw { get; set; }
    public double DeviationPct { get; set; }
    public bool IsAnomaly { get; set; }
}