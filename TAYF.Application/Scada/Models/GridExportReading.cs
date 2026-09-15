using System;

namespace TAYF.Application.Scada.Models
{
    /// <summary>
    /// Represents a single grid export reading from an inverter.
    /// </summary>
    public record GridExportReading(
        DateTime ExportTimestamp,
        string InverterId,
        double EnergyKwh,
        double ReactivePowerKvar,
        bool CurtailmentFlag,
        double TariffRate,
        double RevenueUsd,
        double PowerFactor,
        double FrequencyHz);
}