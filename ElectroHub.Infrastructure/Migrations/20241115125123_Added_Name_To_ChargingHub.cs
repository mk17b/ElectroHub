using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Name_To_ChargingHub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ChargingHubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ChargingHubs");
        }
    }
}
