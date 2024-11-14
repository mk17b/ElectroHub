using ElectroHub.Domain.ChargePoint;
using ElectroHub.Infrastructure.Context;
using ElectroHub.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroHub.Infrastructure.Helpers;

public static class ServiceCollectionExtensions
{
    public static void RegisterInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddTransient<IChargingHubRepository, ChargingHubRepository>();
        services.AddTransient<IChargePointReservationRepository, ChargePointReservationRepository>();
        services.AddTransient<IChargePointReservationReadOnlyRepository>(_ =>
            new ChargePointReservationReadOnlyRepository(connectionString));

        services.AddScoped(_ => new ElectroHubDbContext(connectionString));
    }
}