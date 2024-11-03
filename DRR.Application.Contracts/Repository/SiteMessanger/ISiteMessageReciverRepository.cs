using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.SiteMessenger
{
    public interface ISiteMessageReciverRepository : IRepository
    {
        Task<SiteMessageReciver> ReadById(int id);
        Task<List<SiteMessageReciver>> ReadAll();
        Task Delete(int id);
        Task Create(SiteMessageReciver messagesme);
        Task Create(List<SiteMessageReciver> siteMessageRecivers);
        Task Update(SiteMessageReciver messagesme);
    }
}