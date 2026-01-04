using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScanEventService.Migrations
{
    /// <inheritdoc />
    public partial class ScanEventCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PalletDescription",
                table: "ScanEvents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PalletExternalName",
                table: "ScanEvents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ScanEvents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TargetLocation",
                table: "ScanEvents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ScanEvents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Pallets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Pallets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PalletDescription",
                table: "ScanEvents");

            migrationBuilder.DropColumn(
                name: "PalletExternalName",
                table: "ScanEvents");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ScanEvents");

            migrationBuilder.DropColumn(
                name: "TargetLocation",
                table: "ScanEvents");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ScanEvents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Pallets");
        }
    }
}
