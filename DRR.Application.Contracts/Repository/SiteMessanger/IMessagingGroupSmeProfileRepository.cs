using DRR.Application.Contracts.Commands.Profile.UserProfile;
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
    public interface IMessagingGroupSmeProfileRepository : IRepository
    {
        Task<MessagingGroupSmeProfile> ReadById(int id);
        Task<List<MessagingGroupSmeProfile>> ReadAll();
        Task Delete(int id);
        Task Create(MessagingGroupSmeProfile messagingGroupSmeProfile);
        Task Update(MessagingGroupSmeProfile messagingGroupSmeProfile);
    }
}
