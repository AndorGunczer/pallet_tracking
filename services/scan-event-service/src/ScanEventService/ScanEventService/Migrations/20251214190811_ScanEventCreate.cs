using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScanEventService.Migrations
{
    /// <inheritdoc />
    public partial class ScanEventCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "PalletLocations",
            //     columns: table => new
            //     {
            //         Id = table.Column<Guid>(type: "uuid", nullable: false),
            //         LocationName = table.Column<string>(type: "text", nullable: false),
            //         LocationDescription = table.Column<string>(type: "text", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_PalletLocations", x => x.Id);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "Pallets",
            //     columns: table => new
            //     {
            //         Id = table.Column<Guid>(type: "uuid", nullable: false),
            //         Name = table.Column<string>(type: "text", nullable: false),
            //         Description = table.Column<string>(type: "text", nullable: false),
            //         PalletLocationId = table.Column<Guid>(type: "uuid", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Pallets", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Pallets_PalletLocations_PalletLocationId",
            //             column: x => x.PalletLocationId,
            //             principalTable: "PalletLocations",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateTable(
                name: "ScanEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScannerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PalletLocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Payload = table.Column<JsonElement>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScanEvents_PalletLocations_PalletLocationId",
                        column: x => x.PalletLocationId,
                        principalTable: "PalletLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScanEvents_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Pallets_PalletLocationId",
            //     table: "Pallets",
            //     column: "PalletLocationId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_ScanEvents_PalletId",
            //     table: "ScanEvents",
            //     column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanEvents_PalletLocationId",
                table: "ScanEvents",
                column: "PalletLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScanEvents");

            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "PalletLocations");
        }
    }
}
