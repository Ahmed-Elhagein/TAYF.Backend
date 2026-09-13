using System;

namespace TAYF.Application.DTOs;

/// <summary>
/// Telemetry history DTO (subset of Telemetry entity)
/// </summary>
public class TelemetryHistoryDto
{
    /// <summary>
    /// Telemetry record ID
    /// </>
    public int Id { get; set; }

    /// <summary>
    /// Plant ID
    /// </summary>
    public int PlantId { get; set; }

    /// <summary>
    /// Inverter ID
    /// </summary>
    public int InverterId { get; set; }

    /// <summary>
    /// Timestamp of the telemetry record
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// AC power in kW
    /// </summary>
    public decimal AcPowerKw { get; set; }

    /// <summary>
    /// DC power in kW
    /// </summary>
    public decimal DcPowerKw { get; set; }

    /// <summary>
    /// Irradiance in W/m²
    /// </summary>
    public int Irradiance { get; set; }

    /// <summary>
    /// Ambient temperature in °C
    /// </summary>
    public decimal AmbientTemperature { get; set; }

    /// <summary>
    /// Module temperature in °C
    /// </summary>
    public decimal ModuleTemperature { get; set; }

    /// <summary>
    /// Daily yield in kWh
    /// </summary>
    public int DailyYield { get; set; }

    /// <summary>
    /// Total yield in kWh
    /// </summary>
    public long TotalYield { get; set; }
}