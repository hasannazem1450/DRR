using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Framework.Contracts.Abstracts;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Reservation
{
    public class UpdateReservationCommandHandler : CommandHandler<UpdateReservationCommand, UpdateReservationCommandResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITurnRepository _turnRepository;
        public UpdateReservationCommandHandler(IReservationRepository reservationRepository, ITurnRepository turnRepository)
        {
            _reservationRepository = reservationRepository;
            _turnRepository = turnRepository;
        }

        public override async Task<UpdateReservationCommandResponse> Executor(UpdateReservationCommand command)
        {
            var pturns = await _turnRepository.GetTurnsByReservationId(command.Id);
            if (pturns != null)
            {
                foreach (var turn in pturns)
                {
                    if (turn.IsFree == false)
                        throw new Exception("به دلیل ثبت نوبت توسط بیمار رزرو قابل تغییر نیست");
                }
            }


            var reserve = await _reservationRepository.ReadReservationById(command.Id);

            reserve.Update(DatetimeExtension.DateToNumber(command.ReservationDate.ToString()), command.ReservationTime, command.DoctorTreatmentCenterId, command.VisitCostId, command.CancleTimeDuration,command.TotalTurnCount);
            await _reservationRepository.Update(reserve);


            return new UpdateReservationCommandResponse();
        }
    }
}
