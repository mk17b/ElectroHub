namespace ElectroHub.Domain.ChargePoint;

public record ChargePointReservationDto
{
    public Guid ChargePointReservationId { get; init; }
    public Guid UserId { get; init; }
    public DateTime ReservationDate { get; init; }
    public string SpotNumber { get; init; } = null!;
}