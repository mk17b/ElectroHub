using ElectroHub.Domain.ChargePoint;
using ElectroHub.Infrastructure.Base;
using ElectroHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ElectroHub.Infrastructure.Repositories;

public class ChargingHubRepository(ElectroHubDbContext electroHubDbContext)
    : RepositoryBase(electroHubDbContext), IChargingHubRepository
{
    public async Task<ChargingHub> GetActiveAsync()
    {
        return await ElectroHubDbContext.ChargingHubs.SingleAsync(x => x.IsActive);
    }

    public async Task PersistAsync(ChargingHub chargingHub)
    {
        ElectroHubDbContext.ChargingHubs.Attach(chargingHub);
        await ElectroHubDbContext.SaveChangesAsync();
    }
}