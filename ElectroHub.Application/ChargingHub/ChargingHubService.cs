using ElectroHub.Domain.ChargePoint;

namespace ElectroHub.Application.ChargingHub;

public class ChargingHubService(IChargingHubRepository chargingHubRepository)
{
    public async Task<List<ChargingHubDto>> GetAllChargingHubsAsync()
    {
        var chargingHubs = await chargingHubRepository.GetAllActiveAsync();
        return chargingHubs;
    }
}