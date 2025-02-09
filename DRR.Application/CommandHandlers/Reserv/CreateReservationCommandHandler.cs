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
            var reserve = new Domain.Reserv.Reservation(command.ReservationDate, command.ReservationTime, command.DoctorTreatmentCenterId, command.CancleTimeDuration, command.VisitCostId, command.TotalTurnCount);

            await _reservationRepository.Create(reserve);
            Turn tr;

            for (int x = 0; x < command.TotalTurnCount; x++)
            {
                DateTime stime = DateTime.ParseExact(command.ReservationTime, "HH:mm",
                                       CultureInfo.InvariantCulture);
                DateTime etime = stime.AddMinutes(15);
                if (x % command.Numberofturnsinlimit == 0)
                {
                    stime = stime.AddMinutes((x / command.Numberofturnsinlimit) * command.Timeofturnsinlimit);
                    etime = stime.AddMinutes(command.CancleTimeDuration);
                }



                tr = new Turn(x+1, command.ReservationTime, etime.ToShortTimeString(), true, 5, reserve.Id);
                await _turnRepository.Create(tr);
            }
            return new CreateReservationCommandResponse();
        }
    }
}
