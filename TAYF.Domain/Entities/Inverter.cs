using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TAYF.Domain.Entities;

/// <summary>
/// Represents a solar inverter within a plant
/// </summary>
public class Inverter
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlantId { get; set; }

    [Required]
    [MaxLength(50)]
    public string SerialNumber { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Model { get; set; } = null!;

    [Required]
    public decimal MaxPowerKw { get; set; }

    public DateTime InstallationDate { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation properties
    [ForeignKey("PlantId")]
    public virtual Plant Plant { get; set; } = null!;

    public virtual ICollection<Telemetry> TelemetryRecords { get; set; } = new List<Telemetry>();
    public virtual ICollection<AnalysisResult> AnalysisResults { get; set; } = new List<AnalysisResult>();
    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
    public virtual ICollection<MaintenanceAction> MaintenanceActions { get; set; } = new List<MaintenanceAction>();
    public virtual ICollection<RepairVerification> RepairVerifications { get; set; } = new List<RepairVerification>();
}