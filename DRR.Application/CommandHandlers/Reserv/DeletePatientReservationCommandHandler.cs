using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Reserv
{
    internal class DeletePatientReservationCommandHandler : CommandHandler<DeletePatientReservationCommand, DeletePatientReservationCommandResponse>
    {
        private readonly IPatientReservationRepository _prRepository;


        public DeletePatientReservationCommandHandler(IPatientReservationRepository prRepository)
        {
            _prRepository = prRepository;
        }

        public override async Task<DeletePatientReservationCommandResponse> Executor(DeletePatientReservationCommand command)
        {
            await _prRepository.Delete(command.Id);

            return new DeletePatientReservationCommandResponse();
        }
    }
}
