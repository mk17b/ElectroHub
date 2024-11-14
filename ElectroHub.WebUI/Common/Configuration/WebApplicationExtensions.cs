using ElectroHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ElectroHub.WebUI.Common.Configuration;

public static class WebApplicationExtensions
{
    public static void AutomateDbMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();
        var electroHubDbContext = scope.ServiceProvider.GetRequiredService<ElectroHubDbContext>();
        electroHubDbContext.Database.Migrate();
    }
}