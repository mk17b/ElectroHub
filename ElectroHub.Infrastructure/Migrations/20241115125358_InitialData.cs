using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        private static readonly string SPLAU_ID = Guid.NewGuid().ToString();
        private static readonly string FINESTRELLES_ID = Guid.NewGuid().ToString();
        private static readonly string CAMPNOU_ID = Guid.NewGuid().ToString();
        private static readonly string TORREAGBAR_ID = Guid.NewGuid().ToString();
        private static readonly string WBARCELONA_ID = Guid.NewGuid().ToString();
        private static readonly string ESTACIOSANTS_ID = Guid.NewGuid().ToString();
        private static readonly string EROSKI_ID = Guid.NewGuid().ToString();

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlScript = $@"
            INSERT INTO ChargingHubs (Id, Name, Address, IsActive) 
            VALUES 
                ('{SPLAU_ID}', 'Centre Comercial Splau', 'Av. del Baix Llobregat', 1),
                ('{FINESTRELLES_ID}', 'Centre Comercial Finestrelles', 'Carrer de Sant Mateu 9', 1),
                ('{CAMPNOU_ID}', 'Spotify Camp Nou', 'Travessera de les Corts', 1),
                ('{TORREAGBAR_ID}', 'Torre Agbar', 'Av. Diagonal 211', 1),
                ('{WBARCELONA_ID}', 'W Barcelona', 'Pl. Rosa dels Vents 1', 1),
                ('{ESTACIOSANTS_ID}', 'Estació de Sants', 'Pl. dels Paisos Catalans 1', 1),
                ('{EROSKI_ID}', 'Llobregat Centre', 'Ctra. Esplugues', 0);

            INSERT INTO ChargePoints (Id, SpotNumber, ChargingHubId) 
            VALUES 
                ('{Guid.NewGuid()}', 'C-001', '{SPLAU_ID}'),
                ('{Guid.NewGuid()}', 'C-002', '{SPLAU_ID}'),
                ('{Guid.NewGuid()}', 'C-003', '{SPLAU_ID}'),
                ('{Guid.NewGuid()}', 'C-004', '{SPLAU_ID}'),
                ('{Guid.NewGuid()}', 'C-005', '{SPLAU_ID}'),
                ('{Guid.NewGuid()}', 'C-006', '{SPLAU_ID}'),
                ('{Guid.NewGuid()}', 'C-007', '{SPLAU_ID}'),
                ('{Guid.NewGuid()}', 'C-008', '{SPLAU_ID}'),
                
                ('{Guid.NewGuid()}', 'C-001', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-002', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-003', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-004', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-005', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-006', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-007', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-008', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-009', '{FINESTRELLES_ID}'),
                ('{Guid.NewGuid()}', 'C-010', '{FINESTRELLES_ID}'),
                
                ('{Guid.NewGuid()}', 'C-001', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-002', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-003', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-004', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-005', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-006', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-007', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-008', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-009', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-010', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-011', '{CAMPNOU_ID}'),
                ('{Guid.NewGuid()}', 'C-012', '{CAMPNOU_ID}'),

                ('{Guid.NewGuid()}', 'C-001', '{TORREAGBAR_ID}'),
                ('{Guid.NewGuid()}', 'C-002', '{TORREAGBAR_ID}'),
                ('{Guid.NewGuid()}', 'C-003', '{TORREAGBAR_ID}'),
                ('{Guid.NewGuid()}', 'C-004', '{TORREAGBAR_ID}'),
                ('{Guid.NewGuid()}', 'C-005', '{TORREAGBAR_ID}'),
                ('{Guid.NewGuid()}', 'C-006', '{TORREAGBAR_ID}'),
                
                ('{Guid.NewGuid()}', 'C-001', '{WBARCELONA_ID}'),
                ('{Guid.NewGuid()}', 'C-002', '{WBARCELONA_ID}'),
                ('{Guid.NewGuid()}', 'C-003', '{WBARCELONA_ID}'),
                ('{Guid.NewGuid()}', 'C-004', '{WBARCELONA_ID}'),
                ('{Guid.NewGuid()}', 'C-005', '{WBARCELONA_ID}'),
                ('{Guid.NewGuid()}', 'C-006', '{WBARCELONA_ID}'),
                
                ('{Guid.NewGuid()}', 'C-001', '{ESTACIOSANTS_ID}'),
                ('{Guid.NewGuid()}', 'C-002', '{ESTACIOSANTS_ID}'),
                ('{Guid.NewGuid()}', 'C-003', '{ESTACIOSANTS_ID}'),
                ('{Guid.NewGuid()}', 'C-004', '{ESTACIOSANTS_ID}'),
                ('{Guid.NewGuid()}', 'C-005', '{ESTACIOSANTS_ID}'),
                ('{Guid.NewGuid()}', 'C-006', '{ESTACIOSANTS_ID}'),
                ('{Guid.NewGuid()}', 'C-007', '{ESTACIOSANTS_ID}'),
                ('{Guid.NewGuid()}', 'C-008', '{ESTACIOSANTS_ID}'),
                
                ('{Guid.NewGuid()}', 'C-001', '{EROSKI_ID}'),
                ('{Guid.NewGuid()}', 'C-002', '{EROSKI_ID}'),
                ('{Guid.NewGuid()}', 'C-003', '{EROSKI_ID}'),
                ('{Guid.NewGuid()}', 'C-004', '{EROSKI_ID}');
            ";

            migrationBuilder.Sql(sqlScript);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sqlScript = $@"
            DELETE FROM ChargePoints WHERE ChargingHubId IN ('{SPLAU_ID}', '{FINESTRELLES_ID}', '{CAMPNOU_ID}', '{TORREAGBAR_ID}', '{WBARCELONA_ID}', '{ESTACIOSANTS_ID}', '{EROSKI_ID}');
            DELETE FROM ChargingHubs WHERE Id IN ('{SPLAU_ID}', '{FINESTRELLES_ID}', '{CAMPNOU_ID}', '{TORREAGBAR_ID}', '{WBARCELONA_ID}', '{ESTACIOSANTS_ID}', '{EROSKI_ID}');
            ";

            migrationBuilder.Sql(sqlScript);
        }
    }
}