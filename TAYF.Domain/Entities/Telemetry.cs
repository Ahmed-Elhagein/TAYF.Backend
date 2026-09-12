using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TAYF.Domain.Entities;

/// <summary>
/// Represents telemetry data collected from a solar inverter
/// </summary>
public class Telemetry
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlantId { get; set; }

    [Required]
    public int InverterId { get; set; }

    [Required]
    public DateTime Timestamp { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal AcPowerKw { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DcPowerKw { get; set; }

    [Required]
    public int Irradiance { get; set; } // in W/m²

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal AmbientTemperature { get; set; } // in Celsius

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal ModuleTemperature { get; set; } // in Celsius

    [Required]
    public int DailyYield { get; set; } // in Wh

    [Required]
    public long TotalYield { get; set; } // in Wh

    // Navigation properties
    [ForeignKey("PlantId")]
    public virtual Plant Plant { get; set; } = null!;

    [ForeignKey("InverterId")]
    public virtual Inverter Inverter { get; set; } = null!;
}