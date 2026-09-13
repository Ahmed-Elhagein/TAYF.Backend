using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForDemoAndTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PerformanceBefore",
                table: "RepairVerifications",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PerformanceAfter",
                table: "RepairVerifications",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.InsertData(
                table: "Alerts",
                columns: new[] { "Id", "CreatedAt", "Currency", "EnergyLossKwh", "FinancialLoss", "InverterId", "IsResolved", "PlantId", "Problem", "RecommendedAction", "RootCause", "Severity" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 2, 8, 0, 0, 0, DateTimeKind.Utc), 1, 320m, 4160m, 2, false, 1, "Underperformance detected", "Schedule cleaning", "Soiling", 2 },
                    { 2, new DateTime(2026, 9, 2, 9, 0, 0, 0, DateTimeKind.Utc), 1, 480m, 6240m, 3, false, 1, "Significant underperformance", "Inspect wiring and connections", "Electrical issue detected", 3 },
                    { 3, new DateTime(2026, 9, 2, 10, 0, 0, 0, DateTimeKind.Utc), 1, 640m, 8320m, 4, false, 1, "Critical inverter fault", "Replace inverter immediately", "Inverter failure imminent", 4 }
                });

            migrationBuilder.InsertData(
                table: "AnalysisResults",
                columns: new[] { "Id", "ActualEnergyKwh", "ActualPowerKw", "AnomalyScore", "CauseProbabilities", "ConfidenceScore", "CreatedAt", "Currency", "DeviationPct", "EnergyLossKwh", "EstimatedLoss", "ExpectedEnergyKwh", "ExpectedPowerKw", "InverterId", "IsAnomaly", "PlantId", "PrimaryCause", "Severity", "Timestamp" },
                values: new object[,]
                {
                    { 1, 288m, 82m, 0.15m, "{}", 0.9m, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, -3.5m, 12m, 156m, 300m, 85m, 1, false, 1, "Normal", 1, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 272m, 75m, 0.65m, "{\"Soiling\":0.7,\"Shading\":0.2,\"Degradation\":0.1}", 0.8m, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, -11.8m, 28m, 364m, 300m, 85m, 2, true, 1, "Soiling", 2, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 258m, 68m, 0.85m, "{\"Electrical Issue\":0.8,\"Shading\":0.15,\"Connection\":0.05}", 0.75m, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, -20.0m, 42m, 546m, 300m, 85m, 3, true, 1, "Electrical Issue", 3, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 270m, 60m, 0.92m, "{\"Inverter Fault\":0.85,\"Wiring\":0.1,\"Other\":0.05}", 0.88m, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, -25.0m, 50m, 650m, 320m, 80m, 4, true, 1, "Inverter Fault", 4, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 312m, 88m, 0.12m, "{}", 0.92m, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, -2.2m, 8m, 104m, 320m, 90m, 5, false, 1, "Normal", 1, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceActions",
                columns: new[] { "Id", "ActionType", "CompletedAt", "Description", "InverterId", "PlantId", "StartedAt" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2026, 8, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Inverter 1 repair - underperformance fix", 1, 1, new DateTime(2026, 8, 25, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, null, "Inverter 2 scheduled inspection", 2, 1, new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, new DateTime(2026, 9, 1, 11, 30, 0, 0, DateTimeKind.Utc), "Panel cleaning - inverter 3", 3, 1, new DateTime(2026, 9, 1, 7, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Telemetry",
                columns: new[] { "Id", "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "InverterId", "Irradiance", "ModuleTemperature", "PlantId", "Timestamp", "TotalYield" },
                values: new object[,]
                {
                    { 6, 10.5m, 21m, 105, 11.02m, 1, 210, 23.1m, 1, new DateTime(2026, 8, 28, 6, 0, 0, 0, DateTimeKind.Utc), 5000L },
                    { 7, 11.0m, 20m, 110, 11.55m, 2, 220, 22.2m, 1, new DateTime(2026, 8, 28, 6, 0, 0, 0, DateTimeKind.Utc), 10000L },
                    { 8, 11.5m, 21m, 115, 12.08m, 3, 230, 23.3m, 1, new DateTime(2026, 8, 28, 6, 0, 0, 0, DateTimeKind.Utc), 15000L },
                    { 9, 12.0m, 20m, 120, 12.60m, 4, 240, 22.4m, 1, new DateTime(2026, 8, 28, 6, 0, 0, 0, DateTimeKind.Utc), 20000L },
                    { 10, 12.5m, 21m, 125, 13.12m, 5, 250, 23.5m, 1, new DateTime(2026, 8, 28, 6, 0, 0, 0, DateTimeKind.Utc), 25000L },
                    { 11, 30.75m, 24m, 307, 32.29m, 1, 615, 30.15m, 1, new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Utc), 5000L },
                    { 12, 31.5m, 23m, 315, 33.08m, 2, 630, 29.3m, 1, new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Utc), 10000L },
                    { 13, 32.25m, 24m, 322, 33.86m, 3, 645, 30.45m, 1, new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Utc), 15000L },
                    { 14, 33.0m, 23m, 330, 34.65m, 4, 660, 29.6m, 1, new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Utc), 20000L },
                    { 15, 33.75m, 24m, 337, 35.44m, 5, 675, 30.75m, 1, new DateTime(2026, 8, 28, 9, 0, 0, 0, DateTimeKind.Utc), 25000L },
                    { 16, 42.75m, 27m, 427, 44.89m, 1, 855, 35.55m, 1, new DateTime(2026, 8, 28, 12, 0, 0, 0, DateTimeKind.Utc), 5000L },
                    { 17, 43.0m, 26m, 430, 45.15m, 2, 860, 34.6m, 1, new DateTime(2026, 8, 28, 12, 0, 0, 0, DateTimeKind.Utc), 10000L },
                    { 18, 43.25m, 27m, 432, 45.41m, 3, 865, 35.65m, 1, new DateTime(2026, 8, 28, 12, 0, 0, 0, DateTimeKind.Utc), 15000L },
                    { 19, 43.5m, 26m, 435, 45.68m, 4, 870, 34.7m, 1, new DateTime(2026, 8, 28, 12, 0, 0, 0, DateTimeKind.Utc), 20000L },
                    { 20, 43.75m, 27m, 437, 45.94m, 5, 875, 35.75m, 1, new DateTime(2026, 8, 28, 12, 0, 0, 0, DateTimeKind.Utc), 25000L },
                    { 21, 26.0m, 30m, 260, 27.30m, 1, 520, 35.2m, 1, new DateTime(2026, 8, 28, 15, 0, 0, 0, DateTimeKind.Utc), 5000L },
                    { 22, 27.0m, 29m, 270, 28.35m, 2, 540, 34.4m, 1, new DateTime(2026, 8, 28, 15, 0, 0, 0, DateTimeKind.Utc), 10000L },
                    { 23, 28.0m, 30m, 280, 29.40m, 3, 560, 35.6m, 1, new DateTime(2026, 8, 28, 15, 0, 0, 0, DateTimeKind.Utc), 15000L },
                    { 24, 29.0m, 29m, 290, 30.45m, 4, 580, 34.8m, 1, new DateTime(2026, 8, 28, 15, 0, 0, 0, DateTimeKind.Utc), 20000L },
                    { 25, 30m, 30m, 300, 31.50m, 5, 600, 36m, 1, new DateTime(2026, 8, 28, 15, 0, 0, 0, DateTimeKind.Utc), 25000L },
                    { 26, 10.5m, 21m, 105, 11.02m, 1, 210, 23.1m, 1, new DateTime(2026, 8, 29, 6, 0, 0, 0, DateTimeKind.Utc), 30000L },
                    { 27, 11.0m, 20m, 110, 11.55m, 2, 220, 22.2m, 1, new DateTime(2026, 8, 29, 6, 0, 0, 0, DateTimeKind.Utc), 35000L },
                    { 28, 11.5m, 21m, 115, 12.08m, 3, 230, 23.3m, 1, new DateTime(2026, 8, 29, 6, 0, 0, 0, DateTimeKind.Utc), 40000L },
                    { 29, 12.0m, 20m, 120, 12.60m, 4, 240, 22.4m, 1, new DateTime(2026, 8, 29, 6, 0, 0, 0, DateTimeKind.Utc), 45000L },
                    { 30, 12.5m, 21m, 125, 13.12m, 5, 250, 23.5m, 1, new DateTime(2026, 8, 29, 6, 0, 0, 0, DateTimeKind.Utc), 50000L },
                    { 31, 30.75m, 24m, 307, 32.29m, 1, 615, 30.15m, 1, new DateTime(2026, 8, 29, 9, 0, 0, 0, DateTimeKind.Utc), 30000L },
                    { 32, 31.5m, 23m, 315, 33.08m, 2, 630, 29.3m, 1, new DateTime(2026, 8, 29, 9, 0, 0, 0, DateTimeKind.Utc), 35000L },
                    { 33, 32.25m, 24m, 322, 33.86m, 3, 645, 30.45m, 1, new DateTime(2026, 8, 29, 9, 0, 0, 0, DateTimeKind.Utc), 40000L },
                    { 34, 33.0m, 23m, 330, 34.65m, 4, 660, 29.6m, 1, new DateTime(2026, 8, 29, 9, 0, 0, 0, DateTimeKind.Utc), 45000L },
                    { 35, 33.75m, 24m, 337, 35.44m, 5, 675, 30.75m, 1, new DateTime(2026, 8, 29, 9, 0, 0, 0, DateTimeKind.Utc), 50000L },
                    { 36, 42.75m, 27m, 427, 44.89m, 1, 855, 35.55m, 1, new DateTime(2026, 8, 29, 12, 0, 0, 0, DateTimeKind.Utc), 30000L },
                    { 37, 43.0m, 26m, 430, 45.15m, 2, 860, 34.6m, 1, new DateTime(2026, 8, 29, 12, 0, 0, 0, DateTimeKind.Utc), 35000L },
                    { 38, 43.25m, 27m, 432, 45.41m, 3, 865, 35.65m, 1, new DateTime(2026, 8, 29, 12, 0, 0, 0, DateTimeKind.Utc), 40000L },
                    { 39, 43.5m, 26m, 435, 45.68m, 4, 870, 34.7m, 1, new DateTime(2026, 8, 29, 12, 0, 0, 0, DateTimeKind.Utc), 45000L },
                    { 40, 43.75m, 27m, 437, 45.94m, 5, 875, 35.75m, 1, new DateTime(2026, 8, 29, 12, 0, 0, 0, DateTimeKind.Utc), 50000L },
                    { 41, 26.0m, 30m, 260, 27.30m, 1, 520, 35.2m, 1, new DateTime(2026, 8, 29, 15, 0, 0, 0, DateTimeKind.Utc), 30000L },
                    { 42, 27.0m, 29m, 270, 28.35m, 2, 540, 34.4m, 1, new DateTime(2026, 8, 29, 15, 0, 0, 0, DateTimeKind.Utc), 35000L },
                    { 43, 28.0m, 30m, 280, 29.40m, 3, 560, 35.6m, 1, new DateTime(2026, 8, 29, 15, 0, 0, 0, DateTimeKind.Utc), 40000L },
                    { 44, 29.0m, 29m, 290, 30.45m, 4, 580, 34.8m, 1, new DateTime(2026, 8, 29, 15, 0, 0, 0, DateTimeKind.Utc), 45000L },
                    { 45, 30m, 30m, 300, 31.50m, 5, 600, 36m, 1, new DateTime(2026, 8, 29, 15, 0, 0, 0, DateTimeKind.Utc), 50000L },
                    { 46, 10.5m, 21m, 105, 11.02m, 1, 210, 23.1m, 1, new DateTime(2026, 8, 30, 6, 0, 0, 0, DateTimeKind.Utc), 55000L },
                    { 47, 11.0m, 20m, 110, 11.55m, 2, 220, 22.2m, 1, new DateTime(2026, 8, 30, 6, 0, 0, 0, DateTimeKind.Utc), 60000L },
                    { 48, 11.5m, 21m, 115, 12.08m, 3, 230, 23.3m, 1, new DateTime(2026, 8, 30, 6, 0, 0, 0, DateTimeKind.Utc), 65000L },
                    { 49, 12.0m, 20m, 120, 12.60m, 4, 240, 22.4m, 1, new DateTime(2026, 8, 30, 6, 0, 0, 0, DateTimeKind.Utc), 70000L },
                    { 50, 12.5m, 21m, 125, 13.12m, 5, 250, 23.5m, 1, new DateTime(2026, 8, 30, 6, 0, 0, 0, DateTimeKind.Utc), 75000L },
                    { 51, 30.75m, 24m, 307, 32.29m, 1, 615, 30.15m, 1, new DateTime(2026, 8, 30, 9, 0, 0, 0, DateTimeKind.Utc), 55000L },
                    { 52, 31.5m, 23m, 315, 33.08m, 2, 630, 29.3m, 1, new DateTime(2026, 8, 30, 9, 0, 0, 0, DateTimeKind.Utc), 60000L },
                    { 53, 32.25m, 24m, 322, 33.86m, 3, 645, 30.45m, 1, new DateTime(2026, 8, 30, 9, 0, 0, 0, DateTimeKind.Utc), 65000L },
                    { 54, 33.0m, 23m, 330, 34.65m, 4, 660, 29.6m, 1, new DateTime(2026, 8, 30, 9, 0, 0, 0, DateTimeKind.Utc), 70000L },
                    { 55, 33.75m, 24m, 337, 35.44m, 5, 675, 30.75m, 1, new DateTime(2026, 8, 30, 9, 0, 0, 0, DateTimeKind.Utc), 75000L },
                    { 56, 42.75m, 27m, 427, 44.89m, 1, 855, 35.55m, 1, new DateTime(2026, 8, 30, 12, 0, 0, 0, DateTimeKind.Utc), 55000L },
                    { 57, 43.0m, 26m, 430, 45.15m, 2, 860, 34.6m, 1, new DateTime(2026, 8, 30, 12, 0, 0, 0, DateTimeKind.Utc), 60000L },
                    { 58, 43.25m, 27m, 432, 45.41m, 3, 865, 35.65m, 1, new DateTime(2026, 8, 30, 12, 0, 0, 0, DateTimeKind.Utc), 65000L },
                    { 59, 43.5m, 26m, 435, 45.68m, 4, 870, 34.7m, 1, new DateTime(2026, 8, 30, 12, 0, 0, 0, DateTimeKind.Utc), 70000L },
                    { 60, 43.75m, 27m, 437, 45.94m, 5, 875, 35.75m, 1, new DateTime(2026, 8, 30, 12, 0, 0, 0, DateTimeKind.Utc), 75000L },
                    { 61, 26.0m, 30m, 260, 27.30m, 1, 520, 35.2m, 1, new DateTime(2026, 8, 30, 15, 0, 0, 0, DateTimeKind.Utc), 55000L },
                    { 62, 27.0m, 29m, 270, 28.35m, 2, 540, 34.4m, 1, new DateTime(2026, 8, 30, 15, 0, 0, 0, DateTimeKind.Utc), 60000L },
                    { 63, 28.0m, 30m, 280, 29.40m, 3, 560, 35.6m, 1, new DateTime(2026, 8, 30, 15, 0, 0, 0, DateTimeKind.Utc), 65000L },
                    { 64, 29.0m, 29m, 290, 30.45m, 4, 580, 34.8m, 1, new DateTime(2026, 8, 30, 15, 0, 0, 0, DateTimeKind.Utc), 70000L },
                    { 65, 30m, 30m, 300, 31.50m, 5, 600, 36m, 1, new DateTime(2026, 8, 30, 15, 0, 0, 0, DateTimeKind.Utc), 75000L },
                    { 66, 10.5m, 21m, 105, 11.02m, 1, 210, 23.1m, 1, new DateTime(2026, 8, 31, 6, 0, 0, 0, DateTimeKind.Utc), 80000L },
                    { 67, 11.0m, 20m, 110, 11.55m, 2, 220, 22.2m, 1, new DateTime(2026, 8, 31, 6, 0, 0, 0, DateTimeKind.Utc), 85000L },
                    { 68, 11.5m, 21m, 115, 12.08m, 3, 230, 23.3m, 1, new DateTime(2026, 8, 31, 6, 0, 0, 0, DateTimeKind.Utc), 90000L },
                    { 69, 12.0m, 20m, 120, 12.60m, 4, 240, 22.4m, 1, new DateTime(2026, 8, 31, 6, 0, 0, 0, DateTimeKind.Utc), 95000L },
                    { 70, 12.5m, 21m, 125, 13.12m, 5, 250, 23.5m, 1, new DateTime(2026, 8, 31, 6, 0, 0, 0, DateTimeKind.Utc), 100000L },
                    { 71, 30.75m, 24m, 307, 32.29m, 1, 615, 30.15m, 1, new DateTime(2026, 8, 31, 9, 0, 0, 0, DateTimeKind.Utc), 80000L },
                    { 72, 31.5m, 23m, 315, 33.08m, 2, 630, 29.3m, 1, new DateTime(2026, 8, 31, 9, 0, 0, 0, DateTimeKind.Utc), 85000L },
                    { 73, 32.25m, 24m, 322, 33.86m, 3, 645, 30.45m, 1, new DateTime(2026, 8, 31, 9, 0, 0, 0, DateTimeKind.Utc), 90000L },
                    { 74, 33.0m, 23m, 330, 34.65m, 4, 660, 29.6m, 1, new DateTime(2026, 8, 31, 9, 0, 0, 0, DateTimeKind.Utc), 95000L },
                    { 75, 33.75m, 24m, 337, 35.44m, 5, 675, 30.75m, 1, new DateTime(2026, 8, 31, 9, 0, 0, 0, DateTimeKind.Utc), 100000L },
                    { 76, 42.75m, 27m, 427, 44.89m, 1, 855, 35.55m, 1, new DateTime(2026, 8, 31, 12, 0, 0, 0, DateTimeKind.Utc), 80000L },
                    { 77, 43.0m, 26m, 430, 45.15m, 2, 860, 34.6m, 1, new DateTime(2026, 8, 31, 12, 0, 0, 0, DateTimeKind.Utc), 85000L },
                    { 78, 43.25m, 27m, 432, 45.41m, 3, 865, 35.65m, 1, new DateTime(2026, 8, 31, 12, 0, 0, 0, DateTimeKind.Utc), 90000L },
                    { 79, 43.5m, 26m, 435, 45.68m, 4, 870, 34.7m, 1, new DateTime(2026, 8, 31, 12, 0, 0, 0, DateTimeKind.Utc), 95000L },
                    { 80, 43.75m, 27m, 437, 45.94m, 5, 875, 35.75m, 1, new DateTime(2026, 8, 31, 12, 0, 0, 0, DateTimeKind.Utc), 100000L },
                    { 81, 26.0m, 30m, 260, 27.30m, 1, 520, 35.2m, 1, new DateTime(2026, 8, 31, 15, 0, 0, 0, DateTimeKind.Utc), 80000L },
                    { 82, 27.0m, 29m, 270, 28.35m, 2, 540, 34.4m, 1, new DateTime(2026, 8, 31, 15, 0, 0, 0, DateTimeKind.Utc), 85000L },
                    { 83, 28.0m, 30m, 280, 29.40m, 3, 560, 35.6m, 1, new DateTime(2026, 8, 31, 15, 0, 0, 0, DateTimeKind.Utc), 90000L },
                    { 84, 29.0m, 29m, 290, 30.45m, 4, 580, 34.8m, 1, new DateTime(2026, 8, 31, 15, 0, 0, 0, DateTimeKind.Utc), 95000L },
                    { 85, 30m, 30m, 300, 31.50m, 5, 600, 36m, 1, new DateTime(2026, 8, 31, 15, 0, 0, 0, DateTimeKind.Utc), 100000L },
                    { 86, 10.5m, 21m, 105, 11.02m, 1, 210, 23.1m, 1, new DateTime(2026, 9, 1, 6, 0, 0, 0, DateTimeKind.Utc), 105000L },
                    { 87, 11.0m, 20m, 110, 11.55m, 2, 220, 22.2m, 1, new DateTime(2026, 9, 1, 6, 0, 0, 0, DateTimeKind.Utc), 110000L },
                    { 88, 11.5m, 21m, 115, 12.08m, 3, 230, 23.3m, 1, new DateTime(2026, 9, 1, 6, 0, 0, 0, DateTimeKind.Utc), 115000L },
                    { 89, 12.0m, 20m, 120, 12.60m, 4, 240, 22.4m, 1, new DateTime(2026, 9, 1, 6, 0, 0, 0, DateTimeKind.Utc), 120000L },
                    { 90, 12.5m, 21m, 125, 13.12m, 5, 250, 23.5m, 1, new DateTime(2026, 9, 1, 6, 0, 0, 0, DateTimeKind.Utc), 125000L },
                    { 91, 30.75m, 24m, 307, 32.29m, 1, 615, 30.15m, 1, new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Utc), 105000L },
                    { 92, 31.5m, 23m, 315, 33.08m, 2, 630, 29.3m, 1, new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Utc), 110000L },
                    { 93, 32.25m, 24m, 322, 33.86m, 3, 645, 30.45m, 1, new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Utc), 115000L },
                    { 94, 33.0m, 23m, 330, 34.65m, 4, 660, 29.6m, 1, new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Utc), 120000L },
                    { 95, 33.75m, 24m, 337, 35.44m, 5, 675, 30.75m, 1, new DateTime(2026, 9, 1, 9, 0, 0, 0, DateTimeKind.Utc), 125000L },
                    { 96, 42.75m, 27m, 427, 44.89m, 1, 855, 35.55m, 1, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 105000L },
                    { 97, 43.0m, 26m, 430, 45.15m, 2, 860, 34.6m, 1, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 110000L },
                    { 98, 43.25m, 27m, 432, 45.41m, 3, 865, 35.65m, 1, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 115000L },
                    { 99, 43.5m, 26m, 435, 45.68m, 4, 870, 34.7m, 1, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 120000L },
                    { 100, 43.75m, 27m, 437, 45.94m, 5, 875, 35.75m, 1, new DateTime(2026, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), 125000L },
                    { 101, 26.0m, 30m, 260, 27.30m, 1, 520, 35.2m, 1, new DateTime(2026, 9, 1, 15, 0, 0, 0, DateTimeKind.Utc), 105000L },
                    { 102, 27.0m, 29m, 270, 28.35m, 2, 540, 34.4m, 1, new DateTime(2026, 9, 1, 15, 0, 0, 0, DateTimeKind.Utc), 110000L },
                    { 103, 28.0m, 30m, 280, 29.40m, 3, 560, 35.6m, 1, new DateTime(2026, 9, 1, 15, 0, 0, 0, DateTimeKind.Utc), 115000L },
                    { 104, 29.0m, 29m, 290, 30.45m, 4, 580, 34.8m, 1, new DateTime(2026, 9, 1, 15, 0, 0, 0, DateTimeKind.Utc), 120000L },
                    { 105, 30m, 30m, 300, 31.50m, 5, 600, 36m, 1, new DateTime(2026, 9, 1, 15, 0, 0, 0, DateTimeKind.Utc), 125000L },
                    { 106, 10.5m, 21m, 105, 11.02m, 1, 210, 23.1m, 1, new DateTime(2026, 9, 2, 6, 0, 0, 0, DateTimeKind.Utc), 130000L },
                    { 107, 11.0m, 20m, 110, 11.55m, 2, 220, 22.2m, 1, new DateTime(2026, 9, 2, 6, 0, 0, 0, DateTimeKind.Utc), 135000L },
                    { 108, 11.5m, 21m, 115, 12.08m, 3, 230, 23.3m, 1, new DateTime(2026, 9, 2, 6, 0, 0, 0, DateTimeKind.Utc), 140000L },
                    { 109, 12.0m, 20m, 120, 12.60m, 4, 240, 22.4m, 1, new DateTime(2026, 9, 2, 6, 0, 0, 0, DateTimeKind.Utc), 145000L },
                    { 110, 12.5m, 21m, 125, 13.12m, 5, 250, 23.5m, 1, new DateTime(2026, 9, 2, 6, 0, 0, 0, DateTimeKind.Utc), 150000L },
                    { 111, 30.75m, 24m, 307, 32.29m, 1, 615, 30.15m, 1, new DateTime(2026, 9, 2, 9, 0, 0, 0, DateTimeKind.Utc), 130000L },
                    { 112, 31.5m, 23m, 315, 33.08m, 2, 630, 29.3m, 1, new DateTime(2026, 9, 2, 9, 0, 0, 0, DateTimeKind.Utc), 135000L },
                    { 113, 32.25m, 24m, 322, 33.86m, 3, 645, 30.45m, 1, new DateTime(2026, 9, 2, 9, 0, 0, 0, DateTimeKind.Utc), 140000L },
                    { 114, 33.0m, 23m, 330, 34.65m, 4, 660, 29.6m, 1, new DateTime(2026, 9, 2, 9, 0, 0, 0, DateTimeKind.Utc), 145000L },
                    { 115, 33.75m, 24m, 337, 35.44m, 5, 675, 30.75m, 1, new DateTime(2026, 9, 2, 9, 0, 0, 0, DateTimeKind.Utc), 150000L },
                    { 116, 42.75m, 27m, 427, 44.89m, 1, 855, 35.55m, 1, new DateTime(2026, 9, 2, 12, 0, 0, 0, DateTimeKind.Utc), 130000L },
                    { 117, 43.0m, 26m, 430, 45.15m, 2, 860, 34.6m, 1, new DateTime(2026, 9, 2, 12, 0, 0, 0, DateTimeKind.Utc), 135000L },
                    { 118, 43.25m, 27m, 432, 45.41m, 3, 865, 35.65m, 1, new DateTime(2026, 9, 2, 12, 0, 0, 0, DateTimeKind.Utc), 140000L },
                    { 119, 43.5m, 26m, 435, 45.68m, 4, 870, 34.7m, 1, new DateTime(2026, 9, 2, 12, 0, 0, 0, DateTimeKind.Utc), 145000L },
                    { 120, 43.75m, 27m, 437, 45.94m, 5, 875, 35.75m, 1, new DateTime(2026, 9, 2, 12, 0, 0, 0, DateTimeKind.Utc), 150000L },
                    { 121, 26.0m, 30m, 260, 27.30m, 1, 520, 35.2m, 1, new DateTime(2026, 9, 2, 15, 0, 0, 0, DateTimeKind.Utc), 130000L },
                    { 122, 27.0m, 29m, 270, 28.35m, 2, 540, 34.4m, 1, new DateTime(2026, 9, 2, 15, 0, 0, 0, DateTimeKind.Utc), 135000L },
                    { 123, 28.0m, 30m, 280, 29.40m, 3, 560, 35.6m, 1, new DateTime(2026, 9, 2, 15, 0, 0, 0, DateTimeKind.Utc), 140000L },
                    { 124, 29.0m, 29m, 290, 30.45m, 4, 580, 34.8m, 1, new DateTime(2026, 9, 2, 15, 0, 0, 0, DateTimeKind.Utc), 145000L },
                    { 125, 30m, 30m, 300, 31.50m, 5, 600, 36m, 1, new DateTime(2026, 9, 2, 15, 0, 0, 0, DateTimeKind.Utc), 150000L },
                    { 126, 10.5m, 21m, 105, 11.02m, 1, 210, 23.1m, 1, new DateTime(2026, 9, 3, 6, 0, 0, 0, DateTimeKind.Utc), 155000L },
                    { 127, 11.0m, 20m, 110, 11.55m, 2, 220, 22.2m, 1, new DateTime(2026, 9, 3, 6, 0, 0, 0, DateTimeKind.Utc), 160000L },
                    { 128, 11.5m, 21m, 115, 12.08m, 3, 230, 23.3m, 1, new DateTime(2026, 9, 3, 6, 0, 0, 0, DateTimeKind.Utc), 165000L },
                    { 129, 12.0m, 20m, 120, 12.60m, 4, 240, 22.4m, 1, new DateTime(2026, 9, 3, 6, 0, 0, 0, DateTimeKind.Utc), 170000L },
                    { 130, 12.5m, 21m, 125, 13.12m, 5, 250, 23.5m, 1, new DateTime(2026, 9, 3, 6, 0, 0, 0, DateTimeKind.Utc), 175000L },
                    { 131, 30.75m, 24m, 307, 32.29m, 1, 615, 30.15m, 1, new DateTime(2026, 9, 3, 9, 0, 0, 0, DateTimeKind.Utc), 155000L },
                    { 132, 31.5m, 23m, 315, 33.08m, 2, 630, 29.3m, 1, new DateTime(2026, 9, 3, 9, 0, 0, 0, DateTimeKind.Utc), 160000L },
                    { 133, 32.25m, 24m, 322, 33.86m, 3, 645, 30.45m, 1, new DateTime(2026, 9, 3, 9, 0, 0, 0, DateTimeKind.Utc), 165000L },
                    { 134, 33.0m, 23m, 330, 34.65m, 4, 660, 29.6m, 1, new DateTime(2026, 9, 3, 9, 0, 0, 0, DateTimeKind.Utc), 170000L },
                    { 135, 33.75m, 24m, 337, 35.44m, 5, 675, 30.75m, 1, new DateTime(2026, 9, 3, 9, 0, 0, 0, DateTimeKind.Utc), 175000L },
                    { 136, 42.75m, 27m, 427, 44.89m, 1, 855, 35.55m, 1, new DateTime(2026, 9, 3, 12, 0, 0, 0, DateTimeKind.Utc), 155000L },
                    { 137, 43.0m, 26m, 430, 45.15m, 2, 860, 34.6m, 1, new DateTime(2026, 9, 3, 12, 0, 0, 0, DateTimeKind.Utc), 160000L },
                    { 138, 43.25m, 27m, 432, 45.41m, 3, 865, 35.65m, 1, new DateTime(2026, 9, 3, 12, 0, 0, 0, DateTimeKind.Utc), 165000L },
                    { 139, 43.5m, 26m, 435, 45.68m, 4, 870, 34.7m, 1, new DateTime(2026, 9, 3, 12, 0, 0, 0, DateTimeKind.Utc), 170000L },
                    { 140, 43.75m, 27m, 437, 45.94m, 5, 875, 35.75m, 1, new DateTime(2026, 9, 3, 12, 0, 0, 0, DateTimeKind.Utc), 175000L },
                    { 141, 26.0m, 30m, 260, 27.30m, 1, 520, 35.2m, 1, new DateTime(2026, 9, 3, 15, 0, 0, 0, DateTimeKind.Utc), 155000L },
                    { 142, 27.0m, 29m, 270, 28.35m, 2, 540, 34.4m, 1, new DateTime(2026, 9, 3, 15, 0, 0, 0, DateTimeKind.Utc), 160000L },
                    { 143, 28.0m, 30m, 280, 29.40m, 3, 560, 35.6m, 1, new DateTime(2026, 9, 3, 15, 0, 0, 0, DateTimeKind.Utc), 165000L },
                    { 144, 29.0m, 29m, 290, 30.45m, 4, 580, 34.8m, 1, new DateTime(2026, 9, 3, 15, 0, 0, 0, DateTimeKind.Utc), 170000L },
                    { 145, 30m, 30m, 300, 31.50m, 5, 600, 36m, 1, new DateTime(2026, 9, 3, 15, 0, 0, 0, DateTimeKind.Utc), 175000L }
                });

            migrationBuilder.InsertData(
                table: "RepairVerifications",
                columns: new[] { "Id", "ExpectedPowerKw", "InverterId", "IsStable", "MaintenanceActionId", "PerformanceAfter", "PerformanceBefore", "RecoveryPct", "Verified", "VerifiedAt" },
                values: new object[] { 1, 4500m, null, true, 1, 4300m, 2800m, 88.24m, false, new DateTime(2026, 8, 28, 10, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnalysisResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnalysisResults",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnalysisResults",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnalysisResults",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AnalysisResults",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MaintenanceActions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaintenanceActions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RepairVerifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Telemetry",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "MaintenanceActions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "PerformanceBefore",
                table: "RepairVerifications",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PerformanceAfter",
                table: "RepairVerifications",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
