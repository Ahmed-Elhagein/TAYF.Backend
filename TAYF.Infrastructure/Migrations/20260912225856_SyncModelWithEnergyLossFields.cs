using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncModelWithEnergyLossFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Inverters_InverterId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Plants_PlantId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairVerifications_Inverters_InverterId",
                table: "RepairVerifications");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Inverters_InverterId",
                table: "Alerts",
                column: "InverterId",
                principalTable: "Inverters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Plants_PlantId",
                table: "Alerts",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairVerifications_Inverters_InverterId",
                table: "RepairVerifications",
                column: "InverterId",
                principalTable: "Inverters",
                principalColumn: "Id");
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

            migrationBuilder.DropForeignKey(
                name: "FK_RepairVerifications_Inverters_InverterId",
                table: "RepairVerifications");

            migrationBuilder.InsertData(
                table: "Telemetry",
                columns: new[] { "Id", "AcPowerKw", "AmbientTemperature", "DailyYield", "DcPowerKw", "InverterId", "Irradiance", "ModuleTemperature", "PlantId", "Timestamp", "TotalYield" },
                values: new object[,]
                {
                    { 6, 1.95m, 28m, 11681, 0m, 1, 31, 28.78m, 1, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 6000L },
                    { 7, 3.83m, 32m, 22973, 0m, 2, 0, 32m, 1, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 7000L },
                    { 8, 0m, 31m, 0, 4.69m, 3, 0, 31m, 1, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 8000L },
                    { 9, 0.87m, 29m, 5194, 4.56m, 4, 49, 30.22m, 1, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 9000L },
                    { 10, 0m, 29m, 0, 0m, 5, 0, 29m, 1, new DateTime(2026, 9, 5, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 10000L },
                    { 11, 2.34m, 41m, 14046, 3.96m, 1, 753, 59.82m, 1, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 11000L },
                    { 12, 0m, 37m, 0, 3.59m, 2, 849, 58.22m, 1, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 12000L },
                    { 13, 0m, 38m, 0, 0m, 3, 826, 58.65m, 1, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 13000L },
                    { 14, 1.89m, 39m, 11327, 1.43m, 4, 772, 58.3m, 1, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 14000L },
                    { 15, 0m, 39m, 0, 0m, 5, 848, 60.2m, 1, new DateTime(2026, 9, 5, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 15000L },
                    { 16, 0m, 32m, 0, 1.67m, 1, 0, 32m, 1, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 16000L },
                    { 17, 0m, 27m, 0, 0m, 2, 45, 28.12m, 1, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 17000L },
                    { 18, 3.96m, 32m, 23751, 2.42m, 3, 0, 32m, 1, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 18000L },
                    { 19, 1.81m, 31m, 10868, 2.31m, 4, 0, 31m, 1, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 19000L },
                    { 20, 1.21m, 30m, 7269, 0m, 5, 0, 30m, 1, new DateTime(2026, 9, 5, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 20000L },
                    { 21, 0m, 21m, 0, 3.98m, 1, 27, 21.68m, 1, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 21000L },
                    { 22, 2.74m, 22m, 16417, 0m, 2, 15, 22.38m, 1, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 22000L },
                    { 23, 0m, 22m, 0, 1.92m, 3, 19, 22.48m, 1, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 23000L },
                    { 24, 0m, 19m, 0, 0m, 4, 0, 19m, 1, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 24000L },
                    { 25, 0m, 20m, 0, 0m, 5, 47, 21.18m, 1, new DateTime(2026, 9, 5, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 25000L },
                    { 26, 3.92m, 27m, 23547, 2.91m, 1, 18, 27.45m, 1, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 26000L },
                    { 27, 3.08m, 30m, 18498, 4.03m, 2, 0, 30m, 1, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 27000L },
                    { 28, 0m, 27m, 0, 0m, 3, 0, 27m, 1, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 28000L },
                    { 29, 0m, 29m, 0, 2.71m, 4, 0, 29m, 1, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 29000L },
                    { 30, 1.31m, 30m, 7844, 0m, 5, 0, 30m, 1, new DateTime(2026, 9, 6, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 30000L },
                    { 31, 1.41m, 41m, 8447, 2.74m, 1, 840, 62m, 1, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 31000L },
                    { 32, 1.22m, 38m, 7311, 1.52m, 2, 849, 59.22m, 1, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 32000L },
                    { 33, 3.5m, 37m, 20979, 1.59m, 3, 791, 56.78m, 1, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 33000L },
                    { 34, 0m, 37m, 0, 0m, 4, 766, 56.15m, 1, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 34000L },
                    { 35, 0m, 40m, 0, 1.22m, 5, 810, 60.25m, 1, new DateTime(2026, 9, 6, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 35000L },
                    { 36, 1.13m, 28m, 6808, 2.42m, 1, 0, 28m, 1, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 36000L },
                    { 37, 2.12m, 31m, 12748, 0m, 2, 0, 31m, 1, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 37000L },
                    { 38, 1.65m, 31m, 9893, 0m, 3, 40, 32m, 1, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 38000L },
                    { 39, 0m, 30m, 0, 0.8m, 4, 0, 30m, 1, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 39000L },
                    { 40, 0m, 32m, 0, 4.8m, 5, 0, 32m, 1, new DateTime(2026, 9, 6, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 40000L },
                    { 41, 2.76m, 18m, 16557, 4.4m, 1, 0, 18m, 1, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 41000L },
                    { 42, 2.17m, 18m, 13039, 3.61m, 2, 0, 18m, 1, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 42000L },
                    { 43, 3.38m, 18m, 20260, 1.9m, 3, 0, 18m, 1, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 43000L },
                    { 44, 0m, 18m, 0, 0m, 4, 0, 18m, 1, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 44000L },
                    { 45, 0m, 19m, 0, 0m, 5, 48, 20.2m, 1, new DateTime(2026, 9, 6, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 45000L },
                    { 46, 1.37m, 32m, 8203, 0m, 1, 17, 32.42m, 1, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 46000L },
                    { 47, 0m, 32m, 0, 2.63m, 2, 0, 32m, 1, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 47000L },
                    { 48, 0m, 31m, 0, 3.67m, 3, 10, 31.25m, 1, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 48000L },
                    { 49, 3.24m, 32m, 19415, 0m, 4, 44, 33.1m, 1, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 49000L },
                    { 50, 0.46m, 31m, 2733, 4.14m, 5, 38, 31.95m, 1, new DateTime(2026, 9, 7, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 50000L },
                    { 51, 0m, 39m, 0, 0m, 1, 792, 58.8m, 1, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 51000L },
                    { 52, 1.83m, 40m, 10951, 0m, 2, 760, 59m, 1, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 52000L },
                    { 53, 1.08m, 42m, 6508, 4.67m, 3, 829, 62.72m, 1, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 53000L },
                    { 54, 3.33m, 38m, 19969, 4.1m, 4, 792, 57.8m, 1, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 54000L },
                    { 55, 0m, 37m, 0, 0.86m, 5, 816, 57.4m, 1, new DateTime(2026, 9, 7, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 55000L },
                    { 56, 2.19m, 29m, 13147, 0m, 1, 28, 29.7m, 1, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 56000L },
                    { 57, 0m, 32m, 0, 3.79m, 2, 0, 32m, 1, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 57000L },
                    { 58, 0m, 27m, 0, 2.65m, 3, 40, 28m, 1, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 58000L },
                    { 59, 0m, 28m, 0, 2.61m, 4, 42, 29.05m, 1, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 59000L },
                    { 60, 0.3m, 30m, 1775, 1.75m, 5, 0, 30m, 1, new DateTime(2026, 9, 7, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 60000L },
                    { 61, 0m, 17m, 0, 0m, 1, 11, 17.27m, 1, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 61000L },
                    { 62, 0.21m, 19m, 1239, 2.05m, 2, 0, 19m, 1, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 62000L },
                    { 63, 0m, 17m, 0, 2.34m, 3, 27, 17.68m, 1, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 63000L },
                    { 64, 0m, 17m, 0, 3.26m, 4, 0, 17m, 1, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 64000L },
                    { 65, 0m, 17m, 0, 0.67m, 5, 0, 17m, 1, new DateTime(2026, 9, 7, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 65000L },
                    { 66, 0m, 32m, 0, 4.22m, 1, 0, 32m, 1, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 66000L },
                    { 67, 0m, 32m, 0, 0m, 2, 0, 32m, 1, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 67000L },
                    { 68, 0m, 28m, 0, 0.49m, 3, 0, 28m, 1, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 68000L },
                    { 69, 0.98m, 29m, 5879, 0.6m, 4, 0, 29m, 1, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 69000L },
                    { 70, 0m, 32m, 0, 0m, 5, 0, 32m, 1, new DateTime(2026, 9, 8, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 70000L },
                    { 71, 0m, 41m, 0, 0m, 1, 769, 60.22m, 1, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 71000L },
                    { 72, 0m, 39m, 0, 0m, 2, 797, 58.92m, 1, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 72000L },
                    { 73, 2.68m, 37m, 16076, 0.53m, 3, 802, 57.05m, 1, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 73000L },
                    { 74, 2.26m, 41m, 13534, 1.47m, 4, 781, 60.53m, 1, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 74000L },
                    { 75, 3.21m, 38m, 19230, 0m, 5, 831, 58.78m, 1, new DateTime(2026, 9, 8, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 75000L },
                    { 76, 2.05m, 32m, 12282, 3.82m, 1, 34, 32.85m, 1, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 76000L },
                    { 77, 3.71m, 27m, 22275, 4.84m, 2, 0, 27m, 1, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 77000L },
                    { 78, 0m, 28m, 0, 4.27m, 3, 19, 28.48m, 1, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 78000L },
                    { 79, 0m, 29m, 0, 0m, 4, 12, 29.3m, 1, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 79000L },
                    { 80, 1.17m, 27m, 7016, 0m, 5, 5, 27.12m, 1, new DateTime(2026, 9, 8, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 80000L },
                    { 81, 0m, 22m, 0, 3.47m, 1, 0, 22m, 1, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 81000L },
                    { 82, 2.71m, 20m, 16231, 0.58m, 2, 0, 20m, 1, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 82000L },
                    { 83, 0.37m, 20m, 2233, 1.67m, 3, 0, 20m, 1, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 83000L },
                    { 84, 0.42m, 18m, 2523, 0m, 4, 0, 18m, 1, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 84000L },
                    { 85, 0.91m, 20m, 5474, 0.35m, 5, 0, 20m, 1, new DateTime(2026, 9, 8, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 85000L },
                    { 86, 0m, 27m, 0, 0.1m, 1, 30, 27.75m, 1, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 86000L },
                    { 87, 3.39m, 29m, 20317, 4.45m, 2, 0, 29m, 1, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 87000L },
                    { 88, 0m, 31m, 0, 4.43m, 3, 28, 31.7m, 1, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 88000L },
                    { 89, 0m, 31m, 0, 0m, 4, 9, 31.22m, 1, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 89000L },
                    { 90, 3.35m, 30m, 20084, 0.2m, 5, 0, 30m, 1, new DateTime(2026, 9, 9, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 90000L },
                    { 91, 0m, 37m, 0, 0.77m, 1, 756, 55.9m, 1, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 91000L },
                    { 92, 0m, 42m, 0, 0m, 2, 779, 61.48m, 1, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 92000L },
                    { 93, 0.04m, 42m, 210, 0m, 3, 775, 61.38m, 1, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 93000L },
                    { 94, 3.85m, 40m, 23129, 0m, 4, 797, 59.92m, 1, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 94000L },
                    { 95, 2.93m, 38m, 17585, 0m, 5, 777, 57.42m, 1, new DateTime(2026, 9, 9, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 95000L },
                    { 96, 2.28m, 30m, 13680, 0m, 1, 36, 30.9m, 1, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 96000L },
                    { 97, 0.64m, 32m, 3855, 0m, 2, 49, 33.22m, 1, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 97000L },
                    { 98, 0m, 28m, 0, 0.22m, 3, 32, 28.8m, 1, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 98000L },
                    { 99, 0.34m, 28m, 2040, 0m, 4, 0, 28m, 1, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 99000L },
                    { 100, 0m, 30m, 0, 0m, 5, 0, 30m, 1, new DateTime(2026, 9, 9, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 100000L },
                    { 101, 0m, 19m, 0, 0m, 1, 0, 19m, 1, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 101000L },
                    { 102, 0m, 17m, 0, 2.7m, 2, 0, 17m, 1, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 102000L },
                    { 103, 1.37m, 17m, 8203, 2.23m, 3, 45, 18.12m, 1, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 103000L },
                    { 104, 0m, 17m, 0, 4.38m, 4, 0, 17m, 1, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 104000L },
                    { 105, 0m, 21m, 0, 4.65m, 5, 0, 21m, 1, new DateTime(2026, 9, 9, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 105000L },
                    { 106, 0m, 31m, 0, 2.96m, 1, 22, 31.55m, 1, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 106000L },
                    { 107, 0m, 29m, 0, 2.22m, 2, 0, 29m, 1, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 107000L },
                    { 108, 3.23m, 27m, 19405, 2.36m, 3, 0, 27m, 1, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 108000L },
                    { 109, 0m, 31m, 0, 0.02m, 4, 19, 31.48m, 1, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 109000L },
                    { 110, 0m, 31m, 0, 0m, 5, 31, 31.78m, 1, new DateTime(2026, 9, 10, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 110000L },
                    { 111, 0m, 42m, 0, 4.75m, 1, 787, 61.68m, 1, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 111000L },
                    { 112, 3.33m, 40m, 19986, 4.86m, 2, 750, 58.75m, 1, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 112000L },
                    { 113, 2.31m, 41m, 13855, 3.4m, 3, 756, 59.9m, 1, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 113000L },
                    { 114, 3.11m, 39m, 18680, 0m, 4, 793, 58.82m, 1, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 114000L },
                    { 115, 1.27m, 41m, 7612, 0m, 5, 808, 61.2m, 1, new DateTime(2026, 9, 10, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 115000L },
                    { 116, 2.16m, 29m, 12966, 1.33m, 1, 0, 29m, 1, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 116000L },
                    { 117, 3.81m, 27m, 22843, 0m, 2, 0, 27m, 1, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 117000L },
                    { 118, 2.08m, 28m, 12502, 2.29m, 3, 8, 28.2m, 1, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 118000L },
                    { 119, 0m, 28m, 0, 3.11m, 4, 32, 28.8m, 1, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 119000L },
                    { 120, 0.11m, 28m, 683, 3.35m, 5, 46, 29.15m, 1, new DateTime(2026, 9, 10, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 120000L },
                    { 121, 3.68m, 19m, 22106, 0m, 1, 15, 19.38m, 1, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 121000L },
                    { 122, 2.55m, 19m, 15273, 0m, 2, 27, 19.68m, 1, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 122000L },
                    { 123, 0m, 20m, 0, 2.27m, 3, 0, 20m, 1, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 123000L },
                    { 124, 0m, 18m, 0, 0m, 4, 41, 19.02m, 1, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 124000L },
                    { 125, 2.7m, 19m, 16181, 0m, 5, 0, 19m, 1, new DateTime(2026, 9, 10, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 125000L },
                    { 126, 0m, 28m, 0, 2.32m, 1, 43, 29.08m, 1, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 126000L },
                    { 127, 3.53m, 30m, 21151, 0m, 2, 22, 30.55m, 1, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 127000L },
                    { 128, 0.68m, 28m, 4065, 0m, 3, 8, 28.2m, 1, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 128000L },
                    { 129, 1.36m, 29m, 8149, 0m, 4, 12, 29.3m, 1, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 129000L },
                    { 130, 0m, 28m, 0, 0m, 5, 0, 28m, 1, new DateTime(2026, 9, 11, 1, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 130000L },
                    { 131, 0m, 38m, 0, 4.78m, 1, 827, 58.68m, 1, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 131000L },
                    { 132, 0m, 40m, 0, 0m, 2, 835, 60.88m, 1, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 132000L },
                    { 133, 0m, 38m, 0, 0.82m, 3, 766, 57.15m, 1, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 133000L },
                    { 134, 0m, 37m, 0, 0m, 4, 844, 58.1m, 1, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 134000L },
                    { 135, 0m, 38m, 0, 0m, 5, 837, 58.92m, 1, new DateTime(2026, 9, 11, 7, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 135000L },
                    { 136, 0m, 28m, 0, 1.28m, 1, 39, 28.98m, 1, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 136000L },
                    { 137, 0m, 31m, 0, 0m, 2, 13, 31.32m, 1, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 137000L },
                    { 138, 3.47m, 29m, 20826, 0m, 3, 38, 29.95m, 1, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 138000L },
                    { 139, 3.74m, 29m, 22450, 0m, 4, 38, 29.95m, 1, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 139000L },
                    { 140, 3.95m, 30m, 23709, 3.02m, 5, 0, 30m, 1, new DateTime(2026, 9, 11, 13, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110), 140000L }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_RepairVerifications_Inverters_InverterId",
                table: "RepairVerifications",
                column: "InverterId",
                principalTable: "Inverters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
