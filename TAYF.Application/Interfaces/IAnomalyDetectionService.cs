using TAYF.Domain.Entities;

namespace TAYF.Application.Interfaces;

/// <summary>
/// Detects anomalies by comparing expected vs actual power.
/// </summary>
public interface IAnomalyDetectionService
{
    /// <summary>
    /// Determines if telemetry data represents an anomaly.
    /// Rule: If DeviationPct <= -10%, it is an anomaly.
    /// </summary>
    /// <param name="actualPowerKw">The actual power output in kW.</param>
    /// <param name="expectedPowerKw">The expected power output in kW.</param>
    /// <returns>True if anomaly detected, false otherwise.</returns>
    bool IsAnomaly(double actualPowerKw, double expectedPowerKw);

    /// <summary>
    /// Calculates the deviation percentage between actual and expected power.
    /// </summary>
    /// <param name="actualPowerKw">The actual power output in kW.</param>
    /// <param name="expectedPowerKw">The expected power output in kW.</param>
    /// <returns>The deviation percentage.</returns>
    double CalculateDeviationPct(double actualPowerKw, double expectedPowerKw);
}