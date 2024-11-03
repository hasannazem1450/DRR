using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Application.Contracts.Services.SiteMessenger;
using DRR.Domain.SiteMessenger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Services.Message
{
    public class SiteMessageReciverService : ISiteMessageReciverService
    {
        private readonly ISiteMessageReciverRepository _siteMessageReciverRepository;

        public SiteMessageReciverService(ISiteMessageReciverRepository siteMessageReciverRepository)
        {
            _siteMessageReciverRepository = siteMessageReciverRepository;
        }

        public async Task<List<SiteMessageReciver>> ReadAll()
        {
            var result = await _siteMessageReciverRepository.ReadAll();

            return result;
        }

        public async Task<SiteMessageReciver> ReadById(int id)
        {
            var result = await _siteMessageReciverRepository.ReadById(id);

            return result;
        }

    }
}
