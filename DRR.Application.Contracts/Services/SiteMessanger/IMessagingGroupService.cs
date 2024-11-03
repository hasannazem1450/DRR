using DRR.Framework.Contracts.Markers;
using DRR.Domain.SiteMessenger;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Services.SiteMessenger
{
    public interface IMessagingGroupService : IService
    {
        Task<List<MessagingGroup>> ReadAll();
        Task<MessagingGroup> ReadById(int id);

    }
}
