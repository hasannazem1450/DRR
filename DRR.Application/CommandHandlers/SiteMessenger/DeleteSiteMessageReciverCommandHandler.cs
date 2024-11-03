using DRR.Application.CommandHandlers.SmeProfile.Exceptions;
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger;

public class DeleteSiteMessagereciverCommandHandler : CommandHandler<DeleteSiteMessageReciverCommand, DeleteSiteMessageReciverCommandResponse>
{
    private readonly ISiteMessageReciverRepository _siteMessageReciverRepository;

    public DeleteSiteMessagereciverCommandHandler(ISiteMessageReciverRepository siteMessageReciverRepository)
    {
        _siteMessageReciverRepository = siteMessageReciverRepository;
    }

    public override async Task<DeleteSiteMessageReciverCommandResponse> Executor(DeleteSiteMessageReciverCommand command)
    {
        var siteMessageReciver = await _siteMessageReciverRepository.ReadById(command.Id);

        if (siteMessageReciver == null)
            throw new SmeProfileNotExistException();

        await _siteMessageReciverRepository.Delete(siteMessageReciver.Id);

        return new DeleteSiteMessageReciverCommandResponse();
    }


}