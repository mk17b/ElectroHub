using Dapper;
using ElectroHub.Domain.ChargePoint;
using ElectroHub.Infrastructure.Base;
using Microsoft.Data.SqlClient;

namespace ElectroHub.Infrastructure.Repositories;

public class ChargePointReservationReadOnlyRepository(string connectionString)
    : ReadOnlyRepositoryBase(connectionString), IChargePointReservationReadOnlyRepository
{
    public async Task<List<ChargePointReservationDto>> GetUserChargePointReservationsAsync(Guid chargingHubId, Guid userId)
    {
        var queryString = @"
        ;SELECT 
            cr.Id AS ChargePointReservationId,
            cr.UserId,
            cr.ReservationDate,
            c.SpotNumber AS SpotNumber
        FROM 
            [dbo].[ChargePointReservations] cr
        INNER JOIN 
            [dbo].[ChargePoints] c ON cr.ChargePointId = c.Id
        INNER JOIN
            [dbo].[ChargingHubs] ch ON c.ChargingHubId = ch.Id
        WHERE 
            cr.UserId = @UserId 
            AND ch.Id = @ChargingHubId
            AND cr.ReservationDate >= CAST(GETDATE() AS DATE)
        ORDER BY 
            cr.ReservationDate ASC;
        ";

        await using var db = new SqlConnection(ConnectionString);
        return (await db.QueryAsync<ChargePointReservationDto>(
            queryString, 
            new { UserId = userId, ChargingHubId = chargingHubId }
        )).ToList();
    }

    public async Task<List<ChargePointReservationDto>> GetChargePointsByDateAsync(Guid chargingHubId, DateTime? date)
    {
        var queryString = @"
        ;SELECT 
            NEWID() AS ChargePointReservationId, 
            NULL AS UserId, 
            @Date AS ReservationDate, 
            c.SpotNumber AS SpotNumber
        FROM 
            [dbo].[ChargePoints] c
        INNER JOIN
            [dbo].[ChargingHubs] ch ON c.ChargingHubId = ch.Id
        LEFT JOIN 
            [dbo].[ChargePointReservations] cr ON c.Id = cr.ChargePointId AND cr.ReservationDate = @Date
        WHERE 
            ch.Id = @ChargingHubId
            AND cr.Id IS NULL
        ORDER BY 
            CAST(SUBSTRING(c.SpotNumber, CHARINDEX('-', c.SpotNumber) + 1, LEN(c.SpotNumber)) AS INT);
        ";

        await using var db = new SqlConnection(ConnectionString);
        return (await db.QueryAsync<ChargePointReservationDto>(
            queryString, 
            new { Date = date, ChargingHubId = chargingHubId }
        )).ToList();
    }

}