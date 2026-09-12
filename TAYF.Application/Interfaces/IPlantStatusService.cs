using TAYF.Domain.Entities;

namespace TAYF.Application.Interfaces;

/// <summary>
/// Aggregates data for plant status dashboard (API 02).
/// </summary>
public interface IPlantStatusService
{
    /// <summary>
    /// Gets the current status of a plant for the dashboard.
    /// </summary>
    /// <param name="plantId">The ID of the plant.</param>
    /// <returns>Plant status data for the dashboard.</returns>
    Task<PlantStatusDto> GetPlantStatusAsync(int plantId);
}

/// <summary>
/// Data Transfer Object for plant status dashboard response.
/// </summary>
public class PlantStatusDto
{
    public int PlantId { get; set; }
    public string PlantName { get; set; } = null!;
    public int TotalInverters { get; set; }
    public int ActiveInverters { get; set; }
    public int AnomalyCount { get; set; }
    public double TotalActualPowerKw { get; set; }
    public double TotalExpectedPowerKw { get; set; }
    public double OverallDeviationPct { get; set; }
    public bool HasCriticalAnomalies { get; set; }
    public DateTime LastUpdated { get; set; }
}