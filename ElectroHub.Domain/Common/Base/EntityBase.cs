namespace ElectroHub.Domain.Common.Base;

public class EntityBase
{
    protected EntityBase()
    {
    }

    protected EntityBase(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("The provided ID is empty. Please ensure a valid user ID is supplied.");

        Id = id;
    }

    public Guid Id { get; init; }
}