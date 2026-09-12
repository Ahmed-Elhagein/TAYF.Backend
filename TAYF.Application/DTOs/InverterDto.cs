using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TAYF.Application.DTOs;

/// <summary>
/// Data Transfer Object for Inverter data
/// </summary>
public class InverterDto
{
    [Required]
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

    // Navigation properties (DTOs to avoid circular references)
    public virtual PlantDto? Plant { get; set; }
    public virtual ICollection<object> TelemetryRecords { get; set; } = new List<object>(); // Simplified for DTO
}