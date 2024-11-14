using ElectroHub.Application.ChargePoint;

namespace ElectroHub.WebUI.Common.CommandsDto;

public record CreateChargePointReservationCommandDto
{
    public Guid UserId { get; init; }
    public DateTime ReservationDate { get; init; }
    public string SpotNumber { get; init; } = null!;

    public CreateChargePointReservationCommand ToCommand()
    {
        return new CreateChargePointReservationCommand(UserId, ReservationDate, SpotNumber);
    }
}