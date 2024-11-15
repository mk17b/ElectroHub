namespace ElectroHub.Application.ChargePoint;

public class CreateChargePointReservationCommand(Guid chargingHubId, Guid userId, DateTime reservationDate, string spotNumber)
{
    public Guid ChargingHubId { get; init; } = chargingHubId;
    public Guid UserId { get; init; } = userId;
    public DateTime ReservationDate { get; init; } = reservationDate;
    public string SpotNumber { get; init; } = spotNumber;
}