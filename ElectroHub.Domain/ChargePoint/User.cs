namespace ElectroHub.Domain.ChargePoint;

public record User
{
    protected User()
    {
    }

    public User(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("The provided ID is empty. Please ensure a valid user ID is supplied.");

        UserId = userId;
    }

    public Guid UserId { get; }
}