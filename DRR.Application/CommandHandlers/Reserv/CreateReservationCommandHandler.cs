using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Reserv
{
    public class CreateReservationCommandHandler : CommandHandler<CreateReservationCommand, CreateReservationCommandResponse>
    {
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public override async Task<CreateReservationCommandResponse> Executor(CreateReservationCommand command)
        {
            var reserve = new Domain.Reserv.Reservation(command.ReservationDate, command.ReservationTime, command.VisitTypeId, command.DoctorTreatmentCenterId, command.VisitCostId, command.CancleTimeDuration,command.TotalTurnCount);

            await _reservationRepository.Create(reserve);

            return new CreateReservationCommandResponse();
        }
    }
}
