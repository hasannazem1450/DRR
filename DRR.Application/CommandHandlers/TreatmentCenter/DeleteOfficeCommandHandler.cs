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
    public class DeleteOfficeCommandHandler : CommandHandler<DeleteOfficeCommand, DeleteOfficeCommandResponse>
    {

        private readonly IOfficeRepository _officeRepository;


        public DeleteOfficeCommandHandler(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public override async Task<DeleteOfficeCommandResponse> Executor(DeleteOfficeCommand command)
        {
            await _officeRepository.Delete(command.Id);

            return new DeleteOfficeCommandResponse();
        }
    }
}
