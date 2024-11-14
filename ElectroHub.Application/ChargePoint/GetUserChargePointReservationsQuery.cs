namespace ElectroHub.Application.ChargePoint;

public class GetUserChargePointReservationsQuery(Guid userId)
{
    public Guid UserId { get; init; } = userId;
}