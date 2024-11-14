using ElectroHub.Application.ChargePoint;
using ElectroHub.Infrastructure.Helpers;

namespace ElectroHub.WebUI.Common.Configuration;

internal static class ServiceCollectionExtensions
{
    internal static void RegisterApplication(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddScoped<ChargePointService>();
        services.RegisterInfrastructureServices(appSettings.SqlConnectionString);
    }
}