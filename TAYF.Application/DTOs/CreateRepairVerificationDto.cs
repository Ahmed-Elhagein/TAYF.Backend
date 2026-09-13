using System;

namespace TAYF.Application.DTOs;

/// <summary>
/// Data transfer object for creating a repair verification
/// </summary>
public class CreateRepairVerificationDto
{
    /// <summary>
    /// The maintenance action ID this verification is associated with
    /// </summary>
    public int MaintenanceActionId { get; set; }

    /// <summary>
    /// Performance percentage before the maintenance action
    /// </summary>
    public decimal PerformanceBefore { get; set; }

    /// <summary>
    /// Performance percentage after the maintenance action
    /// </summary>
    public decimal PerformanceAfter { get; set; }

    /// <summary>
    /// Expected power under same conditions (for recovery calculation)
    /// </summary>
    public decimal ExpectedPowerKw { get; set; }

    /// <summary>
    /// Indicates if the performance is stable after maintenance
    /// </summary>
    public bool IsStable { get; set; }
}