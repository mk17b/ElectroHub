namespace ElectroHub.Domain.ChargePoint;

public interface IChargingHubRepository
{
    Task<ChargingHub?> GetByIdAsync(Guid id);
    Task PersistAsync(ChargingHub chargingHub);
}