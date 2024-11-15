namespace ElectroHub.Domain.ChargePoint;

public interface IChargingHubRepository
{
    Task<List<ChargingHubDto>> GetAllActiveAsync();
    Task<ChargingHub?> GetByIdAsync(Guid chargingHubId);
    Task<Guid> GetChargingHubIdAsync(string chargingHubName);
    Task PersistAsync(ChargingHub chargingHub);
}