using ElectroHub.Domain.ChargePoint;
using ElectroHub.Infrastructure.Base;
using ElectroHub.Infrastructure.Context;

namespace ElectroHub.Infrastructure.Repositories;

public class ChargePointReservationRepository(ElectroHubDbContext electroHubDbContext)
    : RepositoryBase(electroHubDbContext), IChargePointReservationRepository
{
    public async Task<ChargePointReservation> GetAsync(Guid id)
    {
        return (await ElectroHubDbContext.ChargePointReservations.FindAsync(id))!;
    }

    public async Task DeleteAsync(ChargePointReservation chargePointReservation)
    {
        ElectroHubDbContext.ChargePointReservations.Remove(chargePointReservation);
        await ElectroHubDbContext.SaveChangesAsync();
    }
}