using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTelemetryCheckpoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelemetryProcessingCheckpoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InverterId = table.Column<int>(type: "int", nullable: false),
                    LastProcessedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetryProcessingCheckpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelemetryProcessingCheckpoints_Inverters_InverterId",
                        column: x => x.InverterId,
                        principalTable: "Inverters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 0m, 32, 19.8m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 0.08m, 17m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.49m, 19m, 8912, 0m, 1, 19.02m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.16m, 19m, 18956, 3.22m, 0, 19m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.82m, 19m, 16930, 28, 19.7m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.79m, 29m, 22727, 49, 30.22m, new DateTime(2026, 9, 4, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 3.5m, 21013, 0m, new DateTime(2026, 9, 4, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.25m, 31m, 13524, 2.19m, 36, 31.9m, new DateTime(2026, 9, 4, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.19m, 32m, 7154, 3.81m, 32m, new DateTime(2026, 9, 4, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 1.77m, 28, 32.7m, new DateTime(2026, 9, 4, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 37m, 0m, 750, 55.75m, new DateTime(2026, 9, 4, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.92m, 767, 61.18m, new DateTime(2026, 9, 4, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 0m, 777, 57.42m, new DateTime(2026, 9, 4, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.52m, 41m, 15142, 0m, 823, 61.58m, new DateTime(2026, 9, 4, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.52m, 41m, 9131, 0m, 771, 60.28m, new DateTime(2026, 9, 4, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0, 32m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.95m, 5719, 0m, 0, 30m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.81m, 27m, 16845, 0m, 44, 28.1m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.24m, 31m, 19427, 0m, 0, 31m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.8m, 32m, 4783, 0m, 0, 32m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 0, 21m, new DateTime(2026, 9, 4, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 22m, 0, 0.5m, 22m, new DateTime(2026, 9, 4, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.02m, 18m, 12129, 18m, new DateTime(2026, 9, 4, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 0.45m, 19m, new DateTime(2026, 9, 4, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 2.09m, 43, 20.08m, new DateTime(2026, 9, 4, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 3.46m, 0, 27m, new DateTime(2026, 9, 5, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.67m, 30m, 21995, 3.89m, 0, 30m, new DateTime(2026, 9, 5, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 4.13m, 31m, new DateTime(2026, 9, 5, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.58m, 28m, 21453, 0.99m, 35, 28.88m, new DateTime(2026, 9, 5, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 4.24m, 0, 30m, new DateTime(2026, 9, 5, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 42m, 0, 841, 63.03m, new DateTime(2026, 9, 5, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.32m, 13944, 2.68m, 847, 61.18m, new DateTime(2026, 9, 5, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.58m, 3488, 0m, 759, 58.98m, new DateTime(2026, 9, 5, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.01m, 39m, 12061, 4.34m, 57.9m, new DateTime(2026, 9, 5, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 40m, 2.03m, 794, 59.85m, new DateTime(2026, 9, 5, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.96m, 29m, 11737, 1.43m, 0, 29m, new DateTime(2026, 9, 5, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 2.7m, 5, 31.12m, new DateTime(2026, 9, 5, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.86m, 28m, 5168, 3.32m, 28m, new DateTime(2026, 9, 5, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.15m, 29m, 12894, 3.81m, 29m, new DateTime(2026, 9, 5, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.76m, 29m, 4537, 0.28m, 29m, new DateTime(2026, 9, 5, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.81m, 18m, 4877, 0, 18m, new DateTime(2026, 9, 5, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.07m, 18m, 449, 3.15m, 18m, new DateTime(2026, 9, 5, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.47m, 19m, 20831, 0m, 0, 19m, new DateTime(2026, 9, 5, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.69m, 18m, 10145, 0, 18m, new DateTime(2026, 9, 5, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 0m, 22, 17.55m, new DateTime(2026, 9, 5, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 24, 28.6m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 4.89m, 16, 27.4m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.63m, 32m, 9761, 3.55m, 0, 32m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 4.19m, 49, 29.22m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 0m, 35, 31.88m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.99m, 38m, 5921, 845, 59.12m, new DateTime(2026, 9, 6, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 1.34m, 832, 58.8m, new DateTime(2026, 9, 6, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 42m, 0, 1.38m, 821, 62.53m, new DateTime(2026, 9, 6, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.94m, 39m, 17619, 1.07m, 809, 59.22m, new DateTime(2026, 9, 6, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 3.09m, 809, 58.22m, new DateTime(2026, 9, 6, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.82m, 16927, 2.84m, 0, 29m, new DateTime(2026, 9, 6, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 0m, 0, 32m, new DateTime(2026, 9, 6, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.08m, 29m, 453, 2.19m, 11, 29.28m, new DateTime(2026, 9, 6, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.76m, 31m, 10555, 0.4m, 31m, new DateTime(2026, 9, 6, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 2.45m, 0, 29m, new DateTime(2026, 9, 6, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 0m, 38, 21.95m, new DateTime(2026, 9, 6, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.08m, 21m, 18509, 2.79m, 0, 21m, new DateTime(2026, 9, 6, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.31m, 17m, 13846, 1.36m, 0, 17m, new DateTime(2026, 9, 6, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 3.98m, 10, 21.25m, new DateTime(2026, 9, 6, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 22m, 0, 3.26m, 22m, new DateTime(2026, 9, 6, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 4.82m, 15, 31.38m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.1m, 31m, 6578, 3.47m, 31m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 1.16m, 27m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 3.35m, 7, 30.18m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 3.98m, 13, 32.33m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 4.08m, 763, 56.08m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 2.78m, 793, 57.82m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 39m, 846, 60.15m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.94m, 38m, 11652, 4.18m, 793, 57.82m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 37m, 800, 57m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.11m, 28m, 12667, 1m, 0, 28m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 3.27m, 15, 27.38m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0m, 0, 27m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 4.59m, 2, 31.05m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 3.72m, 20, 31.5m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.97m, 19m, 23792, 2.47m, 19m, new DateTime(2026, 9, 7, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.43m, 19m, 2570, 37, 19.92m, new DateTime(2026, 9, 7, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.24m, 20m, 1414, 0m, 20m, new DateTime(2026, 9, 7, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 1.77m, 20m, new DateTime(2026, 9, 7, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.91m, 5438, 0.74m, 7, 21.18m, new DateTime(2026, 9, 7, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2m, 27m, 11988, 0m, 27m, new DateTime(2026, 9, 8, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0, 27m, new DateTime(2026, 9, 8, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 3.16m, 0, 28m, new DateTime(2026, 9, 8, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 3.03m, 5, 31.12m, new DateTime(2026, 9, 8, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.49m, 28m, 2915, 4.66m, 28m, new DateTime(2026, 9, 8, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 3.9m, 760, 57m, new DateTime(2026, 9, 8, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.62m, 39m, 15692, 3.54m, 812, 59.3m, new DateTime(2026, 9, 8, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 1.24m, 797, 57.92m, new DateTime(2026, 9, 8, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 817, 58.42m, new DateTime(2026, 9, 8, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.29m, 42m, 19768, 1.86m, 795, 61.88m, new DateTime(2026, 9, 8, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.58m, 31m, 3500, 0, 31m, new DateTime(2026, 9, 8, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 0.31m, 30m, new DateTime(2026, 9, 8, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 0m, 28m, new DateTime(2026, 9, 8, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 0.55m, 0, 29m, new DateTime(2026, 9, 8, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.8m, 30m, 10800, 0, 30m, new DateTime(2026, 9, 8, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 20m, 0, 0m, 25, 20.62m, new DateTime(2026, 9, 8, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 0, 17m, new DateTime(2026, 9, 8, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 0m, 19m, new DateTime(2026, 9, 8, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 17m, new DateTime(2026, 9, 8, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.65m, 21m, 15927, 2.94m, 2, 21.05m, new DateTime(2026, 9, 8, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.79m, 31m, 10720, 0.69m, 22, 31.55m, new DateTime(2026, 9, 9, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.41m, 32m, 20433, 3.37m, 3, 32.08m, new DateTime(2026, 9, 9, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.49m, 32m, 20952, 4.71m, 0, 32m, new DateTime(2026, 9, 9, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.1m, 29m, 6599, 4.64m, 18, 29.45m, new DateTime(2026, 9, 9, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.26m, 30m, 1555, 4.71m, 35, 30.88m, new DateTime(2026, 9, 9, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.35m, 20075, 837, 59.92m, new DateTime(2026, 9, 9, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.88m, 38m, 23300, 0m, 845, 59.12m, new DateTime(2026, 9, 9, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.91m, 40m, 11462, 0m, 766, 59.15m, new DateTime(2026, 9, 9, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 1.9m, 842, 61.05m, new DateTime(2026, 9, 9, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.17m, 41m, 13041, 3.65m, 779, 60.48m, new DateTime(2026, 9, 9, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.11m, 31m, 664, 0m, 31m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.95m, 30m, 23705, 3.56m, 48, 31.2m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 0m, 23, 29.58m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 1, 31.02m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.24m, 30m, 1460, 49, 31.22m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.33m, 17m, 7973, 1.65m, 0, 17m, new DateTime(2026, 9, 9, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.82m, 21m, 4914, 1.16m, 38, 21.95m, new DateTime(2026, 9, 9, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 18m, 0, 2.68m, 28, 18.7m, new DateTime(2026, 9, 9, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.32m, 19m, 7928, 17, 19.42m, new DateTime(2026, 9, 9, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 3, 19.08m, new DateTime(2026, 9, 9, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 1.89m, 31m, new DateTime(2026, 9, 10, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.67m, 30m, 10032, 1.96m, 0, 30m, new DateTime(2026, 9, 10, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.88m, 31m, 5261, 0m, 0, 31m, new DateTime(2026, 9, 10, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.6m, 32m, 9578, 0m, 33, 32.83m, new DateTime(2026, 9, 10, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 3.15m, 45, 28.12m, new DateTime(2026, 9, 10, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 40m, 0m, 824, 60.6m, new DateTime(2026, 9, 10, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 39m, 0, 0m, 780, 58.5m, new DateTime(2026, 9, 10, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 806, 60.15m, new DateTime(2026, 9, 10, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 40m, 3.53m, 831, 60.78m, new DateTime(2026, 9, 10, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 39m, 4.06m, 823, 59.58m, new DateTime(2026, 9, 10, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 4, 27.1m, new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.01m, 6044, 0, 32m, new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.67m, 32m, 9991, 3.43m, 32m, new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 139,
                column: "Timestamp",
                value: new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 16, 28.4m, new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.CreateIndex(
                name: "IX_TelemetryProcessingCheckpoints_InverterId",
                table: "TelemetryProcessingCheckpoints",
                column: "InverterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelemetryProcessingCheckpoints");

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 1.7m, 0, 21m, new DateTime(2026, 9, 3, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.57m, 18m, 15446, 3.03m, 18m, new DateTime(2026, 9, 3, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 3.34m, 0, 17m, new DateTime(2026, 9, 3, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 0m, 31, 21.78m, new DateTime(2026, 9, 3, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 0, 17m, new DateTime(2026, 9, 3, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 0, 31m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 0m, 0, 0.65m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 40, 33m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 0m, 30m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 0m, 36, 29.9m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 39m, 1.17m, 814, 59.35m, new DateTime(2026, 9, 4, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 839, 62.98m, new DateTime(2026, 9, 4, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.63m, 40m, 21773, 1.13m, 842, 61.05m, new DateTime(2026, 9, 4, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.97m, 38m, 23806, 2.24m, 780, 57.5m, new DateTime(2026, 9, 4, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.82m, 37m, 16891, 0.21m, 848, 58.2m, new DateTime(2026, 9, 4, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.76m, 29m, 16552, 5, 29.12m, new DateTime(2026, 9, 4, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.85m, 11123, 2.71m, 19, 30.48m, new DateTime(2026, 9, 4, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.89m, 31m, 23331, 0.49m, 34, 31.85m, new DateTime(2026, 9, 4, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 2.99m, 19, 27.48m, new DateTime(2026, 9, 4, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 4.92m, 29, 28.72m, new DateTime(2026, 9, 4, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.42m, 19m, 20543, 8, 19.2m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.29m, 18m, 7730, 0m, 18m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 19m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.28m, 20m, 19682, 0m, 20m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 0m, 0, 18m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 0.94m, 40, 30m, new DateTime(2026, 9, 5, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0.62m, 47, 28.18m, new DateTime(2026, 9, 5, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.64m, 32m, 9848, 0m, 32m, new DateTime(2026, 9, 5, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.69m, 31m, 22143, 0m, 32, 31.8m, new DateTime(2026, 9, 5, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.85m, 28m, 23095, 0.82m, 42, 29.05m, new DateTime(2026, 9, 5, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.12m, 41m, 6735, 808, 61.2m, new DateTime(2026, 9, 5, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.91m, 17478, 0.81m, 838, 60.95m, new DateTime(2026, 9, 5, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.32m, 7949, 0.7m, 765, 59.12m, new DateTime(2026, 9, 5, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.29m, 42m, 1747, 0m, 60.9m, new DateTime(2026, 9, 5, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 1.12m, 797, 57.92m, new DateTime(2026, 9, 5, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 4.09m, 16, 32.4m, new DateTime(2026, 9, 5, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 0m, 0, 28m, new DateTime(2026, 9, 5, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.86m, 29m, 17132, 1.67m, 29m, new DateTime(2026, 9, 5, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.04m, 28m, 18228, 0m, 28m, new DateTime(2026, 9, 5, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 1.86m, 27m, new DateTime(2026, 9, 5, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.93m, 20m, 23566, 29, 20.72m, new DateTime(2026, 9, 5, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.19m, 19m, 1135, 0.33m, 19m, new DateTime(2026, 9, 5, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.63m, 21m, 15804, 0.11m, 36, 21.9m, new DateTime(2026, 9, 5, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 37, 19.92m, new DateTime(2026, 9, 5, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.79m, 18m, 16751, 1.04m, 17, 18.42m, new DateTime(2026, 9, 5, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 0, 32m, new DateTime(2026, 9, 6, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.29m, 19745, 0.62m, 4, 27.1m, new DateTime(2026, 9, 6, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 0m, 40, 30m, new DateTime(2026, 9, 6, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.53m, 32m, 9160, 0m, 23, 32.58m, new DateTime(2026, 9, 6, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 0.44m, 0, 28m, new DateTime(2026, 9, 6, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 796, 59.9m, new DateTime(2026, 9, 6, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 0m, 816, 62.4m, new DateTime(2026, 9, 6, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.88m, 38m, 23285, 2.75m, 757, 56.92m, new DateTime(2026, 9, 6, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.4m, 41m, 2371, 1.94m, 801, 61.03m, new DateTime(2026, 9, 6, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.84m, 11061, 0.26m, 779, 57.48m, new DateTime(2026, 9, 6, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.84m, 23060, 0m, 4, 29.1m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 1.51m, 40, 31m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.45m, 27m, 2724, 0m, 0, 27m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 32m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.84m, 28m, 17048, 0m, 35, 28.88m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.11m, 18m, 18634, 4.35m, 0, 18m, new DateTime(2026, 9, 6, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 2.24m, 27, 19.68m, new DateTime(2026, 9, 6, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 18m, 0, 0m, 11, 18.27m, new DateTime(2026, 9, 6, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 22m, 0m, 0, 22m, new DateTime(2026, 9, 6, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.7m, 18m, 10199, 0m, 18m, new DateTime(2026, 9, 6, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.86m, 28m, 11176, 3.97m, 0, 28m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.83m, 27m, 22958, 0m, 27m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 0m, 28m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.47m, 28m, 2802, 0m, 18, 28.45m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.71m, 28m, 16286, 0m, 2, 28.05m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.94m, 820, 57.5m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 41m, 2.2m, 842, 62.05m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 40m, 756, 58.9m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.13m, 42m, 6784, 0m, 780, 61.5m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 842, 59.05m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 0m, 5, 31.12m, new DateTime(2026, 9, 7, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 1.34m, 33, 31.82m, new DateTime(2026, 9, 7, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 2.65m, 6, 29.15m, new DateTime(2026, 9, 7, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.11m, 30m, 674, 1.67m, 18, 30.45m, new DateTime(2026, 9, 7, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.63m, 29m, 21775, 1.09m, 23, 29.58m, new DateTime(2026, 9, 7, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.89m, 22m, 5312, 0m, 22m, new DateTime(2026, 9, 7, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.71m, 17m, 22264, 0, 17m, new DateTime(2026, 9, 7, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.75m, 22m, 4480, 4.93m, 22m, new DateTime(2026, 9, 7, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 3.31m, 21m, new DateTime(2026, 9, 7, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.06m, 363, 0m, 38, 21.95m, new DateTime(2026, 9, 7, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.5m, 28m, 14995, 2.48m, 28m, new DateTime(2026, 9, 8, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.98m, 29m, 11850, 20, 29.5m, new DateTime(2026, 9, 8, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.65m, 31m, 3870, 4.65m, 36, 31.9m, new DateTime(2026, 9, 8, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 1.92m, 23, 28.58m, new DateTime(2026, 9, 8, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.76m, 31m, 16548, 0m, 31m, new DateTime(2026, 9, 8, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.47m, 41m, 2842, 2.22m, 834, 61.85m, new DateTime(2026, 9, 8, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 42m, 0, 1.44m, 844, 63.1m, new DateTime(2026, 9, 8, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 0m, 826, 62.65m, new DateTime(2026, 9, 8, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 41m, 835, 61.88m, new DateTime(2026, 9, 8, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 39m, 0, 4.57m, 840, 60m, new DateTime(2026, 9, 8, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 41, 31.02m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 2.04m, 32m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0.38m, 27m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.82m, 32m, 16924, 4.11m, 41, 33.02m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 46, 32.15m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.2m, 19m, 19201, 0.24m, 41, 20.02m, new DateTime(2026, 9, 8, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 30, 20.75m, new DateTime(2026, 9, 8, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 0.14m, 18m, new DateTime(2026, 9, 8, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 20m, new DateTime(2026, 9, 8, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.53m, 18m, 15164, 4.68m, 44, 19.1m, new DateTime(2026, 9, 8, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.68m, 32m, 22102, 1.7m, 0, 32m, new DateTime(2026, 9, 9, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.22m, 27m, 1307, 2.9m, 23, 27.58m, new DateTime(2026, 9, 9, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 4.82m, 11, 29.28m, new DateTime(2026, 9, 9, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.64m, 30m, 3844, 0m, 0, 30m, new DateTime(2026, 9, 9, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.49m, 32m, 14948, 0.38m, 42, 33.05m, new DateTime(2026, 9, 9, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.52m, 15122, 823, 59.58m, new DateTime(2026, 9, 9, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 4.69m, 766, 59.15m, new DateTime(2026, 9, 9, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.67m, 41m, 4043, 2.4m, 753, 59.82m, new DateTime(2026, 9, 9, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.86m, 37m, 5178, 0m, 765, 56.12m, new DateTime(2026, 9, 9, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.6m, 42m, 9594, 0m, 766, 61.15m, new DateTime(2026, 9, 9, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 2.91m, 29m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 0, 32m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.07m, 31m, 12434, 1.54m, 25, 31.62m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.88m, 29m, 11291, 19, 29.48m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0, 32m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 18m, 0, 2.44m, 41, 19.02m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 20m, 0, 3.14m, 0, 20m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.86m, 22m, 11164, 0m, 8, 22.2m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 18m, 0, 0, 18m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.57m, 18m, 3405, 10, 18.25m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 1.19m, 29m, new DateTime(2026, 9, 10, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 2.81m, 28, 29.7m, new DateTime(2026, 9, 10, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.48m, 32m, 2899, 3.99m, 17, 32.42m, new DateTime(2026, 9, 10, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 2.47m, 0, 30m, new DateTime(2026, 9, 10, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.88m, 32m, 17271, 0m, 23, 32.58m, new DateTime(2026, 9, 10, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 1.65m, 826, 62.65m, new DateTime(2026, 9, 10, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.87m, 38m, 23191, 2.1m, 782, 57.55m, new DateTime(2026, 9, 10, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 772, 59.3m, new DateTime(2026, 9, 10, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 41m, 3.05m, 833, 61.82m, new DateTime(2026, 9, 10, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 41m, 2.03m, 802, 61.05m, new DateTime(2026, 9, 10, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.37m, 2198, 0, 27m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 26, 32.65m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0m, 27m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 139,
                column: "Timestamp",
                value: new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 0, 29m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });
        }
    }
}
