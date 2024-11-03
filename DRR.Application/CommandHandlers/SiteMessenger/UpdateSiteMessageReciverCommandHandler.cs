using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Threading.Tasks;


namespace DRR.Application.CommandHandlers.SiteMessenger;

public class UpdateSiteMessagereciverCommandHandler : CommandHandler<UpdateSiteMessageReciverCommand, UpdateSiteMessagereciverCommandResponse>
{
    private readonly ISiteMessageReciverRepository _siteMessagereciverRepository;

    public UpdateSiteMessagereciverCommandHandler(ISiteMessageReciverRepository siteMessagereciverRepository)
    {
        _siteMessagereciverRepository = siteMessagereciverRepository;
    }

    public override async Task<UpdateSiteMessagereciverCommandResponse> Executor(UpdateSiteMessageReciverCommand command)
    {
        SiteMessageReciver smsp = await _siteMessagereciverRepository.ReadById(command.Id);

        if (smsp == null)
            throw new Exception();

        smsp.Update(command.SiteMessageId, command.SmeProfileId, command.IsRead);

        await _siteMessagereciverRepository.Update(smsp);

        return new UpdateSiteMessagereciverCommandResponse();
    }
}