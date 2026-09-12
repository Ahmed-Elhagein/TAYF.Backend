using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TAYF.Domain.Entities;

/// <summary>
/// Verifies the effectiveness of a repair or maintenance action
/// </summary>
public class RepairVerification
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int MaintenanceActionId { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal PerformanceBefore { get; set; } // Performance metric before maintenance (e.g., efficiency % or power output)

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal PerformanceAfter { get; set; } // Performance metric after maintenance

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal RecoveryPct { get; set; } // Percentage of performance recovered

    public bool IsStable { get; set; } // Whether the performance is stable after multiple readings

    public bool Verified { get; set; } // Whether the repair is verified (based on multiple after readings and stability)

    public DateTime VerifiedAt { get; set; } // Timestamp when verification was completed

    // Navigation property
    [ForeignKey("MaintenanceActionId")]
    public virtual MaintenanceAction MaintenanceAction { get; set; } = null!;
}