using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger
{
    public class CreateSiteMessageCommandHandler : CommandHandler<CreateSiteMessageCommand, CreateSiteMessageCommandResponse>
    {
        private readonly ISiteMessageRepository _siteMessageRepository;

        public CreateSiteMessageCommandHandler(ISiteMessageRepository siteMessageRepository)
        {
            _siteMessageRepository = siteMessageRepository;
        }

        public override async Task<CreateSiteMessageCommandResponse> Executor(CreateSiteMessageCommand command)
        {
            var Message = new Domain.SiteMessenger.SiteMessage(command.senderUserId , command.MessageSubject, command.MessageBody, command.MessageType ,command.MessageImage) { };
            
            await _siteMessageRepository.Create(Message);

            return new CreateSiteMessageCommandResponse()
            {
                Id = Message.Id
            };
        }
    }
}
