using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.TreatmentCenter
{
    public class CreateClinicTypeCommandHandler : CommandHandler<CreateClinicTypeCommand, CreateClinicTypeCommandResponse>
    {
        private readonly IClinicTypeRepository _clinicTypeRepository;


        public CreateClinicTypeCommandHandler(IClinicTypeRepository clinicTypeRepository)
        {
            _clinicTypeRepository = clinicTypeRepository;
        }

        public override async Task<CreateClinicTypeCommandResponse> Executor(CreateClinicTypeCommand command)
        {
            var ct = new ClinicType(command.Type);

            await _clinicTypeRepository.Create(ct);

            return new CreateClinicTypeCommandResponse();
        }
    }
}