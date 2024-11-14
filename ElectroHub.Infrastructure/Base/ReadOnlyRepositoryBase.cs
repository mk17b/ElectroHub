namespace ElectroHub.Infrastructure.Base;

public class ReadOnlyRepositoryBase(string connectionString)
{
    protected string ConnectionString { get; init; } = connectionString;
}