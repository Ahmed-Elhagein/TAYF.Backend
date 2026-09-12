using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TAYF.Domain.Enums;

namespace TAYF.Domain.Entities;
/// <summary>
/// Represents an alert generated for a plant or inverter
/// </summary>
public class Alert
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlantId { get; set; }

    [Required]
    public int InverterId { get; set; }

    [Required]
    public Severity Severity { get; set; }

    [Required]
    [MaxLength(200)]
    public string Problem { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string RootCause { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal FinancialLoss { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal EnergyLossKwh { get; set; }

    [Required]
    public Currency Currency { get; set; } = Currency.EGP;

    [Required]
    [MaxLength(500)]
    public string RecommendedAction { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; }

    public bool IsResolved { get; set; } = false;

    // Navigation properties
    [ForeignKey("PlantId")]
    public virtual Plant Plant { get; set; } = null!;

    [ForeignKey("InverterId")]
    public virtual Inverter Inverter { get; set; } = null!;
}