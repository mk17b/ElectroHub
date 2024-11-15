namespace ElectroHub.Domain.ChargePoint;

public record ChargingHubDto
{
    public Guid ChargingHubId { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }
}