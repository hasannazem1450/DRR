using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.SiteMessanger
{
    public interface ISiteMessageImageRepository : IRepository
    {
        Task<SiteMessageImage> ReadById(int id);

        Task<List<SiteMessageImage>> ReadBySiteMessageId(int siteMessageId);

        Task Update(SiteMessageImage siteMessageImage);

        Task Create(SiteMessageImage siteMessageImage);
    }
}
