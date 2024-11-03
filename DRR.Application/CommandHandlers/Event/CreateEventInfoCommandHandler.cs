using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Repository.Event;
using DRR.Domain.Event;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Event;

public class CreateEventInfoCommandHandler : CommandHandler<CreateEventInfoCommand, CreateEventInfoCommandResponse>
{
    private readonly IEventInfoRepository _eventRepository;


    public CreateEventInfoCommandHandler(IEventInfoRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public override async Task<CreateEventInfoCommandResponse> Executor(CreateEventInfoCommand command)
    {
        var ev = new EventInfo(command.Name, command.Photo, command.StartDate, command.EndDate, command.Periority,
            command.ProvinceId);

        await _eventRepository.Create(ev);

        return new CreateEventInfoCommandResponse();
    }
}