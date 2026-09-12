using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;

/// <summary>
/// Bridge/contract to the external Python ML API for root cause analysis.
/// </summary>
public interface IRootCauseModelClient
{
    /// <summary>
    /// Gets the root cause probabilities from the ML model.
    /// </summary>
    /// <param name="plantId">The plant identifier.</param>
    /// <param name="inverterId">The inverter identifier.</param>
    /// <param name="timestamp">The timestamp of the telemetry data.</param>
    /// <returns>A dictionary of cause probabilities.</returns>
    Task<Dictionary<string, double>> GetRootCauseProbabilitiesAsync(int plantId, int inverterId, DateTime timestamp);
}