using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Profile
{
    public interface IUserProfileRepository : IRepository
    {
        Task<List<UserProfile>> ReadAll();
        Task<List<UserProfile>> ReadByUserId(Guid userid);
        Task Delete(int id);
        Task Create(UserProfile userProfile);
        Task<List<UserProfile>> GetUserProfilesByFilter(string? name, string? managerName, SmeType? smeType, string? smeFromDate, string? smeToDate, int perPage, int page);
        Task<int> GetFilteredUserProfilesCount(string? name, string? managerName, SmeType? smeType, string? smeFromDate, string? smeToDate);
    }
}
