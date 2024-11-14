namespace ElectroHub.Domain.ChargePoint;

public interface IChargingHubRepository
{
    Task<ChargingHub> GetActiveAsync();
    Task PersistAsync(ChargingHub chargingHub);
}