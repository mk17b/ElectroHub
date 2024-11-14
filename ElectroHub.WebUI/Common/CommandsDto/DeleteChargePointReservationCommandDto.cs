using ElectroHub.Application.ChargePoint;

namespace ElectroHub.WebUI.Common.CommandsDto;

public record DeleteChargePointReservationCommandDto
{
    public Guid UserId { get; init; }
    public Guid ReservationId { get; init; }
    public DateTime ReservationDate { get; init; }

    public DeleteChargePointReservationCommand ToCommand()
    {
        return new DeleteChargePointReservationCommand(UserId, ReservationId, ReservationDate);
    }
}