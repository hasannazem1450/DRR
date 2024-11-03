using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Services.Event;
using DRR.Domain.Event;
using DRR.Utilities.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.Application.Services.Event;

public class EventAttenderService : IEventAttenderService
{
    public async Task<List<EventAttenderDto>> ConvertToDto(List<EventAttender> eventAttenders)
    {
        var result = eventAttenders.Select(s => ConvertToDto(s).Result).ToList();

        return result;
    }

    public async Task<EventAttenderDto> ConvertToDto(EventAttender eventAttender)
    {
        var result = new EventAttenderDto
        {
            Id = eventAttender.Id,
            SmeProfileId = eventAttender.SmeProfileId,
            SmeProfileName = eventAttender.SmeProfile?.SmeName ?? "",
            EventInfoId = eventAttender.EventInfoId,
            EventInfoName = eventAttender.EventInfo?.Name ?? "",
            EventAttenderType = (int)eventAttender.EventAttenderType,
            EventAttenderTypeName = eventAttender.EventAttenderType.GetDescription(),
            ContactNumber = eventAttender.ContactNumber
        };

        return result;
    }
}