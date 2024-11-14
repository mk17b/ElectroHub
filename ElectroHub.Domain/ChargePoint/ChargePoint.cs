using ElectroHub.Domain.Common.Base;

namespace ElectroHub.Domain.ChargePoint;

public class ChargePoint : EntityBase
{
    protected ChargePoint()
    {
    }

    public ChargePoint(Guid id, string spotNumber, ChargingHub chargingHub)
    {
        SpotNumber = spotNumber;
        ChargingHub = chargingHub;
        ChargePointReservations = new List<ChargePointReservation>();
    }

    public string SpotNumber { get; init; }
    public virtual ChargingHub ChargingHub { get; init; }
    public virtual ICollection<ChargePointReservation> ChargePointReservations { get; init; }

    public ChargePointReservation Reserve(User user, DateTime reservationDate)
    {
        var chargePointReservation = new ChargePointReservation(reservationDate, this, user);

        ChargePointReservations.Add(chargePointReservation);

        return chargePointReservation;
    }

    public bool IsAlreadyReserved(DateTime reservationDate)
    {
        return ChargePointReservations.Any(x => x.ReservationDate == reservationDate);
    }
}