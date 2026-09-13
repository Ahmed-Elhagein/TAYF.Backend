using System;

namespace TAYF.Application.DTOs;

/// <summary>
/// Data transfer object for RepairVerification entity
/// </summary>
public class RepairVerificationDto
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
    /// Recovery percentage (stored in the entity, not recalculated)
    /// </summary>
    public decimal RecoveryPct { get; set; }

    /// <summary>
    /// Indicates if the performance is stable after maintenance
    /// </summary>
    public bool IsStable { get; set; }

    /// <summary>
    /// Indicates if the verification has been completed
    /// </summary>
    public bool Verified { get; set; }

    /// <summary>
    /// Timestamp when the verification was completed
    /// </summary>
    public DateTime VerifiedAt { get; set; }
}