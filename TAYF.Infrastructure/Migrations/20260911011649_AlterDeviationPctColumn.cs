using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterDeviationPctColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alert_Inverters_InverterId",
                table: "Alert");

            migrationBuilder.DropForeignKey(
                name: "FK_Alert_Plants_PlantId",
                table: "Alert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alert",
                table: "Alert");

            migrationBuilder.RenameTable(
                name: "Alert",
                newName: "Alerts");

            migrationBuilder.RenameIndex(
                name: "IX_Alert_PlantId",
                table: "Alerts",
                newName: "IX_Alerts_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Alert_InverterId",
                table: "Alerts",
                newName: "IX_Alerts_InverterId");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeviationPct",
                table: "AnalysisResults",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts",
                column: "Id");

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.79m, 22756, 2.54m, 25, 17.62m, new DateTime(2026, 9, 4, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.54m, 20m, 21232, 0, 20m, new DateTime(2026, 9, 4, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 1.46m, 17m, new DateTime(2026, 9, 4, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.02m, 32m, 12109, 4.99m, 32m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.54m, 30m, 15228, 0m, 0, 30m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 0.4m, 31, 32.78m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.01m, 30m, 18076, 0m, 0, 30m, new DateTime(2026, 9, 4, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.52m, 770, 56.25m, new DateTime(2026, 9, 4, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 32m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.73m, 16357, 0, 27m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.11m, 28m, 12647, 28m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 4.39m, 5, 30.12m, new DateTime(2026, 9, 4, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.71m, 21m, 16269, 1.43m, 21m, new DateTime(2026, 9, 5, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.22m, 20m, 1307, 20m, new DateTime(2026, 9, 5, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.42m, 17m, 14549, 0m, 39, 17.98m, new DateTime(2026, 9, 5, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.13m, 29m, 6804, 0m, 32, 29.8m, new DateTime(2026, 9, 5, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 0.12m, 838, 58.95m, new DateTime(2026, 9, 5, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.68m, 16085, 1.14m, 799, 59.98m, new DateTime(2026, 9, 5, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.44m, 41m, 20669, 0m, 846, 62.15m, new DateTime(2026, 9, 5, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 31m, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 2.99m, 30m, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 0m, 30m, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 28, 32.7m, new DateTime(2026, 9, 5, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 21m, new DateTime(2026, 9, 6, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.14m, 32m, 6832, 3.68m, 0, 32m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 3.94m, 0, 32m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0m, 27m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.24m, 29m, 7426, 23, 29.58m, new DateTime(2026, 9, 6, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 755, 58.88m, new DateTime(2026, 9, 6, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 49, 33.22m, new DateTime(2026, 9, 6, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 0m, 42, 29.05m, new DateTime(2026, 9, 6, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.46m, 19m, 8789, 0m, 36, 19.9m, new DateTime(2026, 9, 7, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 0m, 46, 22.15m, new DateTime(2026, 9, 7, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 0m, 0, 20m, new DateTime(2026, 9, 7, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.31m, 7841, 0m, 0, 31m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 2.8m, 11, 28.28m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0m, 0, 27m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0.05m, 0, 27m, new DateTime(2026, 9, 7, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.83m, 4992, 1.56m, 777, 56.42m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.8m, 42m, 4788, 0m, 820, 62.5m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 801, 62.03m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.77m, 22647, 3.95m, 830, 58.75m, new DateTime(2026, 9, 7, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 4.26m, 31m, new DateTime(2026, 9, 7, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.77m, 28m, 4628, 21, 28.52m, new DateTime(2026, 9, 7, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 0m, 0, 32m, new DateTime(2026, 9, 7, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 20m, 0, 0m, 20m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 22m, 0, 3.87m, 0, 22m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.74m, 21m, 22446, 21m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 22m, 0m, 21, 22.52m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.48m, 14890, 4.97m, 39, 21.98m, new DateTime(2026, 9, 8, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 0.47m, 41, 28.02m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 28m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.58m, 31m, 9465, 0m, 6, 31.15m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.41m, 29m, 2443, 0m, 19, 29.48m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 2.93m, 30m, new DateTime(2026, 9, 8, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 0m, 773, 57.32m, new DateTime(2026, 9, 8, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 4.43m, 833, 62.82m, new DateTime(2026, 9, 8, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.19m, 39m, 13123, 0m, 763, 58.08m, new DateTime(2026, 9, 8, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.06m, 30m, 18383, 42, 31.05m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.89m, 31m, 11359, 0.89m, 31m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 3.35m, 31m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 4.99m, 27m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 6, 27.15m, new DateTime(2026, 9, 8, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 0, 17m, new DateTime(2026, 9, 9, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 1.3m, 21m, new DateTime(2026, 9, 9, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 20m, 0, 0m, 0, 20m, new DateTime(2026, 9, 9, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 4.9m, 44, 29.1m, new DateTime(2026, 9, 9, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 4.45m, 0, 27m, new DateTime(2026, 9, 9, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.01m, 32m, 53, 0m, 0, 32m, new DateTime(2026, 9, 9, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.11m, 41m, 12689, 781, 60.53m, new DateTime(2026, 9, 9, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 811, 60.28m, new DateTime(2026, 9, 9, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.17m, 38m, 19020, 0m, 835, 58.88m, new DateTime(2026, 9, 9, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.25m, 19499, 4.72m, 24, 30.6m, new DateTime(2026, 9, 9, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.75m, 30m, 10506, 44, 31.1m, new DateTime(2026, 9, 9, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 2.08m, 33, 19.82m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 0m, 0, 19m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 14, 18.35m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 36, 21.9m, new DateTime(2026, 9, 10, 1, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "DcPowerKw", "Timestamp" },
                values: new object[] { 0m, new DateTime(2026, 9, 10, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 27m, new DateTime(2026, 9, 10, 7, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.49m, 2916, 3.84m, 770, 59.25m, new DateTime(2026, 9, 10, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 41m, 0m, 813, 61.32m, new DateTime(2026, 9, 10, 13, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

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
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 48, 28.2m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 27, 29.68m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.13m, 31m, 18783, 1.26m, 31m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 27m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 28, 31.7m, new DateTime(2026, 9, 10, 19, 16, 49, 251, DateTimeKind.Utc).AddTicks(6986) });

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Inverters_InverterId",
                table: "Alerts",
                column: "InverterId",
                principalTable: "Inverters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Plants_PlantId",
                table: "Alerts",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Inverters_InverterId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Plants_PlantId",
                table: "Alerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts");

            migrationBuilder.RenameTable(
                name: "Alerts",
                newName: "Alert");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_PlantId",
                table: "Alert",
                newName: "IX_Alert_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_InverterId",
                table: "Alert",
                newName: "IX_Alert_InverterId");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeviationPct",
                table: "AnalysisResults",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alert",
                table: "Alert",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 0m, 32, 19.8m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 0.08m, 0, 17m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.49m, 19m, 8912, 1, 19.02m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.16m, 19m, 18956, 3.22m, 19m, new DateTime(2026, 9, 3, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.5m, 27m, 21013, 0m, 27m, new DateTime(2026, 9, 4, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.19m, 7154, 3.81m, 0, 32m, new DateTime(2026, 9, 4, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 1.77m, 28, 32.7m, new DateTime(2026, 9, 4, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 750, 55.75m, new DateTime(2026, 9, 4, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 42m, 0, 0.92m, 767, 61.18m, new DateTime(2026, 9, 4, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 38m, 777, 57.42m, new DateTime(2026, 9, 4, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 32m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.95m, 30m, 5719, 30m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.81m, 16845, 44, 28.1m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.24m, 31m, 19427, 31m, new DateTime(2026, 9, 4, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 0m, 0, 21m, new DateTime(2026, 9, 4, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.45m, 0, 19m, new DateTime(2026, 9, 4, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 2.09m, 43, 20.08m, new DateTime(2026, 9, 4, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 3.46m, 0, 27m, new DateTime(2026, 9, 5, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "Timestamp" },
                values: new object[] { 3.67m, 30m, 21995, 3.89m, 0, new DateTime(2026, 9, 5, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 4.13m, 0, 31m, new DateTime(2026, 9, 5, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 0m, 841, 63.03m, new DateTime(2026, 9, 5, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.32m, 40m, 13944, 2.68m, 847, 61.18m, new DateTime(2026, 9, 5, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.01m, 39m, 12061, 4.34m, 756, 57.9m, new DateTime(2026, 9, 5, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.96m, 29m, 11737, 1.43m, 29m, new DateTime(2026, 9, 5, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.7m, 5, 31.12m, new DateTime(2026, 9, 5, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.76m, 29m, 4537, 0.28m, 0, 29m, new DateTime(2026, 9, 5, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.81m, 18m, 4877, 0m, 0, 18m, new DateTime(2026, 9, 5, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.47m, 19m, 20831, 19m, new DateTime(2026, 9, 5, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.69m, 18m, 10145, 18m, new DateTime(2026, 9, 5, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 0m, 24, 28.6m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 4.89m, 16, 27.4m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.63m, 32m, 9761, 3.55m, 32m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 35, 31.88m, new DateTime(2026, 9, 6, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 1.34m, 832, 58.8m, new DateTime(2026, 9, 6, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 3.09m, 809, 58.22m, new DateTime(2026, 9, 6, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.82m, 29m, 16927, 2.84m, 0, 29m, new DateTime(2026, 9, 6, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.76m, 31m, 10555, 0.4m, 0, 31m, new DateTime(2026, 9, 6, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 2.45m, 29m, new DateTime(2026, 9, 6, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 21m, 38, 21.95m, new DateTime(2026, 9, 6, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 4.82m, 15, 31.38m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.1m, 31m, 6578, 3.47m, 0, 31m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 1.16m, 0, 27m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 3.35m, 7, 30.18m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 3.98m, 13, 32.33m, new DateTime(2026, 9, 7, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 4.08m, 763, 56.08m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 2.78m, 793, 57.82m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.94m, 11652, 4.18m, 793, 57.82m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 0m, 800, 57m, new DateTime(2026, 9, 7, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.11m, 28m, 12667, 1m, 28m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 3.27m, 15, 27.38m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0, 27m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 4.59m, 2, 31.05m, new DateTime(2026, 9, 7, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.43m, 19m, 2570, 0m, 37, 19.92m, new DateTime(2026, 9, 7, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.24m, 20m, 1414, 20m, new DateTime(2026, 9, 7, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 1.77m, 0, 20m, new DateTime(2026, 9, 7, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2m, 11988, 0m, 0, 27m, new DateTime(2026, 9, 8, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 27m, new DateTime(2026, 9, 8, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 3.03m, 5, 31.12m, new DateTime(2026, 9, 8, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 0m, 817, 58.42m, new DateTime(2026, 9, 8, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 0.31m, 30m, new DateTime(2026, 9, 8, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 0.55m, 29m, new DateTime(2026, 9, 8, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 25, 20.62m, new DateTime(2026, 9, 8, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 0m, 17m, new DateTime(2026, 9, 8, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 0m, 0, 17m, new DateTime(2026, 9, 8, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.79m, 10720, 0.69m, 22, 31.55m, new DateTime(2026, 9, 9, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.35m, 39m, 20075, 0m, 837, 59.92m, new DateTime(2026, 9, 9, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.88m, 38m, 23300, 845, 59.12m, new DateTime(2026, 9, 9, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.91m, 11462, 766, 59.15m, new DateTime(2026, 9, 9, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.95m, 23705, 3.56m, 48, 31.2m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 23, 29.58m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 0m, 1, 31.02m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.24m, 30m, 1460, 0m, 49, 31.22m, new DateTime(2026, 9, 9, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.68m, 28, 18.7m, new DateTime(2026, 9, 9, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 0.14m, 3, 19.08m, new DateTime(2026, 9, 9, 22, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "DcPowerKw", "Timestamp" },
                values: new object[] { 1.89m, new DateTime(2026, 9, 10, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.88m, 31m, 5261, 0, 31m, new DateTime(2026, 9, 10, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.15m, 45, 28.12m, new DateTime(2026, 9, 10, 4, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 0m, 824, 60.6m, new DateTime(2026, 9, 10, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 39m, 0, 780, 58.5m, new DateTime(2026, 9, 10, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 0m, 806, 60.15m, new DateTime(2026, 9, 10, 10, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 4, 27.1m, new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.01m, 32m, 6044, 0, 32m, new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

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
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 32m, new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 16, 28.4m, new DateTime(2026, 9, 10, 16, 19, 2, 776, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.AddForeignKey(
                name: "FK_Alert_Inverters_InverterId",
                table: "Alert",
                column: "InverterId",
                principalTable: "Inverters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alert_Plants_PlantId",
                table: "Alert",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
