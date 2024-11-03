
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;


namespace DRR.Application.CommandHandlers.Profile.Message
{
    
    public class DeleteMessageCommandHandler : CommandHandler<DeleteSiteMessageCommand, DeleteSiteMessageCommandResponse>
    {

        private readonly ISiteMessageRepository _messageRepository;

        public DeleteMessageCommandHandler(ISiteMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public override async Task<DeleteSiteMessageCommandResponse> Executor(DeleteSiteMessageCommand command)
        {

            await _messageRepository.Delete(command.Id);

            return new DeleteSiteMessageCommandResponse();
        }
    }
}
