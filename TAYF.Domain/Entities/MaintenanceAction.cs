using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TAYF.Domain.Enums;

namespace TAYF.Domain.Entities;

/// <summary>
/// Represents a maintenance action performed on a plant or inverter
/// </summary>
public class MaintenanceAction
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlantId { get; set; }

    public int? InverterId { get; set; } // Nullable for plant-level actions

    [Required]
    public ActionType ActionType { get; set; }

    [Required]
    public DateTime StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = null!;

    // Navigation properties
    [ForeignKey("PlantId")]
    public virtual Plant Plant { get; set; } = null!;

    [ForeignKey("InverterId")]
    public virtual Inverter? Inverter { get; set; }

    public virtual ICollection<RepairVerification> RepairVerifications { get; set; } = new List<RepairVerification>();
}