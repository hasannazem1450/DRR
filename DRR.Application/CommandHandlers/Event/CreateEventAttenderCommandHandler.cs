using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Repository.Event;
using DRR.Domain.Event;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Event;

public class CreateEventAttenderCommandHandler : CommandHandler<CreateEventAttenderCommand, CreateEventAttenderCommandResponse>
{
    private readonly IEventAttenderRepository _eventAttenderRepository;

    public CreateEventAttenderCommandHandler(IEventAttenderRepository eventAttenderRepository)
    {
        _eventAttenderRepository = eventAttenderRepository;
    }

    public override async Task<CreateEventAttenderCommandResponse> Executor(CreateEventAttenderCommand command)
    {
        var eventAttender = new EventAttender(command.SmeProfileId, command.EventInfoId, (EventAttenderType)command.EventAttenderType,
            command.ContactNumber);

        await _eventAttenderRepository.Create(eventAttender);

        return new CreateEventAttenderCommandResponse();
    }
}