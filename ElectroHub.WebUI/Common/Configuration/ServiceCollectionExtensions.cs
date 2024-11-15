using ElectroHub.Application.ChargePoint;
using ElectroHub.Application.ChargingHub;
using ElectroHub.Infrastructure.Helpers;

namespace ElectroHub.WebUI.Common.Configuration;

internal static class ServiceCollectionExtensions
{
    internal static void RegisterApplication(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddScoped<ChargePointService>();
        services.AddScoped<ChargingHubService>();
        services.RegisterInfrastructureServices(appSettings.SqlConnectionString);
    }
}