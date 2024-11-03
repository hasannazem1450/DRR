using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Application.Contracts.Services.SiteMessenger;
using DRR.CommandDb.Repository.SiteMessenger;
using DRR.Domain.SiteMessenger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Services.Message
{
    public class MessagingGroupService : IMessagingGroupService
    {
        private readonly IMessagingGroupRepository _messagingGroupRepository;

        public MessagingGroupService(IMessagingGroupRepository messagingGroupRepository)
        {
            _messagingGroupRepository = messagingGroupRepository;
        }

        public async Task<List<MessagingGroup>> ReadAll()
        {
            var result = await _messagingGroupRepository.ReadAll();

            return result;
        }

        public async Task<MessagingGroup> ReadById(int id)
        {
            var result = await _messagingGroupRepository.ReadById(id);

            return result;
        }

    }
}
