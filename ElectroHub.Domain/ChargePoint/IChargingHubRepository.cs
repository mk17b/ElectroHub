namespace ElectroHub.Domain.ChargePoint;

public interface IChargingHubRepository
{
    Task<List<ChargingHubDto>> GetAllActiveAsync();
    Task<ChargingHub?> GetByIdAsync(Guid id);
    Task PersistAsync(ChargingHub chargingHub);
}