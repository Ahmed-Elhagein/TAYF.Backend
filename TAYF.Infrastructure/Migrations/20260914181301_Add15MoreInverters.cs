using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add15MoreInverters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inverters",
                columns: new[] { "Id", "InstallationDate", "IsActive", "MaxPowerKw", "Model", "PlantId", "SerialNumber" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
