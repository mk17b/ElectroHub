namespace ElectroHub.Domain.ChargePoint;

public interface IChargePointReservationReadOnlyRepository
{
    Task<List<ChargePointReservationDto>> GetUserChargePointReservationsAsync(Guid chargingHubId, Guid userId);
    Task<List<ChargePointReservationDto>> GetChargePointsByDateAsync(Guid chargingHubId, DateTime? reservationDate);
}