using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TAYF.Application.Scada;
using TAYF.Application.Scada.Models;
using TAYF.Infrastructure.Scada.Options;
using Microsoft.Extensions.Logging;

namespace TAYF.Infrastructure.Scada
{
    /// <summary>
    /// Implementation of IScadaDataSource that reads SCADA data from CSV files.
    /// </summary>
    public class CsvScadaDataSource : IScadaDataSource
    {
        private readonly IOptions<ScadaCsvOptions> _options;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<CsvScadaDataSource> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvScadaDataSource"/> class.
        /// </summary>
        /// <param name="options">The CSV SCADA options.</param>
        /// <param name="hostEnvironment">The host environment for resolving file paths.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public CsvScadaDataSource(
            IOptions<ScadaCsvOptions> options,
            IHostEnvironment hostEnvironment,
            ILogger<CsvScadaDataSource> logger)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<InverterScadaReading> GetInverterReadingsAsync(
            ScadaQuery query, CancellationToken ct = default)
        {
            return ReadInverterCsvAsync(query, ct);
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<MeteorologicalReading> GetMeteorologicalReadingsAsync(
            ScadaQuery query, CancellationToken ct = default)
        {
            return ReadMeteorologicalCsvAsync(query, ct);
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<GridExportReading> GetGridExportReadingsAsync(
            ScadaQuery query, CancellationToken ct = default)
        {
            return ReadGridExportCsvAsync(query, ct);
        }

        private async IAsyncEnumerable<InverterScadaReading> ReadInverterCsvAsync(
            ScadaQuery query,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
        {
            var filePath = GetFilePath(_options.Value.InverterFile);

            if (!File.Exists(filePath))
            {
                _logger.LogWarning("Inverter SCADA CSV file not found at {FilePath}", filePath);
                yield break;
            }

            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null,
                BadDataFound = null,
                IgnoreBlankLines = true
            };
            using var csv = new CsvReader(reader, config);

            // Configure CSV reader to handle missing values
            csv.Context.TypeConverterOptionsCache.GetOptions<double?>().NullValues.Add(string.Empty);
            csv.Context.TypeConverterOptionsCache.GetOptions<double>().NullValues.Add(string.Empty);

            await foreach (var record in csv.GetRecordsAsync<InverterScadaRecord>(ct))
            {
                // Apply filters
                if (!MatchesQuery(record, query))
                {
                    continue;
                }

                yield return new InverterScadaReading(
                    record.Timestamp,
                    record.InverterId,
                    record.DcPowerKw,
                    record.AcPowerKw,
                    record.DcVoltageV,
                    record.DcCurrentA,
                    record.ModuleTempC,
                    record.InverterEfficiency,
                    record.StatusCode);
            }
        }

        private async IAsyncEnumerable<MeteorologicalReading> ReadMeteorologicalCsvAsync(
            ScadaQuery query,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
        {
            var filePath = GetFilePath(_options.Value.MeteorologicalFile);

            if (!File.Exists(filePath))
            {
                _logger.LogWarning("Meteorological CSV file not found at {FilePath}", filePath);
                yield break;
            }

            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null,
                BadDataFound = null,
                IgnoreBlankLines = true
            };
            using var csv = new CsvReader(reader, config);

            await foreach (var record in csv.GetRecordsAsync<MeteorologicalScadaRecord>(ct))
            {
                // Apply filters
                if (!MatchesQuery(record, query))
                {
                    continue;
                }

                yield return new MeteorologicalReading(
                    record.StationId,
                    record.ReadingTime,
                    record.GhiWm2,
                    record.DniWm2,
                    record.DhiWm2,
                    record.AmbientTemp,
                    record.TempUnit,
                    record.WindSpeedMs,
                    record.RelativeHumidityPct,
                    record.BarometricPressureHpa,
                    record.SolarZenithAngleDeg,
                    record.CloudOpacityPct,
                    record.PrecipitationMm);
            }
        }

        private async IAsyncEnumerable<GridExportReading> ReadGridExportCsvAsync(
            ScadaQuery query,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
        {
            var filePath = GetFilePath(_options.Value.GridExportFile);

            if (!File.Exists(filePath))
            {
                _logger.LogWarning("Grid export CSV file not found at {FilePath}", filePath);
                yield break;
            }

            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null,
                BadDataFound = null,
                IgnoreBlankLines = true
            };
            using var csv = new CsvReader(reader, config);

            await foreach (var record in csv.GetRecordsAsync<GridExportScadaRecord>(ct))
            {
                // Apply filters
                if (!MatchesQuery(record, query))
                {
                    continue;
                }

                yield return new GridExportReading(
                    record.ExportTimestamp,
                    record.InverterId,
                    record.EnergyKwh,
                    record.ReactivePowerKvar,
                    record.CurtailmentFlag,
                    record.TariffRate,
                    record.RevenueUsd,
                    record.PowerFactor,
                    record.FrequencyHz);
            }
        }

        private string GetFilePath(string fileName)
        {
            return Path.Combine(_hostEnvironment.ContentRootPath, _options.Value.BasePath, fileName);
        }

        private bool MatchesQuery<T>(T record, ScadaQuery query) where T : IScadaRecord
        {
            if (query.From.HasValue && record.Timestamp < query.From.Value)
            {
                return false;
            }

            if (query.To.HasValue && record.Timestamp > query.To.Value)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(query.InverterId) &&
                !string.Equals(record.InverterId, query.InverterId, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(query.StationId) &&
                !string.Equals(record.StationId, query.StationId, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Interface for records that have timestamp and identifier properties for querying.
    /// </summary>
    internal interface IScadaRecord
    {
        DateTime Timestamp { get; }
        string InverterId { get; }
        string StationId { get; }
    }

    /// <summary>
    /// CSV record format for inverter SCADA data.
    /// </summary>
    internal class InverterScadaRecord : IScadaRecord
    {
        [Name("timestamp")]
        public DateTime Timestamp { get; set; }
        [Name("inverter_id")]
        public string InverterId { get; set; } = null!;
        [Name("dc_power_kw")]
        public double DcPowerKw { get; set; }
        [Name("ac_power_kw")]
        public double AcPowerKw { get; set; }
        [Name("dc_voltage_v")]
        public double DcVoltageV { get; set; }
        [Name("dc_current_a")]
        public double DcCurrentA { get; set; }
        [Name("module_temp_c")]
        public double ModuleTempC { get; set; }
        [Name("inverter_efficiency")]
        public double? InverterEfficiency { get; set; }
        [Name("status_code")]
        public string StatusCode { get; set; } = null!;
        public string StationId { get; set; } = null!; // Not in CSV but required for interface
    }

    /// <summary>
    /// CSV record format for meteorological data.
    /// </summary>
    internal class MeteorologicalScadaRecord : IScadaRecord
    {
        [Name("station_id")]
        public string StationId { get; set; } = null!;
        [Name("reading_time")]
        public DateTime ReadingTime { get; set; }
        [Name("ghi_wm2")]
        public double GhiWm2 { get; set; }
        [Name("dni_wm2")]
        public double DniWm2 { get; set; }
        [Name("dhi_wm2")]
        public double DhiWm2 { get; set; }
        [Name("ambient_temp")]
        public double AmbientTemp { get; set; }
        [Name("temp_unit")]
        public string TempUnit { get; set; } = null!;
        [Name("wind_speed_ms")]
        public double WindSpeedMs { get; set; }
        [Name("relative_humidity_pct")]
        public double RelativeHumidityPct { get; set; }
        [Name("barometric_pressure_hpa")]
        public double BarometricPressureHpa { get; set; }
        [Name("solar_zenith_angle_deg")]
        public double SolarZenithAngleDeg { get; set; }
        [Name("cloud_opacity_pct")]
        public double CloudOpacityPct { get; set; }
        [Name("precipitation_mm")]
        public double PrecipitationMm { get; set; }

        public DateTime Timestamp => ReadingTime;
        public string InverterId { get; set; } = null!; // Not in CSV but required for interface
    }

    /// <summary>
    /// CSV record format for grid export data.
    /// </summary>
    internal class GridExportScadaRecord : IScadaRecord
    {
        [Name("export_timestamp")]
        public DateTime ExportTimestamp { get; set; }
        [Name("inverter_id")]
        public string InverterId { get; set; } = null!;
        [Name("energy_kwh")]
        public double EnergyKwh { get; set; }
        [Name("reactive_power_kvar")]
        public double ReactivePowerKvar { get; set; }
        [Name("curtailment_flag")]
        public bool CurtailmentFlag { get; set; }
        [Name("tariff_rate")]
        public double TariffRate { get; set; }
        [Name("revenue_usd")]
        public double RevenueUsd { get; set; }
        [Name("power_factor")]
        public double PowerFactor { get; set; }
        [Name("frequency_hz")]
        public double FrequencyHz { get; set; }

        public DateTime Timestamp => ExportTimestamp;
        public string StationId { get; set; } = null!; // Not in CSV but required for interface
    }
}