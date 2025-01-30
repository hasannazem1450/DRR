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
    public class UpdateOfficeTypeCommandHandler : CommandHandler<UpdateOfficeTypeCommand, UpdateOfficeTypeCommandResponse>
    {
        private readonly IOfficeTypeRepository _OfficeTypeRepository;

        public UpdateOfficeTypeCommandHandler(IOfficeTypeRepository OfficeTypeRepository)
        {
            _OfficeTypeRepository = OfficeTypeRepository;
        }


        public override async Task<UpdateOfficeTypeCommandResponse> Executor(UpdateOfficeTypeCommand command)
        {
            var OfficeType = await _OfficeTypeRepository.ReadOfficeTypeById(command.Id);

            OfficeType.Update(command.Type);

            await _OfficeTypeRepository.Update(OfficeType);

            return new UpdateOfficeTypeCommandResponse();
        }
    }
}