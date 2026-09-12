using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEnergyLossFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ActualEnergyKwh",
                table: "AnalysisResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpectedEnergyKwh",
                table: "AnalysisResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EnergyLossKwh",
                table: "Alerts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.03m, 22m, 164, 0m, 0, 22m, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.1m, 21m, 624, 0m, 49, 22.22m, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.85m, 19m, 17098, 19m, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 1.62m, 21m, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.95m, 17m, 17687, 0, 17m, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.95m, 28m, 11681, 31, 28.78m, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 3.83m, 22973, 0m, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 4.69m, 31m, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.87m, 29m, 5194, 4.56m, 49, 30.22m, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 29m, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.34m, 41m, 14046, 3.96m, 753, 59.82m, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 3.59m, 849, 58.22m, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 826, 58.65m, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.89m, 39m, 11327, 1.43m, 772, 58.3m, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 39m, 0, 0m, 848, 60.2m, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.67m, 0, 32m, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 45, 28.12m, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.96m, 32m, 23751, 2.42m, 32m, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.81m, 31m, 10868, 2.31m, 31m, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.21m, 7269, 0m, 0, 30m, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 3.98m, 27, 21.68m, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.74m, 22m, 16417, 0m, 15, 22.38m, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 22m, 0, 1.92m, 19, 22.48m, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 19m, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 20m, 0, 47, 21.18m, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.92m, 27m, 23547, 2.91m, 18, 27.45m, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "Timestamp" },
                values: new object[] { 3.08m, 30m, 18498, 4.03m, 0, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0m, 0, 27m, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 2.71m, 0, 29m, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.31m, 30m, 7844, 0m, 0, 30m, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.41m, 41m, 8447, 2.74m, 840, 62m, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.22m, 38m, 7311, 1.52m, 849, 59.22m, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.5m, 37m, 20979, 1.59m, 791, 56.78m, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 766, 56.15m, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 40m, 1.22m, 810, 60.25m, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.13m, 28m, 6808, 2.42m, 28m, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AcPowerKw", "DailyYield", "Timestamp" },
                values: new object[] { 2.12m, 12748, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.65m, 31m, 9893, 0m, 40, 32m, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "DcPowerKw", "Timestamp" },
                values: new object[] { 0.8m, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 4.8m, 0, 32m, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.76m, 18m, 16557, 4.4m, 0, 18m, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.17m, 18m, 13039, 3.61m, 18m, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.38m, 18m, 20260, 1.9m, 18m, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 18m, 0, 18m, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 0m, 48, 20.2m, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.37m, 8203, 0m, 17, 32.42m, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DcPowerKw", "Timestamp" },
                values: new object[] { 2.63m, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 3.67m, 10, 31.25m, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.24m, 32m, 19415, 0m, 44, 33.1m, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.46m, 31m, 2733, 4.14m, 38, 31.95m, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 39m, 792, 58.8m, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.83m, 40m, 10951, 0m, 760, 59m, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.08m, 42m, 6508, 4.67m, 829, 62.72m, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.33m, 38m, 19969, 4.1m, 792, 57.8m, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 0.86m, 816, 57.4m, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.19m, 29m, 13147, 0m, 28, 29.7m, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 3.79m, 0, 32m, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 2.65m, 40, 28m, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DcPowerKw", "Timestamp" },
                values: new object[] { 2.61m, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.3m, 30m, 1775, 1.75m, 30m, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 11, 17.27m, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.21m, 1239, 2.05m, 0, 19m, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 2.34m, 27, 17.68m, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 3.26m, 17m, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 0.67m, 17m, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 4.22m, 32m, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 0, 32m, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.49m, 0, 28m, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.98m, 29m, 5879, 0.6m, 29m, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 0m, 32m, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 41m, 0, 0m, 769, 60.22m, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 39m, 0, 797, 58.92m, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.68m, 37m, 16076, 0.53m, 802, 57.05m, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.26m, 41m, 13534, 1.47m, 781, 60.53m, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.21m, 38m, 19230, 0m, 831, 58.78m, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.05m, 32m, 12282, 3.82m, 34, 32.85m, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.71m, 27m, 22275, 4.84m, 0, 27m, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 4.27m, 19, 28.48m, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 12, 29.3m, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.17m, 27m, 7016, 0m, 5, 27.12m, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 22m, 3.47m, 22m, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.71m, 20m, 16231, 0.58m, 20m, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.37m, 20m, 2233, 1.67m, 20m, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.42m, 18m, 2523, 0, 18m, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.91m, 20m, 5474, 0.35m, 0, 20m, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.1m, 30, 27.75m, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.39m, 29m, 20317, 4.45m, 29m, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 4.43m, 28, 31.7m, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 9, 31.22m, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 3.35m, 20084, 0.2m, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 0.77m, 756, 55.9m, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 779, 61.48m, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.04m, 210, 0m, 775, 61.38m, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.85m, 40m, 23129, 0m, 797, 59.92m, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.93m, 38m, 17585, 777, 57.42m, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.28m, 13680, 36, 30.9m, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.64m, 32m, 3855, 0m, 49, 33.22m, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 0.22m, 32, 28.8m, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.34m, 28m, 2040, 0m, 28m, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 0, 30m, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 19m, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 2.7m, 17m, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.37m, 17m, 8203, 2.23m, 45, 18.12m, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 4.38m, 0, 17m, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 4.65m, 21m, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 2.96m, 22, 31.55m, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 2.22m, 0, 29m, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.23m, 27m, 19405, 2.36m, 0, 27m, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 0.02m, 19, 31.48m, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 31, 31.78m, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 42m, 0, 4.75m, 787, 61.68m, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.33m, 40m, 19986, 4.86m, 750, 58.75m, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.31m, 41m, 13855, 3.4m, 756, 59.9m, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.11m, 39m, 18680, 0m, 793, 58.82m, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.27m, 41m, 7612, 808, 61.2m, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.16m, 29m, 12966, 1.33m, 29m, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.81m, 27m, 22843, 0m, 0, 27m, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.08m, 28m, 12502, 2.29m, 8, 28.2m, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 3.11m, 32, 28.8m, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.11m, 28m, 683, 3.35m, 46, 29.15m, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.68m, 22106, 0m, 15, 19.38m, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.55m, 15273, 27, 19.68m, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 2.27m, 0, 20m, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 41, 19.02m, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.7m, 19m, 16181, 0m, 0, 19m, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 2.32m, 43, 29.08m, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.53m, 30m, 21151, 0m, 22, 30.55m, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.68m, 28m, 4065, 8, 28.2m, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.36m, 29m, 8149, 0m, 12, 29.3m, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 28m, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 4.78m, 827, 58.68m, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 835, 60.88m, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 0.82m, 766, 57.15m, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 37m, 844, 58.1m, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 0m, 837, 58.92m, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 1.28m, 39, 28.98m, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 13, 31.32m, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.47m, 29m, 20826, 0m, 38, 29.95m, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.74m, 29m, 22450, 38, 29.95m, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.95m, 30m, 23709, 3.02m, 0, 30m, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualEnergyKwh",
                table: "AnalysisResults");

            migrationBuilder.DropColumn(
                name: "ExpectedEnergyKwh",
                table: "AnalysisResults");

            migrationBuilder.DropColumn(
                name: "EnergyLossKwh",
                table: "Alerts");

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.49m, 18m, 8956, 0.06m, 44, 19.1m, new DateTime(2026, 9, 4, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.79m, 17m, 22756, 2.54m, 25, 17.62m, new DateTime(2026, 9, 4, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.54m, 20m, 21232, 20m, new DateTime(2026, 9, 4, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 1.46m, 17m, new DateTime(2026, 9, 4, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 20m, 0, 30, 20.75m, new DateTime(2026, 9, 4, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.75m, 27m, 10481, 0, 27m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 2.02m, 12109, 4.99m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.54m, 30m, 15228, 0m, 30m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0.4m, 31, 32.78m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.01m, 30m, 18076, 30m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 0.52m, 770, 56.25m, new DateTime(2026, 9, 4, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.4m, 38m, 2394, 0m, 818, 58.45m, new DateTime(2026, 9, 4, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 750, 60.75m, new DateTime(2026, 9, 4, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.73m, 40m, 10350, 0.55m, 826, 60.65m, new DateTime(2026, 9, 4, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.66m, 38m, 9955, 4.96m, 834, 58.85m, new DateTime(2026, 9, 4, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.59m, 22, 32.55m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 0, 32m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.73m, 27m, 16357, 0m, 27m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.11m, 28m, 12647, 0m, 28m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 4.39m, 5, 30.12m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.45m, 20m, 14719, 4.42m, 33, 20.82m, new DateTime(2026, 9, 5, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.71m, 21m, 16269, 1.43m, 0, 21m, new DateTime(2026, 9, 5, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.22m, 20m, 1307, 0m, 0, 20m, new DateTime(2026, 9, 5, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.63m, 30, 19.75m, new DateTime(2026, 9, 5, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.42m, 17m, 14549, 39, 17.98m, new DateTime(2026, 9, 5, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.36m, 28m, 8168, 0m, 37, 28.92m, new DateTime(2026, 9, 5, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 1.82m, 40, new DateTime(2026, 9, 5, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.64m, 28m, 9860, 0.8m, 35, 28.88m, new DateTime(2026, 9, 5, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.13m, 6804, 0m, 32, 29.8m, new DateTime(2026, 9, 5, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.46m, 31m, 14768, 0.52m, 25, 31.62m, new DateTime(2026, 9, 5, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 0.12m, 838, 58.95m, new DateTime(2026, 9, 5, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 41m, 0, 0m, 794, 60.85m, new DateTime(2026, 9, 5, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.68m, 40m, 16085, 1.14m, 799, 59.98m, new DateTime(2026, 9, 5, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.44m, 41m, 20669, 846, 62.15m, new DateTime(2026, 9, 5, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 39m, 0m, 818, 59.45m, new DateTime(2026, 9, 5, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 32m, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AcPowerKw", "DailyYield", "Timestamp" },
                values: new object[] { 0m, 0, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 2.99m, 0, 30m, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "DcPowerKw", "Timestamp" },
                values: new object[] { 0m, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28, 32.7m, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.44m, 20m, 20614, 1.11m, 18, 20.45m, new DateTime(2026, 9, 6, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 22m, 0, 0m, 22m, new DateTime(2026, 9, 6, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 0m, 21m, new DateTime(2026, 9, 6, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.66m, 17m, 3948, 17m, new DateTime(2026, 9, 6, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.51m, 22m, 15034, 0.14m, 3, 22.08m, new DateTime(2026, 9, 6, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.14m, 6832, 3.68m, 0, 32m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DcPowerKw", "Timestamp" },
                values: new object[] { 3.94m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0m, 0, 27m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.55m, 30m, 3288, 3.75m, 9, 30.22m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.24m, 29m, 7426, 0m, 23, 29.58m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 40m, 755, 58.88m, new DateTime(2026, 9, 6, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.1m, 42m, 6577, 0.88m, 792, 61.8m, new DateTime(2026, 9, 6, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.25m, 41m, 7479, 4.71m, 828, 61.7m, new DateTime(2026, 9, 6, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 0m, 790, 56.75m, new DateTime(2026, 9, 6, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.93m, 42m, 23594, 3.92m, 803, 62.08m, new DateTime(2026, 9, 6, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 2.4m, 36, 28.9m, new DateTime(2026, 9, 6, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 4.74m, 34, 29.85m, new DateTime(2026, 9, 6, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 0m, 49, 33.22m, new DateTime(2026, 9, 6, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DcPowerKw", "Timestamp" },
                values: new object[] { 0m, new DateTime(2026, 9, 6, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.12m, 31m, 18720, 3.07m, 31m, new DateTime(2026, 9, 6, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 0, 19m, new DateTime(2026, 9, 7, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.46m, 8789, 0m, 36, 19.9m, new DateTime(2026, 9, 7, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 0m, 46, 22.15m, new DateTime(2026, 9, 7, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 0m, 20m, new DateTime(2026, 9, 7, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.84m, 18m, 17051, 0m, 18m, new DateTime(2026, 9, 7, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.31m, 31m, 7841, 0m, 31m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.06m, 27m, 12339, 1.67m, 34, 27.85m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.8m, 11, 28.28m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0m, 27m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0.05m, 27m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.83m, 37m, 4992, 1.56m, 777, 56.42m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.8m, 42m, 4788, 820, 62.5m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 42m, 0, 0m, 801, 62.03m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.77m, 38m, 22647, 3.95m, 830, 58.75m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.9m, 42m, 17426, 0.56m, 764, 61.1m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 4.26m, 0, 31m, new DateTime(2026, 9, 7, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.61m, 30m, 15646, 0m, 23, 30.58m, new DateTime(2026, 9, 7, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.77m, 4628, 0m, 21, 28.52m, new DateTime(2026, 9, 7, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 0, 32m, new DateTime(2026, 9, 7, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.98m, 29m, 17854, 3.15m, 38, 29.95m, new DateTime(2026, 9, 7, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 0m, 20m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 22m, 0, 3.87m, 22m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.74m, 21m, 22446, 0m, 21m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 22m, 0, 21, 22.52m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.48m, 21m, 14890, 4.97m, 39, 21.98m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.47m, 41, 28.02m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 0m, 28m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.58m, 9465, 0m, 6, 31.15m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.41m, 29m, 2443, 19, 29.48m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 0m, 0, 2.93m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.63m, 42m, 21767, 0m, 791, 61.78m, new DateTime(2026, 9, 8, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 773, 57.32m, new DateTime(2026, 9, 8, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 4.43m, 833, 62.82m, new DateTime(2026, 9, 8, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.29m, 42m, 13733, 3.87m, 768, 61.2m, new DateTime(2026, 9, 8, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.19m, 39m, 13123, 763, 58.08m, new DateTime(2026, 9, 8, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.06m, 18383, 42, 31.05m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.89m, 31m, 11359, 0.89m, 0, 31m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 3.35m, 0, 31m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 4.99m, 27m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 6, 27.15m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 17m, new DateTime(2026, 9, 9, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 3.3m, 19m, new DateTime(2026, 9, 9, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 1.3m, 0, 21m, new DateTime(2026, 9, 9, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.69m, 19m, 16151, 0.84m, 49, 20.23m, new DateTime(2026, 9, 9, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 0m, 20m, new DateTime(2026, 9, 9, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.31m, 1848, 0m, 3, 31.08m, new DateTime(2026, 9, 9, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 4.9m, 44, 29.1m, new DateTime(2026, 9, 9, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 0m, 6, 29.15m, new DateTime(2026, 9, 9, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 4.45m, 0, 27m, new DateTime(2026, 9, 9, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.01m, 32m, 53, 0, 32m, new DateTime(2026, 9, 9, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.82m, 37m, 4899, 0.33m, 846, 58.15m, new DateTime(2026, 9, 9, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.11m, 41m, 12689, 0m, 781, 60.53m, new DateTime(2026, 9, 9, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 0m, 811, 60.28m, new DateTime(2026, 9, 9, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.86m, 42m, 23135, 4.16m, 755, 60.88m, new DateTime(2026, 9, 9, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.17m, 38m, 19020, 835, 58.88m, new DateTime(2026, 9, 9, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.81m, 30m, 4840, 2.16m, 30m, new DateTime(2026, 9, 9, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.25m, 30m, 19499, 4.72m, 24, 30.6m, new DateTime(2026, 9, 9, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.75m, 30m, 10506, 0m, 44, 31.1m, new DateTime(2026, 9, 9, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.73m, 27m, 4387, 0.29m, 0, 27m, new DateTime(2026, 9, 9, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.13m, 32m, 769, 1.03m, 0, 32m, new DateTime(2026, 9, 9, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 2.08m, 33, 19.82m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 0, 19m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 0m, 14, 18.35m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 36, 21.9m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.82m, 22m, 16895, 1.5m, 38, 22.95m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 0m, 0, 31m, new DateTime(2026, 9, 10, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 1.75m, 40, 28m, new DateTime(2026, 9, 10, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 44, 28.1m, new DateTime(2026, 9, 10, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.46m, 28m, 20768, 4.72m, 38, 28.95m, new DateTime(2026, 9, 10, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 27m, new DateTime(2026, 9, 10, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.7m, 37m, 4196, 2.93m, 822, 57.55m, new DateTime(2026, 9, 10, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.36m, 41m, 2152, 782, 60.55m, new DateTime(2026, 9, 10, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.49m, 40m, 2916, 3.84m, 770, 59.25m, new DateTime(2026, 9, 10, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 41m, 813, 61.32m, new DateTime(2026, 9, 10, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 40m, 0.81m, 820, 60.5m, new DateTime(2026, 9, 10, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0m, 48, 28.2m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 27, 29.68m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.13m, 31m, 18783, 1.26m, 0, 31m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0, 27m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 0m, 28, 31.7m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });
        }
    }
}
