using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Profile
{
    public interface IUserProfileService : IService
    {
        Task<List<UserProfileDto>> ReadAll();
        Task<List<UserProfileDto>> ReadByUserId(Guid userid);
        Task<List<UserProfileDto>> ConvertToDto(List<UserProfile> userProfiles);
        Task<UserProfileDto> ConvertToDto(UserProfile userProfile);
        Task<List<UserProfileDto>> ConvertToMessageDto(List<UserProfile> userProfiles);
        Task<UserProfileDto> ConvertToMessageDto(UserProfile userProfile);

    }
}
