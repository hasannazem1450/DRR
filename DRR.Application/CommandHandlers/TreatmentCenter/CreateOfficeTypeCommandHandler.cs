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
    public class CreateOfficeTypeCommandHandler : CommandHandler<CreateOfficeTypeCommand, CreateOfficeTypeCommandResponse>
    {
        private readonly IOfficeTypeRepository _eventRepository;


        public CreateOfficeTypeCommandHandler(IOfficeTypeRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public override async Task<CreateOfficeTypeCommandResponse> Executor(CreateOfficeTypeCommand command)
        {
            var ev = new OfficeType(command.Type);

            await _eventRepository.Create(ev);

            return new CreateOfficeTypeCommandResponse();
        }
    }
}