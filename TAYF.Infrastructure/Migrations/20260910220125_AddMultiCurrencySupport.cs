using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiCurrencySupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnergyLossKwh",
                table: "Alert");

            migrationBuilder.RenameColumn(
                name: "RateEgpPerKwh",
                table: "Tariffs",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "TariffRateEgpPerKwh",
                table: "Plants",
                newName: "TariffRate");

            migrationBuilder.RenameColumn(
                name: "EstimatedLossEgp",
                table: "AnalysisResults",
                newName: "EstimatedLoss");

            migrationBuilder.RenameColumn(
                name: "FinancialLossEgp",
                table: "Alert",
                newName: "FinancialLoss");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Tariffs",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "AnalysisResults",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Alert",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1,
                column: "Currency",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Currency",
                value: 1);

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 2.57m, 15446, 3.03m, new DateTime(2026, 9, 3, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.34m, 0, 17m, new DateTime(2026, 9, 3, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 0m, 0, 17m, new DateTime(2026, 9, 3, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 0m, 31m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0.65m, 27m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 40, 33m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 0m, 0, 30m, new DateTime(2026, 9, 4, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 39m, 0, 1.17m, 814, 59.35m, new DateTime(2026, 9, 4, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 0m, 839, 62.98m, new DateTime(2026, 9, 4, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.76m, 29m, 16552, 0m, 5, 29.12m, new DateTime(2026, 9, 4, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.85m, 30m, 11123, 2.71m, 19, 30.48m, new DateTime(2026, 9, 4, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 2.99m, 19, 27.48m, new DateTime(2026, 9, 4, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.42m, 19m, 20543, 0m, 8, 19.2m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.29m, 7730, 0, 18m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 0m, 0, 19m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 3.28m, 19682, 0m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 18m, new DateTime(2026, 9, 4, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.62m, 47, 28.18m, new DateTime(2026, 9, 5, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.64m, 32m, 9848, 0m, 0, 32m, new DateTime(2026, 9, 5, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.69m, 31m, 22143, 32, 31.8m, new DateTime(2026, 9, 5, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.91m, 40m, 17478, 0.81m, 838, 60.95m, new DateTime(2026, 9, 5, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.29m, 42m, 1747, 0m, 756, 60.9m, new DateTime(2026, 9, 5, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.12m, 797, 57.92m, new DateTime(2026, 9, 5, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 4.09m, 16, 32.4m, new DateTime(2026, 9, 5, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 0m, 0, 28m, new DateTime(2026, 9, 5, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 1.86m, 27m, new DateTime(2026, 9, 5, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.93m, 20m, 23566, 20.72m, new DateTime(2026, 9, 5, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.19m, 19m, 1135, 0.33m, 0, 19m, new DateTime(2026, 9, 5, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 37, 19.92m, new DateTime(2026, 9, 5, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0, 32m, new DateTime(2026, 9, 6, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 40, 30m, new DateTime(2026, 9, 6, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 0.44m, 0, 28m, new DateTime(2026, 9, 6, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 816, 62.4m, new DateTime(2026, 9, 6, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.84m, 38m, 11061, 0.26m, 779, 57.48m, new DateTime(2026, 9, 6, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.84m, 29m, 23060, 4, 29.1m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 1.51m, 40, 31m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 0, 32m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.84m, 28m, 17048, 35, 28.88m, new DateTime(2026, 9, 6, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 18m, 0, 11, 18.27m, new DateTime(2026, 9, 6, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 0m, 0, 0m, new DateTime(2026, 9, 6, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.7m, 18m, 10199, 18m, new DateTime(2026, 9, 6, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.83m, 22958, 0m, 0, 27m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0, 28m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.47m, 28m, 2802, 18, 28.45m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.71m, 16286, 2, 28.05m, new DateTime(2026, 9, 7, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 0.94m, 820, 57.5m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 756, 58.9m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.13m, 42m, 6784, 780, 61.5m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 38m, 0, 842, 59.05m, new DateTime(2026, 9, 7, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 5, 31.12m, new DateTime(2026, 9, 7, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 1.34m, 33, 31.82m, new DateTime(2026, 9, 7, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.89m, 22m, 5312, 0m, 0, 22m, new DateTime(2026, 9, 7, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 21m, 0, 3.31m, 0, 21m, new DateTime(2026, 9, 7, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.06m, 21m, 363, 0m, 38, 21.95m, new DateTime(2026, 9, 7, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.98m, 11850, 0m, 20, 29.5m, new DateTime(2026, 9, 8, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.76m, 31m, 16548, 0m, 0, 31m, new DateTime(2026, 9, 8, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 1.44m, 844, 63.1m, new DateTime(2026, 9, 8, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 42m, 0, 826, 62.65m, new DateTime(2026, 9, 8, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 0m, 41, 31.02m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.04m, 0, 32m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0.38m, 0, 27m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 46, 32.15m, new DateTime(2026, 9, 8, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.2m, 19201, 0.24m, 41, 20.02m, new DateTime(2026, 9, 8, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 0m, 30, 20.75m, new DateTime(2026, 9, 8, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 0.14m, 0, 18m, new DateTime(2026, 9, 8, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.68m, 32m, 22102, 1.7m, 32m, new DateTime(2026, 9, 9, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "Timestamp" },
                values: new object[] { 0.64m, 3844, new DateTime(2026, 9, 9, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.49m, 14948, 0.38m, 42, 33.05m, new DateTime(2026, 9, 9, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.52m, 39m, 15122, 823, 59.58m, new DateTime(2026, 9, 9, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 40m, 4.69m, 766, 59.15m, new DateTime(2026, 9, 9, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.6m, 9594, 766, 61.15m, new DateTime(2026, 9, 9, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 2.91m, 0, 29m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 32m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.07m, 12434, 1.54m, 25, 31.62m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.88m, 29m, 11291, 0m, 19, 29.48m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 0m, 0, 32m, new DateTime(2026, 9, 9, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 2.44m, 41, 19.02m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 20m, 0, 3.14m, 20m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 0m, 0, 18m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.57m, 18m, 3405, 0.14m, 10, 18.25m, new DateTime(2026, 9, 9, 22, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 29m, 0, 1.19m, 0, 29m, new DateTime(2026, 9, 10, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 2.81m, 28, 29.7m, new DateTime(2026, 9, 10, 4, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 1.65m, 826, 62.65m, new DateTime(2026, 9, 10, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

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
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.05m, 833, 61.82m, new DateTime(2026, 9, 10, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 41m, 0, 2.03m, 802, 61.05m, new DateTime(2026, 9, 10, 10, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.37m, 27m, 2198, 0, 27m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 26, 32.65m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 27m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 32m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 29m, new DateTime(2026, 9, 10, 16, 1, 24, 678, DateTimeKind.Utc).AddTicks(9896) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "AnalysisResults");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Alert");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Tariffs",
                newName: "RateEgpPerKwh");

            migrationBuilder.RenameColumn(
                name: "TariffRate",
                table: "Plants",
                newName: "TariffRateEgpPerKwh");

            migrationBuilder.RenameColumn(
                name: "EstimatedLoss",
                table: "AnalysisResults",
                newName: "EstimatedLossEgp");

            migrationBuilder.RenameColumn(
                name: "FinancialLoss",
                table: "Alert",
                newName: "FinancialLossEgp");

            migrationBuilder.AddColumn<decimal>(
                name: "EnergyLossKwh",
                table: "Alert",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 0m, 40, 18m, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 0m, 0, 0m, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.94m, 25, 17.62m, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.37m, 19m, 20191, 3.08m, 14, 19.35m, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.62m, 20m, 3706, 1.78m, 28, 20.7m, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 3.15m, 30m, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.7m, 29m, 22185, 0m, 29m, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 27m, 0, 27m, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.08m, 27m, 18471, 0.84m, 27, 27.68m, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 2.82m, 0, 30m, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.23m, 41m, 1366, 0m, 804, 61.1m, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 37m, 3m, 849, 58.22m, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 41m, 0, 0m, 826, 61.65m, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 0m, 773, 59.32m, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.98m, 42m, 11883, 1.42m, 834, 62.85m, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 4.63m, 41, 28.02m, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.68m, 28m, 22091, 0m, 44, 29.1m, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 4.99m, 0, 28m, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 2.17m, 0, 31m, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.82m, 29m, 16940, 0m, 0, 29m, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.16m, 20m, 981, 3.53m, 23, 20.58m, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 42, 19.05m, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 2.4m, 11, 18.27m, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 0m, 0, 4.01m, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 22m, 22m, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 3.77m, 43, 32.08m, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.66m, 0, 27m, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 0.63m, 37, 28.92m, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 3, 30.08m, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.15m, 30m, 12902, 0m, 47, 31.18m, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.63m, 37m, 21773, 834, 57.85m, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 0m, 778, 56.45m, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.63m, 9791, 1.28m, 817, 60.42m, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 2.05m, 762, 56.05m, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 786, 57.65m, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 0m, 11, 30.28m, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.73m, 31m, 22381, 1.19m, 26, 31.65m, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.47m, 31m, 20794, 3.48m, 31m, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 2.94m, 31m, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 3.86m, 31m, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 19m, 0, 19.73m, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.02m, 21m, 18113, 0m, 26, 21.65m, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 18m, 0, 1.8m, 0, 18m, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 22m, 0, 22m, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.65m, 22m, 15920, 0m, 3, 22.08m, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.55m, 30m, 15320, 17, 30.42m, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.83m, 11002, 3.18m, 0, 27m, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 41, 31.02m, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.22m, 28m, 19294, 4.85m, 36, 28.9m, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.85m, 29m, 11128, 1.71m, 30, 29.75m, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.52m, 41m, 21114, 843, 62.08m, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 41m, 822, 61.55m, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 41m, 0, 1.46m, 793, 60.82m, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 37m, 0, 1.37m, 752, 55.8m, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.85m, 41m, 5123, 1.46m, 793, 60.82m, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 30m, 0, 0, 30m, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.47m, 2823, 3.32m, 14, 30.35m, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.38m, 28m, 20298, 3.61m, 21, 28.52m, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.36m, 31m, 2154, 3.05m, 29, 31.72m, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 0, 31m, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.53m, 19m, 15156, 0m, 46, 20.15m, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.54m, 22m, 15269, 0m, 0, 22m, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.13m, 19m, 756, 0, 19m, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Timestamp" },
                values: new object[] { 3.8m, 22827, 3.1m, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.14m, 22m, 822, 22m, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.02m, 29m, 12125, 0m, 44, 30.1m, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 1.79m, 9, 27.22m, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19, 28.48m, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.5m, 31m, 9011, 8, 31.2m, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.17m, 7032, 0, 28m, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.25m, 42m, 7497, 1.97m, 767, 61.18m, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 1.88m, 830, 62.75m, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.46m, 37m, 20742, 794, 56.85m, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.16m, 41m, 12939, 817, 61.42m, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.59m, 40m, 3537, 834, 60.85m, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20, 31.5m, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.09m, 27m, 12516, 0m, 27, 27.68m, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 0.16m, 0, 30m, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.38m, 29m, 2285, 0m, 0, 29m, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.42m, 31m, 8493, 2.45m, 0, 31m, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.69m, 18m, 22114, 1.34m, 17, 18.42m, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.01m, 20m, 12061, 11, 20.27m, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 20m, 0, 3.02m, 20m, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.33m, 19m, 13965, 2.82m, 44, 20.1m, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.93m, 18m, 11597, 2.43m, 0, 18m, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0m, 27m, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.03m, 202, 1.5m, 0, 29m, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 28m, 0, 1.98m, 44, 29.1m, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 0m, 9, 31.22m, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 2.3m, 49, 28.22m, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 42m, 0, 3.9m, 841, 63.03m, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 37m, 3.21m, 774, 56.35m, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.94m, 37m, 17647, 796, 56.9m, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 42m, 787, 61.68m, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.78m, 38m, 10682, 0m, 820, 58.5m, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 28m, 1.72m, 43, 29.08m, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 4.8m, 48, 33.2m, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 1.58m, 27, 31.68m, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 27m, 0, 0m, 0, 27m, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "AmbientTemperature", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 29m, 48, 30.2m, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.06m, 18384, 3.83m, 23, 19.58m, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 18m, 1.67m, 20, 18.5m, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 19m, 0m, 14, 19.35m, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 22m, 22m, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.46m, 19m, 2780, 0m, 0, 19m, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.21m, 31m, 13256, 0m, 31m, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.15m, 30m, 12877, 0m, 0, 30m, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.98m, 27m, 17867, 3.86m, 0, 27m, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "AcPowerKw", "DailyYield", "Timestamp" },
                values: new object[] { 1.84m, 11058, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.69m, 22111, 4.11m, 49, 33.22m, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 40m, 0, 754, 58.85m, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 41m, 0m, 753, 59.82m, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.73m, 42m, 16366, 2.11m, 837, 62.92m, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.51m, 40m, 9081, 3.9m, 840, 61m, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "AcPowerKw", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 0, 775, 61.38m, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 30m, 3.98m, 36, 30.9m, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.53m, 28m, 9183, 0.28m, 28m, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.05m, 6321, 1.87m, 10, 31.25m, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 32m, 0, 4.6m, 46, 33.15m, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.4m, 29m, 8411, 1.6m, 10, 29.25m, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 17m, 0m, 0, 17m, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.31m, 21m, 19872, 2.41m, 21m, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.77m, 18m, 4607, 3.38m, 0, 18m, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 20m, 4.03m, 30, 20.75m, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 17m, 0, 2.71m, 45, 18.12m, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.41m, 28m, 14458, 1.82m, 28, 28.7m, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "AmbientTemperature", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 0.55m, 33, 32.83m, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.6m, 27m, 9623, 0m, 0, 27m, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.83m, 32m, 5001, 0m, 29, 32.72m, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.1m, 30m, 12572, 1.13m, 0, 30m, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "AcPowerKw", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.01m, 6072, 2.57m, 764, 61.1m, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.76m, 40m, 16579, 1.72m, 827, 60.68m, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 759, 58.98m, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0.74m, 751, 59.78m, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 1.9m, 38m, 11415, 0.08m, 770, 57.25m, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 0m, 31m, 0, 3, 31.08m, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "Irradiance", "ModuleTemperature", "Timestamp" },
                values: new object[] { 3.51m, 30m, 21063, 34, 30.85m, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 32m, 32m, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "AcPowerKw", "AmbientTemperature", "DailyYield", "ModuleTemperature", "Timestamp" },
                values: new object[] { 2.38m, 30m, 14283, 30m, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "AmbientTemperature", "ModuleTemperature", "Timestamp" },
                values: new object[] { 31m, 31m, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082) });
        }
    }
}
