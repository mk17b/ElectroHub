﻿using ElectroHub.Domain.ChargePoint;
using ElectroHub.Domain.Common.Enums;

namespace ElectroHub.Application.ChargePoint;

public class ChargePointService(
    IChargePointReservationReadOnlyRepository chargePointReservationReadOnlyRepository,
    IChargePointReservationRepository chargePointReservationRepository,
    IChargingHubRepository chargingHubRepository)
{
    public async Task<List<ChargePointReservationDto>> InvokeAsync(GetUserChargePointReservationsQuery query)
    {
        var chargingHubId = await chargingHubRepository.GetChargingHubIdAsync(query.ChargingHubName);
        var chargePointReservations =
            await chargePointReservationReadOnlyRepository.GetUserChargePointReservationsAsync(chargingHubId,
                query.UserId);
        return chargePointReservations;
    }

    public async Task<List<ChargePointReservationDto>> InvokeAsync(GetAvailableChargePointsByDateQuery query)
    {
        var chargingHubId = await chargingHubRepository.GetChargingHubIdAsync(query.ChargingHubName);
        var chargePoints =
            await chargePointReservationReadOnlyRepository.GetChargePointsByDateAsync(chargingHubId, query.Date);
        return chargePoints;
    }

    public async Task<ReservationStatus> InvokeAsync(CreateChargePointReservationCommand command)
    {
        var chargingHubId = await chargingHubRepository.GetChargingHubIdAsync(command.ChargingHubName);
        var chargingHub = await chargingHubRepository.GetByIdAsync(chargingHubId);
        var result = chargingHub!.TryReserve(command.UserId, command.ReservationDate, command.SpotNumber);

        if (result.Flag == ReservationStatus.Success)
            await chargingHubRepository.PersistAsync(chargingHub);

        return result.Flag;
    }

    public async Task InvokeAsync(DeleteChargePointReservationCommand command)
    {
        var chargePoint = await chargePointReservationRepository.GetAsync(command.ReservationId);

        if (chargePoint.IsRemovable(command.UserId, command.ReservationDate))
            await chargePointReservationRepository.DeleteAsync(chargePoint);
        else
            throw new Exception($"Charge point reservation with id {command.ReservationId} not found");
    }
}