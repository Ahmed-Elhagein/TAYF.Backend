using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExpectedPowerToRepairVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExpectedPowerKw",
                table: "RepairVerifications",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstallationDate",
                value: new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstallationDate",
                value: new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstallationDate",
                value: new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstallationDate",
                value: new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstallationDate",
                value: new DateTime(2023, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstallationDate",
                value: new DateTime(2023, 1, 14, 22, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedPowerKw",
                table: "RepairVerifications");

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstallationDate",
                value: new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstallationDate",
                value: new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstallationDate",
                value: new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstallationDate",
                value: new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inverters",
                keyColumn: "Id",
                keyValue: 5,
                column: "InstallationDate",
                value: new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstallationDate",
                value: new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
