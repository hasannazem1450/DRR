﻿using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Domain.Reserv;
using DRR.Domain.TreatmentCenters;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Reserv
{
    public class ReservationService:IReservationService
    {
        public async Task<List<ReservationDto>> ConvertToDto(List<Reservation> reservations)
        {
            var result = reservations.Select(s => ConvertToDto(s).Result).ToList();

            return result;

        }

        public async Task<ReservationDto> ConvertToDto(Reservation reservation)
        {
            var result = new ReservationDto
            {

                Id = reservation.Id,
                ReservationDate = DatetimeExtension.NumberToDate(reservation.ReservationDate),
                DoctorTreatmentCenterId = reservation.DoctorTreatmentCenterId,
                CancleTimeDuration = reservation.CancleTimeDuration,
                ReservationTime = reservation.ReservationTime,
                VisitCostId = reservation.VisitCostId,
                DoctorTreatmentCenter = reservation.DoctorTreatmentCenter,
                VisitCost = reservation.VisitCost
            };

            return result;
        }

    }
}
