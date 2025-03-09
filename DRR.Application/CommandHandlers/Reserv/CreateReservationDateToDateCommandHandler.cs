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
using Microsoft.AspNetCore.Components.Forms;

namespace DRR.Application.CommandHandlers.Reserv
{
    public class CreateReservationDateToDateCommandHandler : CommandHandler<CreateReservationDateToDateCommand, CreateReservationCommandResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITurnRepository _turnRepository;

        public CreateReservationDateToDateCommandHandler(IReservationRepository reservationRepository, ITurnRepository turnRepository)
        {
            _reservationRepository = reservationRepository;
            _turnRepository = turnRepository;
        }

        public override async Task<CreateReservationCommandResponse> Executor(CreateReservationDateToDateCommand command)
        {
            var gdate = DateTime.Now;
            var sgdate = (DateTime)command.ReservationFromDate.ToString().ToGregorianDateTime();
            var egdate = (DateTime)command.ReservationToDate.ToString().ToGregorianDateTime();
            DateTime internalsgdate;

            for (DateTime i = sgdate; i <= egdate; i = i.AddDays(7))
            {
                for (int weekday = 0; weekday < 7; weekday++)
                {
                    if (command.DayArray[weekday] == true)
                    {
                        if (i >= gdate)
                        {
                            internalsgdate = i.AddDays(weekday);
                            if (internalsgdate <= egdate)
                            {
                                var reserve = new Domain.Reserv.Reservation(DatetimeExtension.DateToNumber(internalsgdate.ToPersianString().ToString()), command.ReservationTime, command.DoctorTreatmentCenterId, command.CancleTimeDuration, command.VisitCostId, command.TotalTurnCount);

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



                                    tr = new Turn(x + 1, stime.ToShortTimeString(), etime.ToShortTimeString(), true, 5, reserve.Id);
                                    await _turnRepository.Create(tr);
                                }
                            }
                        }
                    }
                }

            }
                
            
            return new CreateReservationCommandResponse();
        }
    }
}
