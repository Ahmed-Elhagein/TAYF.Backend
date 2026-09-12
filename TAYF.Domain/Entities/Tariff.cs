using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TAYF.Domain.Enums;

namespace TAYF.Domain.Entities;
/// <summary>
/// Represents the tariff arrangement for a solar plant
/// </summary>
public class Tariff
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlantId { get; set; }

    [Required]
    public TariffType Type { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal Rate { get; set; }

    [Required]
    public Currency Currency { get; set; } = Currency.EGP;

    // Navigation property
    [ForeignKey("PlantId")]
    public virtual Plant Plant { get; set; } = null!;
}