using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Domain.Profile;
using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.SiteMessenger
{
    public interface ISiteMessageRepository : IRepository
    {
        Task<SiteMessage> ReadById(int id);
        Task<List<SiteMessage>> ReadAll();
        Task Delete(int id);
        Task Update(SiteMessage message);
        Task Create(SiteMessage message);
        Task<List<SiteMessage>> ReadByUserId(string UserId);

    }
}
