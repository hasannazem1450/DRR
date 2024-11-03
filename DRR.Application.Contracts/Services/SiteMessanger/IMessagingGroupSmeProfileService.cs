using DRR.Framework.Contracts.Markers;
using DRR.Domain.SiteMessenger;
using DRR.Application.Contracts.Commands.SiteMessenger;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Services.SiteMessenger
{
    public interface IMessagingGroupSmeProfileService : IService
    {
        Task<List<MessagingGroupSmeProfile>> ReadAll();
        Task<MessagingGroupSmeProfile> ReadById(int id);

    }
}
