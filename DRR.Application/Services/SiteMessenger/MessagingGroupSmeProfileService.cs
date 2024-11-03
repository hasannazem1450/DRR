using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Application.Contracts.Services.SiteMessenger;
using DRR.Domain.SiteMessenger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Services.Message
{
    public class MessagingGroupSmeProfileService : IMessagingGroupSmeProfileService
    {
        private readonly IMessagingGroupSmeProfileRepository _messagingGroupSmeProfileRepository;

        public MessagingGroupSmeProfileService(IMessagingGroupSmeProfileRepository messagingGroupSmeProfileRepository)
        {
            _messagingGroupSmeProfileRepository = messagingGroupSmeProfileRepository;
        }

        public async Task<List<MessagingGroupSmeProfile>> ReadAll()
        {
            var result = await _messagingGroupSmeProfileRepository.ReadAll();

            return result;
        }

        public async Task<MessagingGroupSmeProfile> ReadById(int id)
        {
            var result = await _messagingGroupSmeProfileRepository.ReadById(id);

            return result;
        }

        
    }
}
