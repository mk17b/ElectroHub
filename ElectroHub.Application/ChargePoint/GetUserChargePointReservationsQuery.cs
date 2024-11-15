namespace ElectroHub.Application.ChargePoint;

public class GetUserChargePointReservationsQuery(string chargingHubName, Guid userId)
{
    public string ChargingHubName { get; init; } = chargingHubName;
    public Guid UserId { get; init; } = userId;
}