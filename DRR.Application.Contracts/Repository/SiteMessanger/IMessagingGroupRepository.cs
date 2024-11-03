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
    public interface IMessagingGroupRepository : IRepository
    {
        Task<MessagingGroup> ReadById(int id);
        Task<List<MessagingGroup>> ReadAll();
        Task Delete(int id);
        Task Create(MessagingGroup messagingGroup);
        Task Update(MessagingGroup messagingGroup);
    }
}
