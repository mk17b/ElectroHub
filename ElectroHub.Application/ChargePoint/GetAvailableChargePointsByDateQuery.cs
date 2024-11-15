namespace ElectroHub.Application.ChargePoint;

public class GetAvailableChargePointsByDateQuery(Guid chargingHubId, DateTime? date)
{
    public Guid ChargingHubId { get; init; } = chargingHubId;
    public DateTime? Date { get; init; } = date;
}