namespace ElectroHub.Application.ChargePoint;

public class GetAvailableChargePointsByDateQuery(DateTime? date)
{
    public DateTime? Date { get; init; } = date;
}