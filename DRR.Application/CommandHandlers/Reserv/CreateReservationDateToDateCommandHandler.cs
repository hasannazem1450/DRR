using DRR.Application.Contracts.Commands.News;
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

            var gdate = DateTime.Now.Date;
            var sgdate = (DateTime)command.ReservationFromDate.ToString().ToGregorianDateTime();
            var egdate = (DateTime)command.ReservationToDate.ToString().ToGregorianDateTime();
            //check the reservationdate and turn time in backend
            if (sgdate < gdate.Date || egdate < gdate)
            {
                throw new Exception ("تاریخ شروع و یا تاریخ پایان در گذشته است لطفا دقت کنید");
            }

            DateTime userselectendtime = DateTime.ParseExact(command.ReservationTimeEnd, "HH:mm",
                                                          CultureInfo.InvariantCulture);

            DateTime stimeforcheck = DateTime.ParseExact(command.ReservationTime, "HH:mm",
                                                          CultureInfo.InvariantCulture);
            DateTime etimeforcheck = stimeforcheck.AddMinutes(command.Timeofturnsinlimit);
            for (int x = 0; x < command.TotalTurnCount; x++)
            {

                if (x % command.Numberofturnsinlimit == 0)
                {
                    if (x == 0)
                        stimeforcheck = stimeforcheck.AddMinutes(0);
                    else
                        stimeforcheck = stimeforcheck.AddMinutes(command.Timeofturnsinlimit);

                    etimeforcheck = stimeforcheck.AddMinutes(command.Timeofturnsinlimit);

                    if (etimeforcheck > userselectendtime)
                    {
                        throw new Exception("زمان پایان محاسبه شده بیشتر از زمان پایان " + stimeforcheck.TimeOfDay.ToString() + " است لطفا در محاسبات دقت کنید");
                    }
                } 
            }
            


            DateTime internalsgdate = sgdate;
            //fix the date fo english day of week means day 0 is monday
            int ifixday = 6;
            bool[] NewDayArray = [false, false, false, false, false, false, false];
            foreach (var item in command.DayArray)
            {
                NewDayArray[ifixday] = item;
                ifixday++;
                if (ifixday >= 7)
                    ifixday = 0;


            }
            command.DayArray = NewDayArray;

            for (DateTime i = sgdate; i <= egdate; i = i.AddDays(7))
            {
                for (int weekday = 1; weekday < 8; weekday++)
                {
                    
                    if (command.DayArray[(int)internalsgdate.DayOfWeek] == true)
                    {
                        if (i >= gdate)
                        {
                            
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



                                    tr = new Turn(x + 1, stime.ToString("HH:mm"), etime.ToString("HH:mm"), true, 5, reserve.Id);
                                    await _turnRepository.Create(tr);
                                }
                            }
                        }
                    }
                    internalsgdate = i.AddDays(weekday);
                }

            }


            return new CreateReservationCommandResponse();
        }
    }
}
