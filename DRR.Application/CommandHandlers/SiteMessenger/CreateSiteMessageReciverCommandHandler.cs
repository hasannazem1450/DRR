using DRR.Application.CommandHandlers.SiteMessenger.Exceptions;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger;

public class CreateSiteMessagereciverCommandHandler : CommandHandler<CreateSiteMessageReciverCommand, CreateSiteMessageReciverCommandResponse>
{
    private readonly ISiteMessageReciverRepository _siteMessageReciverRepository;
    private readonly ISiteMessageRepository _siteMessageRepository;

    public CreateSiteMessagereciverCommandHandler(ISiteMessageReciverRepository siteMessageReciverRepository,
        ISiteMessageRepository siteMessageRepository)
    {
        _siteMessageReciverRepository = siteMessageReciverRepository;
        _siteMessageRepository = siteMessageRepository;
    }

    public override async Task<CreateSiteMessageReciverCommandResponse> Executor(CreateSiteMessageReciverCommand command)
    {
        if (command.SmeProfileIdList == null && command.MessagingGroupIdList == null)
            throw new MessageReciversIsEmptyException();

        var recivers = new List<SiteMessageReciver>();

        foreach (var smeId in command.SmeProfileIdList)
        {
            recivers.Add(new SiteMessageReciver(command.SiteMessageId, smeId, null));
        }

        foreach (var groupId in command.MessagingGroupIdList)
        {
            recivers.Add(new SiteMessageReciver(command.SiteMessageId, null, groupId));
        }

        await _siteMessageReciverRepository.Create(recivers);

        return new CreateSiteMessageReciverCommandResponse();
    }
}