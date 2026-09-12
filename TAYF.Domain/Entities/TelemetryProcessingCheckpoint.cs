using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TAYF.Domain.Entities;

namespace TAYF.Domain.Entities;
/// <summary>
/// Tracks the last processed telemetry timestamp for each inverter to ensure exactly-once processing.
/// </summary>
public class TelemetryProcessingCheckpoint
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int InverterId { get; set; }

    [Required]
    public DateTime LastProcessedUtc { get; set; }

    // Optional: track when the checkpoint was last updated
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    [ForeignKey("InverterId")]
    public virtual Inverter Inverter { get; set; } = null!;
}