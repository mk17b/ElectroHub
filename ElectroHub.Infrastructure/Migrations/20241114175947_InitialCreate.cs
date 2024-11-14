using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChargingHubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingHubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChargePoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpotNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ChargingHubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargePoints_ChargingHubs_ChargingHubId",
                        column: x => x.ChargingHubId,
                        principalTable: "ChargingHubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChargePointReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChargePointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargePointReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargePointReservations_ChargePoints_ChargePointId",
                        column: x => x.ChargePointId,
                        principalTable: "ChargePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargePointReservations_ChargePointId",
                table: "ChargePointReservations",
                column: "ChargePointId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargePoints_ChargingHubId",
                table: "ChargePoints",
                column: "ChargingHubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargePointReservations");

            migrationBuilder.DropTable(
                name: "ChargePoints");

            migrationBuilder.DropTable(
                name: "ChargingHubs");
        }
    }
}
