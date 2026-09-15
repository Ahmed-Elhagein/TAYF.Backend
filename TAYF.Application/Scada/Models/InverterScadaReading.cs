using System;

namespace TAYF.Application.Scada.Models
{
    /// <summary>
    /// Represents a single reading from an inverter SCADA system.
    /// </summary>
    public record InverterScadaReading(
        DateTime Timestamp,
        string InverterId,
        double DcPowerKw,
        double AcPowerKw,
        double DcVoltageV,
        double DcCurrentA,
        double ModuleTempC,
        double? InverterEfficiency,
        string StatusCode);
}