using DRR.Application.CommandHandlers.SmeProfile.Exceptions;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger;

public class UpdateMessagingGroupCommandHandler : CommandHandler<UpdateMessagingGroupCommand, UpdateMessagingGroupCommandResponse>
{
    private readonly IMessagingGroupRepository _MessagingGroupRepository;

    public UpdateMessagingGroupCommandHandler(IMessagingGroupRepository MessagingGroupRepository)
    {
        _MessagingGroupRepository = MessagingGroupRepository;
    }

    public override async Task<UpdateMessagingGroupCommandResponse> Executor(UpdateMessagingGroupCommand command)
    {
        var messaginggroup = await _MessagingGroupRepository.ReadById(command.Id);

        if (messaginggroup == null)
            throw new SmeProfileNotExistException();

        messaginggroup.Update(command.name);

        await _MessagingGroupRepository.Update(messaginggroup);

        return new UpdateMessagingGroupCommandResponse()
        {
            Id = messaginggroup.Id
        };
    }
}