using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Repository.Event;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Event;

public class UpdateEventInfoCommandHandler : CommandHandler<UpdateEventInfoCommand, UpdateEventInfoCommandResponse>
{
    private readonly IEventInfoRepository _eventInfoRepository;

    public UpdateEventInfoCommandHandler(IEventInfoRepository eventInfoRepository)
    {
        _eventInfoRepository = eventInfoRepository;
    }


    public override async Task<UpdateEventInfoCommandResponse> Executor(UpdateEventInfoCommand command)
    {
        var eventInfo = await _eventInfoRepository.ReadEventInfoById(command.Id);

        eventInfo.Update(command.Name, command.Photo, command.StartDate, command.EndDate, command.Periority,
            command.ProvinceId);

        await _eventInfoRepository.Update(eventInfo);

        return new UpdateEventInfoCommandResponse();
    }
}