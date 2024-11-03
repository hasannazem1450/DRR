using DRR.Application.Contracts.Commands.Event;
using DRR.Domain.Event;
using DRR.Framework.Contracts.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Event;

public interface IEventAttenderService : IService
{
    Task<List<EventAttenderDto>> ConvertToDto(List<EventAttender> eventAttenders);
    Task<EventAttenderDto> ConvertToDto(EventAttender eventAttender);
}