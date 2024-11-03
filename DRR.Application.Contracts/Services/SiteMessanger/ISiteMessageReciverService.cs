using DRR.Framework.Contracts.Markers;
using DRR.Domain.SiteMessenger;
using DRR.Application.Contracts.Commands.SiteMessenger;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Services.SiteMessenger
{
    public interface ISiteMessageReciverService : IService
    {
        Task<List<SiteMessageReciver>> ReadAll();
        Task<SiteMessageReciver> ReadById(int id);

    }
}
