using ElectroHub.Domain.Common.Base;

namespace ElectroHub.Domain.ChargePoint;

public class ChargePointReservation : EntityBase
{
    protected ChargePointReservation()
    {
    }

    public ChargePointReservation(DateTime reservationDate, ChargePoint chargePoint, User user)
    {
        ReservationDate = reservationDate;
        ChargePoint = chargePoint;
        User = user;
    }

    public DateTime ReservationDate { get; init; }
    public virtual ChargePoint ChargePoint { get; init; }
    public virtual User User { get; init; }

    public bool IsRemovable(Guid userId, DateTime reservationDate)
    {
        if (User.UserId != userId) return false;
        return ReservationDate >= reservationDate;
    }
}