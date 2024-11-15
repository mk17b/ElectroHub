namespace ElectroHub.Application.ChargePoint;

public class CreateChargePointReservationCommand(
    string chargingHubName,
    Guid userId,
    DateTime reservationDate,
    string spotNumber)
{
    public string ChargingHubName { get; init; } = chargingHubName;
    public Guid UserId { get; init; } = userId;
    public DateTime ReservationDate { get; init; } = reservationDate;
    public string SpotNumber { get; init; } = spotNumber;
}