using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.News;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDb.Repository.News;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Reservation
{
    public class DeleteReservationCommandHandler : CommandHandler<DeleteReservationCommand, DeleteReservationCommandResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public override async Task<DeleteReservationCommandResponse> Executor(DeleteReservationCommand command)
        {
            await _reservationRepository.Delete(command.Id);

            return new DeleteReservationCommandResponse();
        }
    }
}
