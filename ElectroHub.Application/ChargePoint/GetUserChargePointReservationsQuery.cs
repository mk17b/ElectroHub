namespace ElectroHub.Application.ChargePoint;

public class GetUserChargePointReservationsQuery(Guid chargingHubId, Guid userId)
{
    public Guid ChargingHubId { get; init; } = chargingHubId;
    public Guid UserId { get; init; } = userId;
}