
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;


namespace DRR.Application.CommandHandlers.Profile.Message
{
    
    public class DeleteMessagingGrouCommandHandler : CommandHandler<DeleteMessagingGroupCommand, DeleteMessagingGroupCommandResponse>
    {

        private readonly IMessagingGroupRepository _messageRepository;

        public DeleteMessagingGrouCommandHandler(IMessagingGroupRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public override async Task<DeleteMessagingGroupCommandResponse> Executor(DeleteMessagingGroupCommand command)
        {

            await _messageRepository.Delete(command.Id);

            return new DeleteMessagingGroupCommandResponse();
        }
    }
}
