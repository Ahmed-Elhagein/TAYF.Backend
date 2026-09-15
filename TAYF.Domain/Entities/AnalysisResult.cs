using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TAYF.Domain.Enums;

namespace TAYF.Domain.Entities;

/// <summary>
/// Stores the results of analysis performed on telemetry data
/// </summary>
public class AnalysisResult
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
    public decimal ActualPowerKw { get; set; }

    [Required]
    public decimal ExpectedPowerKw { get; set; }

    [Required]
    public decimal DeviationPct { get; set; }

    public bool IsAnomaly { get; set; }

    [Required]
    public Severity Severity { get; set; }

    [Required]
    public decimal AnomalyScore { get; set; }

    [Required]
    [MaxLength(200)]
    public string PrimaryCause { get; set; } = null!;

    public string CauseProbabilities { get; set; } = null!;

    [Required]
    public decimal ConfidenceScore { get; set; }

    [Required]
    public decimal EnergyLossKwh { get; set; }

    [Required]
    public decimal ExpectedEnergyKwh { get; set; }

    [Required]
    public decimal ActualEnergyKwh { get; set; }

    [Required]
    public decimal EstimatedLoss { get; set; }

    [Required]
    public Currency Currency { get; set; } = Currency.EGP;

    [Required]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("PlantId")]
    public virtual Plant Plant { get; set; } = null!;

    [ForeignKey("InverterId")]
    public virtual Inverter Inverter { get; set; } = null!;
}