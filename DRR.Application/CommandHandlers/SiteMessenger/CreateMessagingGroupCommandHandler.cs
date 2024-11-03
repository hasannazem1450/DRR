using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger
{
    public class CreateMessagingGroupCommandHandler : CommandHandler<CreateMessagingGroupCommand, CreateMessagingGroupCommandResponse>
    {
        private readonly IMessagingGroupRepository _MessagingGroupRepository;

        public CreateMessagingGroupCommandHandler(IMessagingGroupRepository MessagingGroupRepository)
        {
            _MessagingGroupRepository = MessagingGroupRepository;
        }

        public override async Task<CreateMessagingGroupCommandResponse> Executor(CreateMessagingGroupCommand command)
        {
            var Message = new Domain.SiteMessenger.MessagingGroup(command.name) { };
            
            await _MessagingGroupRepository.Create(Message);

            return new CreateMessagingGroupCommandResponse()
            {
                Id = Message.Id
            };
        }
    }
}
