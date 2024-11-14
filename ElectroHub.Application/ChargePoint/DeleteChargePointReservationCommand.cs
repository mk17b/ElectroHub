namespace ElectroHub.Application.ChargePoint;

public class DeleteChargePointReservationCommand(Guid userId, Guid reservationId, DateTime reservationDate)
{
    public Guid UserId { get; } = userId;
    public Guid ReservationId { get; } = reservationId;
    public DateTime ReservationDate { get; } = reservationDate;
}