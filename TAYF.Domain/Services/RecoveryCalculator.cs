namespace TAYF.Domain.Services;

/// <summary>
/// Provides methods for calculating recovery rate and verification status.
/// </summary>
public static class RecoveryCalculator
{
    /// <summary>
    /// Calculates the recovery rate based on the physics formula.
    /// </summary>
    /// <param name="performanceBefore">Performance before repair (P_before)</param>
    /// <param name="performanceAfter">Performance after repair (P_after)</param>
    /// <param name="expectedPower">Expected power under same conditions (P_expected)</param>
    /// <returns>Recovery rate as a percentage, clamped between 0 and 100.</returns>
    /// <exception cref="InvalidOperationException">Thrown when expectedPower is less than or equal to performanceBefore.</exception>
    public static decimal CalculateRecoveryRate(
        decimal performanceBefore,
        decimal performanceAfter,
        decimal expectedPower)
    {
        var denominator = expectedPower - performanceBefore;
        if (denominator <= 0)
            throw new InvalidOperationException(
                "Expected power must be greater than performance before");

        var numerator = performanceAfter - performanceBefore;
        var recoveryRate = (numerator / denominator) * 100m;
        return Math.Clamp(recoveryRate, 0m, 100m);
    }

    /// <summary>
    /// Determines if the recovery rate meets or exceeds the verification threshold.
    /// </summary>
    /// <param name="recoveryRate">The calculated recovery rate (percentage)</param>
    /// <param name="threshold">The verification threshold (percentage)</param>
    /// <returns>True if recoveryRate >= threshold, false otherwise.</returns>
    public static bool IsVerified(decimal recoveryRate, decimal threshold)
        => recoveryRate >= threshold;
}