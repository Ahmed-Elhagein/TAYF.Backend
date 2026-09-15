using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CapacityKw = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TariffType = table.Column<int>(type: "integer", nullable: false),
                    TariffRate = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    InstallationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inverters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MaxPowerKw = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inverters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inverters_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tariffs_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    Problem = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RootCause = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FinancialLoss = table.Column<decimal>(type: "numeric", nullable: false),
                    EnergyLossKwh = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    RecommendedAction = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Inverters_InverterId",
                        column: x => x.InverterId,
                        principalTable: "Inverters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alerts_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualPowerKw = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ExpectedPowerKw = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DeviationPct = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    IsAnomaly = table.Column<bool>(type: "boolean", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    AnomalyScore = table.Column<decimal>(type: "numeric(5,4)", nullable: false),
                    PrimaryCause = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CauseProbabilities = table.Column<string>(type: "TEXT", nullable: false),
                    ConfidenceScore = table.Column<decimal>(type: "numeric(5,4)", nullable: false),
                    EnergyLossKwh = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ExpectedEnergyKwh = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualEnergyKwh = table.Column<decimal>(type: "numeric", nullable: false),
                    EstimatedLoss = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisResults_Inverters_InverterId",
                        column: x => x.InverterId,
                        principalTable: "Inverters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalysisResults_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: true),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceActions_Inverters_InverterId",
                        column: x => x.InverterId,
                        principalTable: "Inverters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceActions_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AcPowerKw = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DcPowerKw = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Irradiance = table.Column<int>(type: "int", nullable: false),
                    AmbientTemperature = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    ModuleTemperature = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    DailyYield = table.Column<int>(type: "int", nullable: false),
                    TotalYield = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telemetry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telemetry_Inverters_InverterId",
                        column: x => x.InverterId,
                        principalTable: "Inverters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telemetry_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelemetryProcessingCheckpoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InverterId = table.Column<int>(type: "int", nullable: false),
                    LastProcessedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'utc'")
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

            migrationBuilder.CreateTable(
                name: "RepairVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaintenanceActionId = table.Column<int>(type: "int", nullable: false),
                    PerformanceBefore = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PerformanceAfter = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ExpectedPowerKw = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    RecoveryPct = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    IsStable = table.Column<bool>(type: "boolean", nullable: false),
                    Verified = table.Column<bool>(type: "boolean", nullable: false),
                    VerifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairVerifications_Inverters_InverterId",
                        column: x => x.InverterId,
                        principalTable: "Inverters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepairVerifications_MaintenanceActions_MaintenanceActionId",
                        column: x => x.MaintenanceActionId,
                        principalTable: "MaintenanceActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "CapacityKw", "Currency", "InstallationDate", "IsActive", "Location", "Name", "TariffRate", "TariffType" },
                values: new object[] { 1, 500m, 1, new DateTime(2023, 1, 14, 22, 0, 0, 0, DateTimeKind.Utc), true, "Cairo, Egypt", "Solar Plant A - Cairo", 1.25m, 1 });

            migrationBuilder.InsertData(
                table: "Inverters",
                columns: new[] { "Id", "InstallationDate", "IsActive", "MaxPowerKw", "Model", "PlantId", "SerialNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-001" },
                    { 2, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-002" },
                    { 3, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-003" },
                    { 4, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-004" },
                    { 5, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-005" },
                    { 6, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-006" },
                    { 7, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-007" },
                    { 8, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-008" },
                    { 9, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-009" },
                    { 10, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-010" },
                    { 11, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-011" },
                    { 12, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-012" },
                    { 13, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-013" },
                    { 14, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-014" },
                    { 15, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-015" },
                    { 16, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-016" },
                    { 17, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-017" },
                    { 18, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-018" },
                    { 19, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-019" },
                    { 20, new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-020" }
                });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "Currency", "PlantId", "Rate", "Type" },
                values: new object[] { 1, 1, 1, 1.25m, 1 });

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
                    { 1, 0.03m, 22m, 164, 0m, 1, 0, 22m, 1, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 1000L },
                    { 2, 0.1m, 21m, 624, 0m, 2, 49, 22.22m, 1, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 2000L },
                    { 3, 2.85m, 19m, 17098, 0m, 3, 0, 19m, 1, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 3000L },
                    { 4, 0m, 21m, 0, 1.62m, 4, 0, 21m, 1, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 4000L },
                    { 5, 2.95m, 17m, 17687, 0m, 5, 0, 17m, 1, new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 5000L },
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

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_InverterId",
                table: "Alerts",
                column: "InverterId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_PlantId",
                table: "Alerts",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisResult_InverterId_Timestamp",
                table: "AnalysisResults",
                columns: new[] { "InverterId", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisResult_IsAnomaly",
                table: "AnalysisResults",
                column: "IsAnomaly");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisResult_PlantId_Timestamp",
                table: "AnalysisResults",
                columns: new[] { "PlantId", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_Inverters_PlantId",
                table: "Inverters",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceActions_InverterId",
                table: "MaintenanceActions",
                column: "InverterId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceActions_PlantId",
                table: "MaintenanceActions",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairVerifications_InverterId",
                table: "RepairVerifications",
                column: "InverterId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairVerifications_MaintenanceActionId",
                table: "RepairVerifications",
                column: "MaintenanceActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_PlantId",
                table: "Tariffs",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetry_InverterId_Timestamp",
                table: "Telemetry",
                columns: new[] { "InverterId", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_Telemetry_PlantId_Timestamp",
                table: "Telemetry",
                columns: new[] { "PlantId", "Timestamp" });

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
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "AnalysisResults");

            migrationBuilder.DropTable(
                name: "RepairVerifications");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "Telemetry");

            migrationBuilder.DropTable(
                name: "TelemetryProcessingCheckpoints");

            migrationBuilder.DropTable(
                name: "MaintenanceActions");

            migrationBuilder.DropTable(
                name: "Inverters");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
