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
    public class UpdateClinicTypeCommandHandler : CommandHandler<UpdateClinicTypeCommand, UpdateClinicTypeCommandResponse>
    {
        private readonly IClinicTypeRepository _ClinicTypeRepository;

        public UpdateClinicTypeCommandHandler(IClinicTypeRepository ClinicTypeRepository)
        {
            _ClinicTypeRepository = ClinicTypeRepository;
        }


        public override async Task<UpdateClinicTypeCommandResponse> Executor(UpdateClinicTypeCommand command)
        {
            var ClinicType = await _ClinicTypeRepository.ReadClinicTypeById(command.Id);

            ClinicType.Update(command.Type);

            await _ClinicTypeRepository.Update(ClinicType);

            return new UpdateClinicTypeCommandResponse();
        }
    }
}