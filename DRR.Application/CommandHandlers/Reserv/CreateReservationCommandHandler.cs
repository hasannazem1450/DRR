﻿using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Utilities.Extensions;

namespace DRR.Application.CommandHandlers.Reserv
{
    public class CreateReservationCommandHandler : CommandHandler<CreateReservationCommand, CreateReservationCommandResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITurnRepository _turnRepository;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository, ITurnRepository turnRepository)
        {
            _reservationRepository = reservationRepository;
            _turnRepository = turnRepository;
        }

        public override async Task<CreateReservationCommandResponse> Executor(CreateReservationCommand command)
        {
            var reserve = new Domain.Reserv.Reservation(DatetimeExtension.DateToNumber(command.ReservationDate.ToString()), command.ReservationTime, command.DoctorTreatmentCenterId, command.CancleTimeDuration, command.VisitCostId, command.TotalTurnCount);

            await _reservationRepository.Create(reserve);
            Turn tr;
            DateTime stime = DateTime.ParseExact(command.ReservationTime, "HH:mm",
                                       CultureInfo.InvariantCulture);
            DateTime etime = stime.AddMinutes(command.Timeofturnsinlimit);
            for (int x = 0; x < command.TotalTurnCount; x++)
            {

                if (x % command.Numberofturnsinlimit == 0)
                {
                    if (x == 0)
                        stime = stime.AddMinutes(0);
                    else
                        stime = stime.AddMinutes(command.Timeofturnsinlimit);

                    etime = stime.AddMinutes(command.Timeofturnsinlimit);
                }



                //tr = new Turn(x + 1, stime.ToShortTimeString(), etime.ToShortTimeString(), true, 5, reserve.Id);
                tr = new Turn(x + 1, stime.ToString("HH:mm"), etime.ToShortTimeString(), true, 5, reserve.Id);
                await _turnRepository.Create(tr);
            }
            return new CreateReservationCommandResponse();
        }
    }
}
