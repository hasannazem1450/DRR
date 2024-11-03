using DRR.Application.Contracts.Queries.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Application.Contracts.Services.SiteMessenger;
using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Profile.Message;

public class ReadRecivedMessageQueryHandler : IQueryHandler<ReadRecivedMessageQuery, ReadRecivedMessageQueryResponse>
{
    private readonly ISiteMessageRepository _siteMessageRepository;
    private readonly ISiteMessageService _messageService;

    public ReadRecivedMessageQueryHandler(ISiteMessageRepository siteMessageRepository, ISiteMessageService messageService)
    {
        _siteMessageRepository = siteMessageRepository;
        _messageService = messageService;
    }

    public async Task<ReadRecivedMessageQueryResponse> Execute(ReadRecivedMessageQuery query,
        CancellationToken cancellationToken)
    {
        var siteMessage = await _siteMessageRepository.ReadByUserId(query.UserId.ToString());

        var result = new ReadRecivedMessageQueryResponse
        {
            List = await _messageService.ConvertToDto(siteMessage)
        };

        return result;
    }
}