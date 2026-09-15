using System;

namespace TAYF.Application.Scada.Models
{
    /// <summary>
    /// Represents a single meteorological reading from a weather station.
    /// </summary>
    public record MeteorologicalReading(
        string StationId,
        DateTime ReadingTime,
        double GhiWm2,
        double DniWm2,
        double DhiWm2,
        double AmbientTemp,
        string TempUnit,
        double WindSpeedMs,
        double RelativeHumidityPct,
        double BarometricPressureHpa,
        double SolarZenithAngleDeg,
        double CloudOpacityPct,
        double PrecipitationMm);
}