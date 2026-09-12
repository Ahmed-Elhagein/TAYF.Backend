using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services;

/// <summary>
/// Detects anomalies by comparing Expected vs Actual. Rule: If DeviationPct <= -10%, it is an anomaly.
/// </summary>
public class AnomalyDetectionService : IAnomalyDetectionService
{
    /// <summary>
    /// Determines if telemetry data represents an anomaly.
    /// Rule: If DeviationPct <= -10%, it is an anomaly.
    /// </summary>
    /// <param name="actualPowerKw">The actual power output in kW.</param>
    /// <param name="expectedPowerKw">The expected power output in kW.</param>
    /// <returns>True if anomaly detected, false otherwise.</returns>
    public bool IsAnomaly(double actualPowerKw, double expectedPowerKw)
    {
        if (expectedPowerKw == 0)
        {
            // Avoid division by zero - if expected power is zero, we can't calculate deviation
            return false;
        }

        double deviationPct = CalculateDeviationPct(actualPowerKw, expectedPowerKw);
        return deviationPct <= -10.0; // Anomaly if deviation is less than or equal to -10%
    }

    /// </// Calculates the deviation percentage between actual and expected power.
    /// </summary>
    /// <param name="actualPowerKw">The actual power output in kW.</param>
    /// <param name="expectedPowerKw">The expected power output in kW.</param>
    /// <returns>The deviation percentage.</returns>
    public double CalculateDeviationPct(double actualPowerKw, double expectedPowerKw)
    {
        if (expectedPowerKw == 0)
        {
            // Avoid division by zero
            return 0;
        }

        // DeviationPct = ((Actual - Expected) / Expected) * 100
        return ((actualPowerKw - expectedPowerKw) / expectedPowerKw) * 100.0;
    }
}