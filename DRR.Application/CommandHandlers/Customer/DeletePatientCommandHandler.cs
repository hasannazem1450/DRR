using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Customer
{
    public class DeletePatientCommandHandler : CommandHandler<DeletePatientCommand, DeletePatientCommandResponse>
    {
        private readonly IPatientRepository _patientRepository;


        public DeletePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public override async Task<DeletePatientCommandResponse> Executor(DeletePatientCommand command)
        {
            await _patientRepository.Delete(command.Id);

            return new DeletePatientCommandResponse();
        }
    }
}
