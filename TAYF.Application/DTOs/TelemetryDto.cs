using System.ComponentModel.DataAnnotations;

namespace TAYF.Application.DTOs;

/// <summary>
/// Data Transfer Object for telemetry data ingestion
/// Matches the example from the specification
/// </summary>
public class TelemetryDto
{
    [Required]
    public int PlantId { get; set; }

    [Required]
    public int InverterId { get; set; }

    [Required]
    public string Timestamp { get; set; } = null!;

    [Required]
    [Range(0, double.MaxValue)]
    public double AcPowerKw { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public double DcPowerKw { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public double Irradiance { get; set; }

    [Required]
    public double AmbientTemperature { get; set; }

    [Required]
    public double ModuleTemperature { get; set; }

    [Required]
    public int DailyYield { get; set; }

    [Required]
    public long TotalYield { get; set; }
}

/// <summary>
/// Response DTO for telemetry ingestion
/// </summary>
public class TelemetryDtoResponse
{
    public int TelemetryId { get; set; }
    public bool Received { get; set; }
}