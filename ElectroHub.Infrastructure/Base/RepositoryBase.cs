using ElectroHub.Infrastructure.Context;

namespace ElectroHub.Infrastructure.Base;

public class RepositoryBase(ElectroHubDbContext electroHubDbContext)
{
    protected readonly ElectroHubDbContext ElectroHubDbContext = electroHubDbContext;
}