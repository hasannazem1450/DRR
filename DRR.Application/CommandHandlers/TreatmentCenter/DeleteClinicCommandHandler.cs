using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.TreatmentCenter
{
    public class DeleteClinicCommandHandler : CommandHandler<DeleteClinicCommand, DeleteClinicCommandResponse>
    {

        private readonly IClinicRepository _clinicRepository;


        public DeleteClinicCommandHandler(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public override async Task<DeleteClinicCommandResponse> Executor(DeleteClinicCommand command)
        {
            await _clinicRepository.Delete(command.Id);

            return new DeleteClinicCommandResponse();
        }
    }
}
