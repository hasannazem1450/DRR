using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Framework.Contracts.Abstracts;
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
        public UpdateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public override async Task<UpdateReservationCommandResponse> Executor(UpdateReservationCommand command)
        {
            var reserve = await _reservationRepository.ReadReservationById(command.Id);

            reserve.Update(command.ReservationDate, command.ReservationTime, command.VisitTypeId, command.DoctorTreatmentCenterId, command.VisitCostId, command.CancleTimeDuration);
            await _reservationRepository.Update(reserve);


            return new UpdateReservationCommandResponse();
        }
    }
}
