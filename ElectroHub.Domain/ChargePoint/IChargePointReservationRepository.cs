namespace ElectroHub.Domain.ChargePoint;

public interface IChargePointReservationRepository
{
    Task<ChargePointReservation> GetAsync(Guid id);
    Task DeleteAsync(ChargePointReservation chargePointReservation);
}