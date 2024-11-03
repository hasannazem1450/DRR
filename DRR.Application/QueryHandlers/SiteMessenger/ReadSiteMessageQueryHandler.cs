using DRR.Application.Contracts.Queries.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Application.Contracts.Services.SiteMessenger;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Profile.Message;

public class ReadMessageQueryHandler : IQueryHandler<ReadSiteMessageQuery, ReadSiteMessageQueryResponse>
{
    private readonly ISiteMessageRepository _messageRepository;
    private readonly ISiteMessageService _messageService;

    public ReadMessageQueryHandler(ISiteMessageRepository messageRepository, ISiteMessageService messageService)
    {
        _messageRepository = messageRepository;
        _messageService = messageService;
    }

    public async Task<ReadSiteMessageQueryResponse> Execute(ReadSiteMessageQuery query,
        CancellationToken cancellationToken)
    {
        var message = await _messageRepository.ReadById(query.Id);

        var result = new ReadSiteMessageQueryResponse
        {
            Dto = await _messageService.ConvertToDto(message)
        };

        return result;
    }

}