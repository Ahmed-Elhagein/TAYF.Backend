using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TAYF.Domain.Entities;
using TAYF.Domain.Enums;
using TAYF.Infrastructure.Data;

namespace TAYF.Infrastructure.Seed
{
    /// <summary>
    /// Seeds the database with SCADA data from CSV files.
    /// </summary>
    public class ScadaCsvSeeder
    {
        private readonly TayfDbContext _context;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<ScadaCsvSeeder> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScadaCsvSeeder"/> class.
        /// </summary>
        public ScadaCsvSeeder(
            TayfDbContext context,
            IHostEnvironment hostEnvironment,
            ILogger<ScadaCsvSeeder> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Seeds the database with SCADA data from CSV files.
        /// </summary>
        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("ScadaCsvSeeder: Starting to seed SCADA data from CSV files");

            // Remove old fake telemetry for this plant
            var oldTelemetry = await _context.TelemetryRecords
                .Where(t => t.PlantId == 1)
                .ToListAsync(cancellationToken);

            if (oldTelemetry.Any())
            {
                _context.TelemetryRecords.RemoveRange(oldTelemetry);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("ScadaCsvSeeder: Removed {Count} old telemetry records", oldTelemetry.Count);
            }

            // Load inverters: Dictionary<SerialNumber, Inverter>
            var inverters = await _context.Inverters
                .Where(i => i.PlantId == 1)
                .ToDictionaryAsync(i => i.SerialNumber, i => i, cancellationToken);

            _logger.LogInformation("ScadaCsvSeeder: Loaded {Count} inverters for PlantId=1", inverters.Count);

            // Read CSV files
            var inverterRecords = await ReadInverterCsvAsync(cancellationToken);
            var meteorologicalRecords = await ReadMeteorologicalCsvAsync(cancellationToken);
            var gridExportRecords = await ReadGridExportCsvAsync(cancellationToken);

            _logger.LogInformation(
                "ScadaCsvSeeder: Read {InverterCount} inverter records, {MeteorologicalCount} meteorological records, {GridExportCount} grid export records",
                inverterRecords.Count, meteorologicalRecords.Count, gridExportRecords.Count);

            // Build map: timestamp (minute-truncated) -> meteo reading
            var meteoByTimestamp = meteorologicalRecords
                .GroupBy(m => DateTime.SpecifyKind(new DateTime(
                    m.ReadingTime.Year,
                    m.ReadingTime.Month,
                    m.ReadingTime.Day,
                    m.ReadingTime.Hour,
                    m.ReadingTime.Minute,
                    0), DateTimeKind.Utc))
                .ToDictionary(g => g.Key, g => g.First());

            // Process inverter SCADA rows
            var telemetryRecords = new List<Telemetry>();
            int skippedRows = 0;

            foreach (var inverterRecord in inverterRecords)
            {
                // Convert CSV inverter_id (e.g., "INV-01") to DB SerialNumber (e.g., "INV-CAIRO-001")
                var csvInverterId = inverterRecord.InverterId;
                if (!csvInverterId.StartsWith("INV-"))
                {
                    _logger.LogWarning("ScadaCsvSeeder: Unexpected inverter ID format '{InverterId}', skipping row", csvInverterId);
                    skippedRows++;
                    continue;
                }

                var numberPart = csvInverterId.Substring(4);
                if (!int.TryParse(numberPart, out var number))
                {
                    _logger.LogWarning("ScadaCsvSeeder: Invalid inverter number in '{InverterId}'", csvInverterId);
                    skippedRows++;
                    continue;
                }

                var serialNumber = $"INV-CAIRO-{number:D3}";
                if (!inverters.TryGetValue(serialNumber, out var inverter))
                {
                    _logger.LogWarning("ScadaCsvSeeder: Inverter with SerialNumber '{SerialNumber}' not found, skipping row", serialNumber);
                    skippedRows++;
                    continue;
                }

                int inverterId = inverter.Id;

                // Find meteo by matching timestamp (truncated to minute)
                var inverterTs = DateTime.SpecifyKind(new DateTime(
                    inverterRecord.Timestamp.Year,
                    inverterRecord.Timestamp.Month,
                    inverterRecord.Timestamp.Day,
                    inverterRecord.Timestamp.Hour,
                    inverterRecord.Timestamp.Minute,
                    0), DateTimeKind.Utc);

                if (!meteoByTimestamp.TryGetValue(inverterTs, out var meteoRecord))
                {
                    _logger.LogWarning("ScadaCsvSeeder: No meteorological data found for timestamp {Timestamp}", inverterRecord.Timestamp);
                    skippedRows++;
                    continue;
                }

                // Get DC and AC power from record
                var dcPower = inverterRecord.DcPowerKw ?? 0;
                var acPower = inverterRecord.AcPowerKw ?? 0;

                // Sanity: if DC/AC > 1000, it's likely in watts. Convert to kW.
                if (dcPower > 1000) dcPower = dcPower / 1000.0;
                if (acPower > 1000) acPower = acPower / 1000.0;

                // Skip if DC power exceeds 2x the inverter's MaxPowerKw
                if (dcPower > (double)inverter.MaxPowerKw * 2)
                {
                    _logger.LogWarning("ScadaCsvSeeder: Skipping: DC={Dc} exceeds MaxPower={Max} for {Serial}",
                        dcPower, inverter.MaxPowerKw, serialNumber);
                    skippedRows++;
                    continue;
                }

                var dni = meteoRecord.DniWm2 ?? 0;
                var ghi = meteoRecord.GhiWm2 ?? 0;
                // Use DNI if available (closer to POA on tilted panels), else GHI
                var poa = dni > 0 ? dni : ghi;

                // Create Telemetry record
                var telemetry = new Telemetry
                {
                    PlantId = 1,
                    InverterId = inverterId,
                    Timestamp = DateTime.SpecifyKind(inverterRecord.Timestamp, DateTimeKind.Utc),
                    AcPowerKw = (decimal)acPower,
                    DcPowerKw = (decimal)dcPower,
                    Irradiance = (int)Math.Round(poa),
                    AmbientTemperature = (decimal)(meteoRecord.AmbientTemp ?? 0),
                    ModuleTemperature = (decimal)(inverterRecord.ModuleTempC ?? 0),
                    DailyYield = 0,
                    TotalYield = 0
                };

                telemetryRecords.Add(telemetry);
            }

            // Bulk insert telemetry records
            if (telemetryRecords.Any())
            {
                await _context.TelemetryRecords.AddRangeAsync(telemetryRecords, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("ScadaCsvSeeder: Inserted {Count} telemetry records", telemetryRecords.Count);
            }
            else
            {
                _logger.LogWarning("ScadaCsvSeeder: No telemetry records to insert");
            }

            _logger.LogInformation("ScadaCsvSeeder: Seeding completed. Skipped {Count} rows due to missing data", skippedRows);
        }

        private async Task<List<InverterScadaRecord>> ReadInverterCsvAsync(CancellationToken cancellationToken)
        {
            var filePath = GetFilePath("Inverter SCADA.csv");

            if (!File.Exists(filePath))
            {
                _logger.LogWarning("Inverter SCADA CSV file not found at {FilePath}", filePath);
                return new List<InverterScadaRecord>();
            }

            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                BadDataFound = null,
                IgnoreBlankLines = true,
            };
            using var csv = new CsvReader(reader, config);

            csv.Context.TypeConverterOptionsCache.GetOptions<double?>().NullValues.Add(string.Empty);
            csv.Context.TypeConverterOptionsCache.GetOptions<double>().NullValues.Add(string.Empty);

            var records = new List<InverterScadaRecord>();
            await foreach (var r in csv.GetRecordsAsync<InverterScadaRecord>(cancellationToken))
                records.Add(r);

            _logger.LogInformation("ScadaCsvSeeder: Read {Count} inverter records from CSV", records.Count);
            return records;
        }

        private async Task<List<MeteorologicalScadaRecord>> ReadMeteorologicalCsvAsync(CancellationToken cancellationToken)
        {
            var filePath = GetFilePath("Meteorological data.csv");

            if (!File.Exists(filePath))
            {
                _logger.LogWarning("Meteorological CSV file not found at {FilePath}", filePath);
                return new List<MeteorologicalScadaRecord>();
            }

            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                BadDataFound = null,
                IgnoreBlankLines = true,
            };
            using var csv = new CsvReader(reader, config);

            csv.Context.TypeConverterOptionsCache.GetOptions<double?>().NullValues.Add(string.Empty);
            csv.Context.TypeConverterOptionsCache.GetOptions<double>().NullValues.Add(string.Empty);

            var records = new List<MeteorologicalScadaRecord>();
            await foreach (var record in csv.GetRecordsAsync<MeteorologicalScadaRecord>(cancellationToken))
            {
                records.Add(record);
            }

            _logger.LogInformation("ScadaCsvSeeder: Read {Count} meteorological records from CSV", records.Count);
            return records;
        }

        private async Task<List<GridExportScadaRecord>> ReadGridExportCsvAsync(CancellationToken cancellationToken)
        {
            var filePath = GetFilePath("Grid export data.csv");

            if (!File.Exists(filePath))
            {
                _logger.LogWarning("Grid export CSV file not found at {FilePath}", filePath);
                return new List<GridExportScadaRecord>();
            }

            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                BadDataFound = null,
                IgnoreBlankLines = true,
            };
            using var csv = new CsvReader(reader, config);

            var records = new List<GridExportScadaRecord>();
            await foreach (var record in csv.GetRecordsAsync<GridExportScadaRecord>(cancellationToken))
            {
                records.Add(record);
            }

            _logger.LogInformation("ScadaCsvSeeder: Read {Count} grid export records from CSV", records.Count);
            return records;
        }

        private string GetFilePath(string fileName)
        {
            return Path.Combine(_hostEnvironment.ContentRootPath, "Seed/pv_scada", fileName);
        }

        // CSV record formats
        private class InverterScadaRecord
        {
            [Name("timestamp")] public DateTime Timestamp { get; set; }
            [Name("inverter_id")] public string InverterId { get; set; } = null!;
            [Name("dc_power_kw")] public double? DcPowerKw { get; set; }
            [Name("ac_power_kw")] public double? AcPowerKw { get; set; }
            [Name("dc_voltage_v")] public double? DcVoltageV { get; set; }
            [Name("dc_current_a")] public double? DcCurrentA { get; set; }
            [Name("module_temp_c")] public double? ModuleTempC { get; set; }
            [Name("inverter_efficiency")] public double? InverterEfficiency { get; set; }
            [Name("status_code")] public string StatusCode { get; set; } = null!;
        }

        private class MeteorologicalScadaRecord
        {
            [Name("station_id")] public string StationId { get; set; } = null!;
            [Name("reading_time")] public DateTime ReadingTime { get; set; }
            [Name("ghi_wm2")] public double? GhiWm2 { get; set; }
            [Name("dni_wm2")] public double? DniWm2 { get; set; }
            [Name("dhi_wm2")] public double? DhiWm2 { get; set; }
            [Name("ambient_temp")] public double? AmbientTemp { get; set; }
            [Name("temp_unit")] public string TempUnit { get; set; } = null!;
            [Name("wind_speed_ms")] public double? WindSpeedMs { get; set; }
            [Name("relative_humidity_pct")] public double? RelativeHumidityPct { get; set; }
            [Name("barometric_pressure_hpa")] public double? BarometricPressureHpa { get; set; }
            [Name("solar_zenith_angle_deg")] public double? SolarZenithAngleDeg { get; set; }
            [Name("cloud_opacity_pct")] public double? CloudOpacityPct { get; set; }
            [Name("precipitation_mm")] public double? PrecipitationMm { get; set; }
        }

        private class GridExportScadaRecord
        {
            [Name("export_timestamp")] public DateTime ExportTimestamp { get; set; }
            [Name("inverter_id")] public string InverterId { get; set; } = null!;
            [Name("energy_kwh")] public double? EnergyKwh { get; set; }
            [Name("reactive_power_kvar")] public double? ReactivePowerKvar { get; set; }
            [Name("curtailment_flag")] public bool? CurtailmentFlag { get; set; }
            [Name("tariff_rate")] public double? TariffRate { get; set; }
            [Name("revenue_usd")] public double? RevenueUsd { get; set; }
            [Name("power_factor")] public double? PowerFactor { get; set; }
            [Name("frequency_hz")] public double? FrequencyHz { get; set; }
        }
    }
}