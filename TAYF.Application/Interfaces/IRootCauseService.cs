using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;

/// <summary>
/// Orchestrates the root cause analysis logic.
/// </summary>
public interface IRootCauseService
{
    /// <summary>
    /// Generates a root cause diagnosis for the given telemetry data.
    /// </summary>
    /// <param name="plantId">The plant identifier.</param>
    /// <param name="inverterId">The inverter identifier.</param>
    /// <param name="timestamp">The timestamp of the telemetry data.</param>
    /// <returns>The root cause diagnosis.</returns>
    Task<RootCauseDiagnosisDto> GetRootCauseDiagnosisAsync(int plantId, int inverterId, DateTime timestamp);
}