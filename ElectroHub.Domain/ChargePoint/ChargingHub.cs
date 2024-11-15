using ElectroHub.Domain.Common.Base;
using ElectroHub.Domain.Common.Enums;

namespace ElectroHub.Domain.ChargePoint;

public class ChargingHub : EntityBase
{
    protected ChargingHub()
    {
    }

    public ChargingHub(Guid id, string name, string address) : base(id)
    {
        Name = name;
        Address = address;
    }

    public string Name { get; init; }
    public string Address { get; init; }
    public bool IsActive { get; init; }
    public virtual ICollection<ChargePoint> ChargePoints { get; set; }

    public (ReservationStatus Flag, ChargePointReservation chargePointReservation) TryReserve(Guid userId,
        DateTime reservationDate,
        string spotNumber)
    {
        return TryReserveSingle(new User(userId), reservationDate, spotNumber);
    }

    private (ReservationStatus Flag, ChargePointReservation chargePointReservation) TryReserveSingle(User user,
        DateTime reservationDate,
        string spotNumber)
    {
        if (HasAlreadyReserved(user, reservationDate))
            return (ReservationStatus.AlreadyReserved, null)!;
        return PerformChargePointReservation(user, reservationDate, spotNumber);
    }

    private (ReservationStatus Flag, ChargePointReservation chargePointReservation) PerformChargePointReservation(
        User user,
        DateTime reservationDate, string spotNumber)
    {
        var chargePoint = TryReservedSelectedChargePoint(reservationDate, spotNumber);
        return (ReservationStatus.Success, chargePoint.Reserve(user, reservationDate));
    }

    private ChargePoint TryReservedSelectedChargePoint(DateTime reservationDate, string spotNumber)
    {
        return ChargePoints.FirstOrDefault(x => x.SpotNumber == spotNumber && !x.IsAlreadyReserved(reservationDate))!;
    }

    private bool HasAlreadyReserved(User user, DateTime reservationDate)
    {
        return ChargePoints.SelectMany(x => x.ChargePointReservations)
            .Any(x => x.ReservationDate == reservationDate && x.User == user);
    }
}