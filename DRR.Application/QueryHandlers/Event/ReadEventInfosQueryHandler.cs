using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Services.Event;
using DRR.Framework.Contracts.Markers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Event;

public class ReadEventInfosQueryHandler : IQueryHandler<ReadEventInfosQuery, ReadEventInfosQueryResponse>
{
    private readonly IEventInfoRepository _eventInfoRepository;
    private readonly IEventInfoService _eventInfoService;

    public ReadEventInfosQueryHandler(IEventInfoRepository eventInfoRepository, IEventInfoService eventInfoService)
    {
        _eventInfoRepository = eventInfoRepository;
        _eventInfoService = eventInfoService;
    }

    public async Task<ReadEventInfosQueryResponse> Execute(ReadEventInfosQuery query,
        CancellationToken cancellationToken)
    {
        var eventInfos = await _eventInfoRepository.ReadEventInfos();

        var result = new ReadEventInfosQueryResponse
        {
            List = await _eventInfoService.ConvertToDto(eventInfos.ToList())
        };

        return result;
    }
}