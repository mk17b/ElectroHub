using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        private static readonly string CHARGINGHUB_ID = Guid.NewGuid().ToString();
        
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlScript = $@"
            INSERT INTO ChargingHubs (Id, Address, IsActive) 
            VALUES ('{CHARGINGHUB_ID}', 'Centre Comercial Splau - Carrer del Progrés 4', 1);
            
            INSERT INTO ChargePoints (Id, SpotNumber, ChargingHubId) 
            VALUES ('{Guid.NewGuid()}', 'C-001', '{CHARGINGHUB_ID}'),
                   ('{Guid.NewGuid()}', 'C-002', '{CHARGINGHUB_ID}'),
                   ('{Guid.NewGuid()}', 'C-003', '{CHARGINGHUB_ID}'),
                   ('{Guid.NewGuid()}', 'C-004', '{CHARGINGHUB_ID}'),
                   ('{Guid.NewGuid()}', 'C-005', '{CHARGINGHUB_ID}'),
                   ('{Guid.NewGuid()}', 'C-006', '{CHARGINGHUB_ID}'),
                   ('{Guid.NewGuid()}', 'C-007', '{CHARGINGHUB_ID}'),
                   ('{Guid.NewGuid()}', 'C-008', '{CHARGINGHUB_ID}')
            ";

            migrationBuilder.Sql(sqlScript);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlScript = $@"
            DELETE FROM ChargePoints WHERE ChargingHubId = '{CHARGINGHUB_ID}';
            DELETE FROM ChargingHubs WHERE Id = '{CHARGINGHUB_ID}';
            ";

            migrationBuilder.Sql(sqlScript);
        }
    }
}
