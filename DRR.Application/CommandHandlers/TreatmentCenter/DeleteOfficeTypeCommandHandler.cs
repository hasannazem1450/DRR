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
    public class DeleteOfficeTypeCommandHandler : CommandHandler<DeleteOfficeTypeCommand, DeleteOfficeTypeCommandResponse>
    {

        private readonly IOfficeTypeRepository _otRepository;


        public DeleteOfficeTypeCommandHandler(IOfficeTypeRepository otRepository)
        {
            _otRepository = otRepository;
        }

        public override async Task<DeleteOfficeTypeCommandResponse> Executor(DeleteOfficeTypeCommand command)
        {
            await _otRepository.Delete(command.Id);

            return new DeleteOfficeTypeCommandResponse();
        }
    }
}
