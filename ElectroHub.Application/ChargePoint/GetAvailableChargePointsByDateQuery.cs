namespace ElectroHub.Application.ChargePoint;

public class GetAvailableChargePointsByDateQuery(string chargingHubName, DateTime? date)
{
    public string ChargingHubName { get; init; } = chargingHubName;
    public DateTime? Date { get; init; } = date;
}