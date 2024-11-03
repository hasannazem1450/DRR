using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Services.Event;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Event;

public class
    ReadFilteredEventInfosQueryHandler : IQueryHandler<ReadFilteredEventInfosQuery, ReadFilteredEventInfosQueryResponse>
{
    private readonly IEventInfoRepository _eventInfoRepository;
    private readonly IEventInfoService _eventInfoService;

    public ReadFilteredEventInfosQueryHandler(IEventInfoRepository eventInfoRepository,
        IEventInfoService eventInfoService)
    {
        _eventInfoRepository = eventInfoRepository;
        _eventInfoService = eventInfoService;
    }

    public async Task<ReadFilteredEventInfosQueryResponse> Execute(ReadFilteredEventInfosQuery query,
        CancellationToken cancellationToken)
    {
        var eventInfos = await _eventInfoRepository.ReadEventInfos();

        var eventInfosDto = await _eventInfoService.ConvertToDto(eventInfos);

        if (query.Name.IsNotNullOrEmpty())
            eventInfosDto = await _eventInfoService.FilterByName(eventInfosDto, query.Name);

        if (query.ProvinceId.HasValue)
            eventInfosDto = await _eventInfoService.FilterByProvince(eventInfosDto, query.ProvinceId.Value);

        if (query.States != null && query.States.Any())
            eventInfosDto = await _eventInfoService.FilterByState(eventInfosDto, query.States.Select(s => (EventInfoState)s).ToList());

        if (query.FromDate.HasValue && query.ToDate.HasValue)
            eventInfosDto =
                await _eventInfoService.FilterByDate(eventInfosDto, query.FromDate.Value, query.ToDate.Value);

        var result = new ReadFilteredEventInfosQueryResponse
        {
            List = eventInfosDto
        };

        return result;
    }
}