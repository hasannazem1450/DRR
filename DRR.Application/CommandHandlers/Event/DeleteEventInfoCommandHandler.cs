using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.News;
using DRR.Application.Contracts.Repository.Profile.Member;
using DRR.Domain.Profile.Member;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Event
{
    public class DeleteEventInfoCommandHandler : CommandHandler<DeleteEventInfoCommand, DeleteEventInfoCommandResponse>
    {

        private readonly IEventInfoRepository _eventRepository;


        public DeleteEventInfoCommandHandler(IEventInfoRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public override async Task<DeleteEventInfoCommandResponse> Executor(DeleteEventInfoCommand command)
        {
            await _eventRepository.Delete(command.Id);

            return new DeleteEventInfoCommandResponse();
        }
    }
}
