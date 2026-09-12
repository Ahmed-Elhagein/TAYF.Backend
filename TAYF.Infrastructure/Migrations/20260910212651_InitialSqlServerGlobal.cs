using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlServerGlobal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CapacityKw = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TariffType = table.Column<int>(type: "int", nullable: false),
                    TariffRateEgpPerKwh = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxPowerKw = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RateEgpPerKwh = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
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
                name: "Alert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RootCause = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnergyLossKwh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinancialLossEgp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecommendedAction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alert_Inverters_InverterId",
                        column: x => x.InverterId,
                        principalTable: "Inverters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alert_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualPowerKw = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpectedPowerKw = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeviationPct = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsAnomaly = table.Column<bool>(type: "bit", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    AnomalyScore = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    PrimaryCause = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CauseProbabilities = table.Column<string>(type: "TEXT", nullable: false),
                    ConfidenceScore = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    EnergyLossKwh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedLossEgp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: true),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcPowerKw = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DcPowerKw = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Irradiance = table.Column<int>(type: "int", nullable: false),
                    AmbientTemperature = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ModuleTemperature = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
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
                name: "RepairVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceActionId = table.Column<int>(type: "int", nullable: false),
                    PerformanceBefore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PerformanceAfter = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RecoveryPct = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsStable = table.Column<bool>(type: "bit", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InverterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairVerifications_Inverters_InverterId",
                        column: x => x.InverterId,
                        principalTable: "Inverters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairVerifications_MaintenanceActions_MaintenanceActionId",
                        column: x => x.MaintenanceActionId,
                        principalTable: "MaintenanceActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "CapacityKw", "InstallationDate", "IsActive", "Location", "Name", "TariffRateEgpPerKwh", "TariffType" },
                values: new object[] { 1, 500m, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cairo, Egypt", "Solar Plant A - Cairo", 1.25m, 1 });

            migrationBuilder.InsertData(
                table: "Inverters",
                columns: new[] { "Id", "InstallationDate", "IsActive", "MaxPowerKw", "Model", "PlantId", "SerialNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-001" },
                    { 2, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-002" },
                    { 3, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-003" },
                    { 4, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-004" },
                    { 5, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100m, "SUN2000-100KTL", 1, "INV-CAIRO-005" }
                });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "PlantId", "RateEgpPerKwh", "Type" },
                values: new object[] { 1, 1, 1.25m, 1 });

            migrationBuilder.InsertData(
                table: "Telemetry",
                columns: new[] { "Id", "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "InverterId", "Irradiance", "ModuleTemperature", "PlantId", "Timestamp", "TotalYield" },
                values: new object[,]
                {
                    { 1, 0m, 17m, 0, 0m, 1, 40, 18m, 1, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 1000L },
                    { 2, 0m, 18m, 0, 0m, 2, 0, 18m, 1, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 2000L },
                    { 3, 0m, 17m, 0, 3.94m, 3, 25, 17.62m, 1, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 3000L },
                    { 4, 3.37m, 19m, 20191, 3.08m, 4, 14, 19.35m, 1, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 4000L },
                    { 5, 0.62m, 20m, 3706, 1.78m, 5, 28, 20.7m, 1, new DateTime(2026, 9, 3, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 5000L },
                    { 6, 0m, 30m, 0, 3.15m, 1, 0, 30m, 1, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 6000L },
                    { 7, 3.7m, 29m, 22185, 0m, 2, 0, 29m, 1, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 7000L },
                    { 8, 0m, 27m, 0, 0m, 3, 0, 27m, 1, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 8000L },
                    { 9, 3.08m, 27m, 18471, 0.84m, 4, 27, 27.68m, 1, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 9000L },
                    { 10, 0m, 30m, 0, 2.82m, 5, 0, 30m, 1, new DateTime(2026, 9, 4, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 10000L },
                    { 11, 0.23m, 41m, 1366, 0m, 1, 804, 61.1m, 1, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 11000L },
                    { 12, 0m, 37m, 0, 3m, 2, 849, 58.22m, 1, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 12000L },
                    { 13, 0m, 41m, 0, 0m, 3, 826, 61.65m, 1, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 13000L },
                    { 14, 0m, 40m, 0, 0m, 4, 773, 59.32m, 1, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 14000L },
                    { 15, 1.98m, 42m, 11883, 1.42m, 5, 834, 62.85m, 1, new DateTime(2026, 9, 4, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 15000L },
                    { 16, 0m, 27m, 0, 4.63m, 1, 41, 28.02m, 1, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 16000L },
                    { 17, 3.68m, 28m, 22091, 0m, 2, 44, 29.1m, 1, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 17000L },
                    { 18, 0m, 28m, 0, 4.99m, 3, 0, 28m, 1, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 18000L },
                    { 19, 0m, 31m, 0, 2.17m, 4, 0, 31m, 1, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 19000L },
                    { 20, 2.82m, 29m, 16940, 0m, 5, 0, 29m, 1, new DateTime(2026, 9, 4, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 20000L },
                    { 21, 0.16m, 20m, 981, 3.53m, 1, 23, 20.58m, 1, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 21000L },
                    { 22, 0m, 18m, 0, 0m, 2, 42, 19.05m, 1, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 22000L },
                    { 23, 0m, 18m, 0, 2.4m, 3, 11, 18.27m, 1, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 23000L },
                    { 24, 0m, 20m, 0, 4.01m, 4, 0, 20m, 1, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 24000L },
                    { 25, 0m, 22m, 0, 0m, 5, 0, 22m, 1, new DateTime(2026, 9, 4, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 25000L },
                    { 26, 0m, 31m, 0, 3.77m, 1, 43, 32.08m, 1, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 26000L },
                    { 27, 0m, 27m, 0, 0.66m, 2, 0, 27m, 1, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 27000L },
                    { 28, 0m, 28m, 0, 0.63m, 3, 37, 28.92m, 1, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 28000L },
                    { 29, 0m, 30m, 0, 0m, 4, 3, 30.08m, 1, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 29000L },
                    { 30, 2.15m, 30m, 12902, 0m, 5, 47, 31.18m, 1, new DateTime(2026, 9, 5, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 30000L },
                    { 31, 3.63m, 37m, 21773, 0m, 1, 834, 57.85m, 1, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 31000L },
                    { 32, 0m, 37m, 0, 0m, 2, 778, 56.45m, 1, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 32000L },
                    { 33, 1.63m, 40m, 9791, 1.28m, 3, 817, 60.42m, 1, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 33000L },
                    { 34, 0m, 37m, 0, 2.05m, 4, 762, 56.05m, 1, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 34000L },
                    { 35, 0m, 38m, 0, 0m, 5, 786, 57.65m, 1, new DateTime(2026, 9, 5, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 35000L },
                    { 36, 0m, 30m, 0, 0m, 1, 11, 30.28m, 1, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 36000L },
                    { 37, 3.73m, 31m, 22381, 1.19m, 2, 26, 31.65m, 1, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 37000L },
                    { 38, 3.47m, 31m, 20794, 3.48m, 3, 0, 31m, 1, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 38000L },
                    { 39, 0m, 31m, 0, 2.94m, 4, 0, 31m, 1, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 39000L },
                    { 40, 0m, 31m, 0, 3.86m, 5, 0, 31m, 1, new DateTime(2026, 9, 5, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 40000L },
                    { 41, 0m, 19m, 0, 0m, 1, 29, 19.73m, 1, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 41000L },
                    { 42, 3.02m, 21m, 18113, 0m, 2, 26, 21.65m, 1, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 42000L },
                    { 43, 0m, 18m, 0, 1.8m, 3, 0, 18m, 1, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 43000L },
                    { 44, 0m, 22m, 0, 0m, 4, 0, 22m, 1, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 44000L },
                    { 45, 2.65m, 22m, 15920, 0m, 5, 3, 22.08m, 1, new DateTime(2026, 9, 5, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 45000L },
                    { 46, 2.55m, 30m, 15320, 0m, 1, 17, 30.42m, 1, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 46000L },
                    { 47, 1.83m, 27m, 11002, 3.18m, 2, 0, 27m, 1, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 47000L },
                    { 48, 0m, 30m, 0, 0m, 3, 41, 31.02m, 1, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 48000L },
                    { 49, 3.22m, 28m, 19294, 4.85m, 4, 36, 28.9m, 1, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 49000L },
                    { 50, 1.85m, 29m, 11128, 1.71m, 5, 30, 29.75m, 1, new DateTime(2026, 9, 6, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 50000L },
                    { 51, 3.52m, 41m, 21114, 0m, 1, 843, 62.08m, 1, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 51000L },
                    { 52, 0m, 41m, 0, 0m, 2, 822, 61.55m, 1, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 52000L },
                    { 53, 0m, 41m, 0, 1.46m, 3, 793, 60.82m, 1, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 53000L },
                    { 54, 0m, 37m, 0, 1.37m, 4, 752, 55.8m, 1, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 54000L },
                    { 55, 0.85m, 41m, 5123, 1.46m, 5, 793, 60.82m, 1, new DateTime(2026, 9, 6, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 55000L },
                    { 56, 0m, 30m, 0, 0m, 1, 0, 30m, 1, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 56000L },
                    { 57, 0.47m, 30m, 2823, 3.32m, 2, 14, 30.35m, 1, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 57000L },
                    { 58, 3.38m, 28m, 20298, 3.61m, 3, 21, 28.52m, 1, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 58000L },
                    { 59, 0.36m, 31m, 2154, 3.05m, 4, 29, 31.72m, 1, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 59000L },
                    { 60, 0m, 31m, 0, 0m, 5, 0, 31m, 1, new DateTime(2026, 9, 6, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 60000L },
                    { 61, 2.53m, 19m, 15156, 0m, 1, 46, 20.15m, 1, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 61000L },
                    { 62, 2.54m, 22m, 15269, 0m, 2, 0, 22m, 1, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 62000L },
                    { 63, 0.13m, 19m, 756, 0m, 3, 0, 19m, 1, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 63000L },
                    { 64, 3.8m, 22m, 22827, 3.1m, 4, 0, 22m, 1, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 64000L },
                    { 65, 0.14m, 22m, 822, 0m, 5, 0, 22m, 1, new DateTime(2026, 9, 6, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 65000L },
                    { 66, 2.02m, 29m, 12125, 0m, 1, 44, 30.1m, 1, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 66000L },
                    { 67, 0m, 27m, 0, 1.79m, 2, 9, 27.22m, 1, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 67000L },
                    { 68, 0m, 28m, 0, 0m, 3, 19, 28.48m, 1, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 68000L },
                    { 69, 1.5m, 31m, 9011, 0m, 4, 8, 31.2m, 1, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 69000L },
                    { 70, 1.17m, 28m, 7032, 0m, 5, 0, 28m, 1, new DateTime(2026, 9, 7, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 70000L },
                    { 71, 1.25m, 42m, 7497, 1.97m, 1, 767, 61.18m, 1, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 71000L },
                    { 72, 0m, 42m, 0, 1.88m, 2, 830, 62.75m, 1, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 72000L },
                    { 73, 3.46m, 37m, 20742, 0m, 3, 794, 56.85m, 1, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 73000L },
                    { 74, 2.16m, 41m, 12939, 0m, 4, 817, 61.42m, 1, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 74000L },
                    { 75, 0.59m, 40m, 3537, 0m, 5, 834, 60.85m, 1, new DateTime(2026, 9, 7, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 75000L },
                    { 76, 0m, 31m, 0, 0m, 1, 20, 31.5m, 1, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 76000L },
                    { 77, 2.09m, 27m, 12516, 0m, 2, 27, 27.68m, 1, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 77000L },
                    { 78, 0m, 30m, 0, 0.16m, 3, 0, 30m, 1, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 78000L },
                    { 79, 0.38m, 29m, 2285, 0m, 4, 0, 29m, 1, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 79000L },
                    { 80, 1.42m, 31m, 8493, 2.45m, 5, 0, 31m, 1, new DateTime(2026, 9, 7, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 80000L },
                    { 81, 3.69m, 18m, 22114, 1.34m, 1, 17, 18.42m, 1, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 81000L },
                    { 82, 2.01m, 20m, 12061, 0m, 2, 11, 20.27m, 1, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 82000L },
                    { 83, 0m, 20m, 0, 3.02m, 3, 0, 20m, 1, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 83000L },
                    { 84, 2.33m, 19m, 13965, 2.82m, 4, 44, 20.1m, 1, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 84000L },
                    { 85, 1.93m, 18m, 11597, 2.43m, 5, 0, 18m, 1, new DateTime(2026, 9, 7, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 85000L },
                    { 86, 0m, 27m, 0, 0m, 1, 0, 27m, 1, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 86000L },
                    { 87, 0.03m, 29m, 202, 1.5m, 2, 0, 29m, 1, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 87000L },
                    { 88, 0m, 28m, 0, 1.98m, 3, 44, 29.1m, 1, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 88000L },
                    { 89, 0m, 31m, 0, 0m, 4, 9, 31.22m, 1, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 89000L },
                    { 90, 0m, 27m, 0, 2.3m, 5, 49, 28.22m, 1, new DateTime(2026, 9, 8, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 90000L },
                    { 91, 0m, 42m, 0, 3.9m, 1, 841, 63.03m, 1, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 91000L },
                    { 92, 0m, 37m, 0, 3.21m, 2, 774, 56.35m, 1, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 92000L },
                    { 93, 2.94m, 37m, 17647, 0m, 3, 796, 56.9m, 1, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 93000L },
                    { 94, 0m, 42m, 0, 0m, 4, 787, 61.68m, 1, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 94000L },
                    { 95, 1.78m, 38m, 10682, 0m, 5, 820, 58.5m, 1, new DateTime(2026, 9, 8, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 95000L },
                    { 96, 0m, 28m, 0, 1.72m, 1, 43, 29.08m, 1, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 96000L },
                    { 97, 0m, 32m, 0, 4.8m, 2, 48, 33.2m, 1, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 97000L },
                    { 98, 0m, 31m, 0, 1.58m, 3, 27, 31.68m, 1, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 98000L },
                    { 99, 0m, 27m, 0, 0m, 4, 0, 27m, 1, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 99000L },
                    { 100, 0m, 29m, 0, 0m, 5, 48, 30.2m, 1, new DateTime(2026, 9, 8, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 100000L },
                    { 101, 3.06m, 19m, 18384, 3.83m, 1, 23, 19.58m, 1, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 101000L },
                    { 102, 0m, 18m, 0, 1.67m, 2, 20, 18.5m, 1, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 102000L },
                    { 103, 0m, 19m, 0, 0m, 3, 14, 19.35m, 1, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 103000L },
                    { 104, 0m, 22m, 0, 0m, 4, 0, 22m, 1, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 104000L },
                    { 105, 0.46m, 19m, 2780, 0m, 5, 0, 19m, 1, new DateTime(2026, 9, 8, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 105000L },
                    { 106, 2.21m, 31m, 13256, 0m, 1, 0, 31m, 1, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 106000L },
                    { 107, 2.15m, 30m, 12877, 0m, 2, 0, 30m, 1, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 107000L },
                    { 108, 2.98m, 27m, 17867, 3.86m, 3, 0, 27m, 1, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 108000L },
                    { 109, 1.84m, 30m, 11058, 0m, 4, 0, 30m, 1, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 109000L },
                    { 110, 3.69m, 32m, 22111, 4.11m, 5, 49, 33.22m, 1, new DateTime(2026, 9, 9, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 110000L },
                    { 111, 0m, 40m, 0, 0m, 1, 754, 58.85m, 1, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 111000L },
                    { 112, 0m, 41m, 0, 0m, 2, 753, 59.82m, 1, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 112000L },
                    { 113, 2.73m, 42m, 16366, 2.11m, 3, 837, 62.92m, 1, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 113000L },
                    { 114, 1.51m, 40m, 9081, 3.9m, 4, 840, 61m, 1, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 114000L },
                    { 115, 0m, 42m, 0, 0m, 5, 775, 61.38m, 1, new DateTime(2026, 9, 9, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 115000L },
                    { 116, 0m, 30m, 0, 3.98m, 1, 36, 30.9m, 1, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 116000L },
                    { 117, 1.53m, 28m, 9183, 0.28m, 2, 0, 28m, 1, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 117000L },
                    { 118, 1.05m, 31m, 6321, 1.87m, 3, 10, 31.25m, 1, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 118000L },
                    { 119, 0m, 32m, 0, 4.6m, 4, 46, 33.15m, 1, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 119000L },
                    { 120, 1.4m, 29m, 8411, 1.6m, 5, 10, 29.25m, 1, new DateTime(2026, 9, 9, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 120000L },
                    { 121, 0m, 17m, 0, 0m, 1, 0, 17m, 1, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 121000L },
                    { 122, 3.31m, 21m, 19872, 2.41m, 2, 0, 21m, 1, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 122000L },
                    { 123, 0.77m, 18m, 4607, 3.38m, 3, 0, 18m, 1, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 123000L },
                    { 124, 0m, 20m, 0, 4.03m, 4, 30, 20.75m, 1, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 124000L },
                    { 125, 0m, 17m, 0, 2.71m, 5, 45, 18.12m, 1, new DateTime(2026, 9, 9, 21, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 125000L },
                    { 126, 2.41m, 28m, 14458, 1.82m, 1, 28, 28.7m, 1, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 126000L },
                    { 127, 0m, 32m, 0, 0.55m, 2, 33, 32.83m, 1, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 127000L },
                    { 128, 1.6m, 27m, 9623, 0m, 3, 0, 27m, 1, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 128000L },
                    { 129, 0.83m, 32m, 5001, 0m, 4, 29, 32.72m, 1, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 129000L },
                    { 130, 2.1m, 30m, 12572, 1.13m, 5, 0, 30m, 1, new DateTime(2026, 9, 10, 3, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 130000L },
                    { 131, 1.01m, 42m, 6072, 2.57m, 1, 764, 61.1m, 1, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 131000L },
                    { 132, 2.76m, 40m, 16579, 1.72m, 2, 827, 60.68m, 1, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 132000L },
                    { 133, 0m, 40m, 0, 0m, 3, 759, 58.98m, 1, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 133000L },
                    { 134, 0m, 41m, 0, 0.74m, 4, 751, 59.78m, 1, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 134000L },
                    { 135, 1.9m, 38m, 11415, 0.08m, 5, 770, 57.25m, 1, new DateTime(2026, 9, 10, 9, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 135000L },
                    { 136, 0m, 31m, 0, 0m, 1, 3, 31.08m, 1, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 136000L },
                    { 137, 3.51m, 30m, 21063, 0m, 2, 34, 30.85m, 1, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 137000L },
                    { 138, 0m, 32m, 0, 0m, 3, 0, 32m, 1, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 138000L },
                    { 139, 2.38m, 30m, 14283, 0m, 4, 0, 30m, 1, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 139000L },
                    { 140, 0m, 31m, 0, 0m, 5, 0, 31m, 1, new DateTime(2026, 9, 10, 15, 26, 50, 856, DateTimeKind.Utc).AddTicks(1082), 140000L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alert_InverterId",
                table: "Alert",
                column: "InverterId");

            migrationBuilder.CreateIndex(
                name: "IX_Alert_PlantId",
                table: "Alert",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropTable(
                name: "AnalysisResults");

            migrationBuilder.DropTable(
                name: "RepairVerifications");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "Telemetry");

            migrationBuilder.DropTable(
                name: "MaintenanceActions");

            migrationBuilder.DropTable(
                name: "Inverters");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
