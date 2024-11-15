using ElectroHub.Domain.ChargePoint;
using ElectroHub.Infrastructure.Base;
using ElectroHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ElectroHub.Infrastructure.Repositories;

public class ChargingHubRepository(ElectroHubDbContext electroHubDbContext)
    : RepositoryBase(electroHubDbContext), IChargingHubRepository
{
    public async Task<List<ChargingHubDto>> GetAllActiveAsync()
    {
        return await ElectroHubDbContext.ChargingHubs
            .Where(x => x.IsActive)
            .Select(x => new ChargingHubDto
            {
                ChargingHubId = x.Id,
                Name = x.Name,
                Address = x.Address
            })
            .ToListAsync();
    }
    
    public async Task<ChargingHub?> GetByIdAsync(Guid id)
    {
        return await ElectroHubDbContext.ChargingHubs.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task PersistAsync(ChargingHub chargingHub)
    {
        ElectroHubDbContext.ChargingHubs.Attach(chargingHub);
        await ElectroHubDbContext.SaveChangesAsync();
    }
}