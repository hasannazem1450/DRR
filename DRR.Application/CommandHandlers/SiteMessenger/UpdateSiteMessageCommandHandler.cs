using DRR.Application.CommandHandlers.SmeProfile.Exceptions;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger;

public class UpdateSiteMessageCommandHandler : CommandHandler<UpdateSiteMessageCommand, UpdateSiteMessageCommandResponse>
{
    private readonly ISiteMessageRepository _siteMessageRepository;

    public UpdateSiteMessageCommandHandler(ISiteMessageRepository siteMessageRepository)
    {
        _siteMessageRepository = siteMessageRepository;
    }

    public override async Task<UpdateSiteMessageCommandResponse> Executor(UpdateSiteMessageCommand command)
    {
        var message = await _siteMessageRepository.ReadById(command.Id);

        if (message == null)
            throw new SmeProfileNotExistException();

        message.Update(command.MessageSubject, command.MessageBody, command.MessageType , command.MessageImage);

        await _siteMessageRepository.Update(message);

        return new UpdateSiteMessageCommandResponse()
        {
            Id = message.Id
        };
    }
}