namespace TAYF.Domain.Enums;

/// <summary>
/// Severity levels for anomalies and alerts
/// </summary>
public enum Severity
{
    /// <summary>
    /// Low severity - informational, no immediate action required
    /// </summary>
    Low = 1,

    /// <summary>
    /// Medium severity - warning, should be investigated
    /// </summary>
    Medium = 2,

    /// <summary>
    /// High severity - critical issue requiring prompt attention
    /// </summary>
    High = 3,

    /// <summary>
    /// Critical severity - emergency situation requiring immediate action
    /// </summary>
    Critical = 4
}