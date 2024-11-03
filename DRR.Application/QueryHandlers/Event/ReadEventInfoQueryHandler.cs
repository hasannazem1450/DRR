using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Services.Event;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Event;

public class ReadEventInfoQueryHandler : IQueryHandler<ReadEventInfoQuery, ReadEventInfoQueryResponse>
{
    private readonly IEventInfoRepository _eventInfoRepository;
    private readonly IEventInfoService _eventInfoService;

    public ReadEventInfoQueryHandler(IEventInfoRepository eventInfoRepository, IEventInfoService eventInfoService)
    {
        _eventInfoRepository = eventInfoRepository;
        _eventInfoService = eventInfoService;
    }

    public async Task<ReadEventInfoQueryResponse> Execute(ReadEventInfoQuery query, CancellationToken cancellationToken)
    {
        var eventInfo = await _eventInfoRepository.ReadEventInfoById(query.Id);

        var result = new ReadEventInfoQueryResponse
        {
            Data = await _eventInfoService.ConvertToDto(eventInfo)
        };

        return result;
    }
}