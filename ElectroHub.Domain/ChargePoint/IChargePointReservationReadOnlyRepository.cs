namespace ElectroHub.Domain.ChargePoint;

public interface IChargePointReservationReadOnlyRepository
{
    Task<List<ChargePointReservationDto>> GetUserChargePointReservationsAsync(Guid userId);
    Task<List<ChargePointReservationDto>> GetChargePointsByDateAsync(DateTime? reservationDate);
}