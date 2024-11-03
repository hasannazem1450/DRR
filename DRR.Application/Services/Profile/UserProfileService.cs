using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Domain.Profile;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.Application.Services.Profile
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<List<UserProfileDto>> ReadAll()
        {
            var read = await _userProfileRepository.ReadAll();

            var result = read.Select(item => new UserProfileDto()
            {
                Id = item.Id,
                UserName = item.User.UserName,
                ProfileLogo = item.SmeProfile.Logo,
                ProfileName = item.SmeProfile.SmeName,
                SmeProfileTypeName = item.SmeProfile.SmeType.GetDescription(),
                ManagerName = item.SmeProfile.ManagerName,
                RankId = item.SmeProfile.SmeRankId ?? 1,
                UserId = Guid.Parse(item.UserId),
                ProfileId = item.SmeProfile.Id
            })
                 .ToList();

            return result;
        }

        public async Task<List<UserProfileDto>> ReadByUserId(Guid userid)
        {
            var readbyuserid = await _userProfileRepository.ReadByUserId(userid);
            PersianCalendar pc = new PersianCalendar();
           
            var result = readbyuserid.Select(item => new UserProfileDto()
            {
                Id = item.Id,
                UserName = item.User.UserName,
                ProfileLogo = item.SmeProfile.Logo,
                ProfileName = item.SmeProfile.SmeName,
                SmeProfileTypeName = item.SmeProfile.SmeType.GetDescription(),
                ManagerName = item.SmeProfile.ManagerName,
                RankId = item.SmeProfile.SmeRankId ?? 1,
                UserId = Guid.Parse(item.UserId),
                ProfileId = item.SmeProfile.Id,
                LastModify = string.Format("{0}/{1}/{2}", pc.GetYear(item.SmeProfile.ModifiedAt ?? item.SmeProfile.CreatedAt), pc.GetMonth(item.SmeProfile.ModifiedAt ?? item.SmeProfile.CreatedAt), pc.GetDayOfMonth(item.SmeProfile.ModifiedAt ?? item.SmeProfile.CreatedAt)),
            })
                .ToList();

            return result;
        }


        public async Task<List<UserProfileDto>> ConvertToDto(List<UserProfile> userProfiles)
        {
            var result = userProfiles.Select(s => ConvertToDto(s).Result).ToList();

            return result;
        }

        public async Task<UserProfileDto> ConvertToDto(UserProfile userProfile)
        {
            var result = new UserProfileDto
            {
                Id = userProfile.Id,
                ProfileId = userProfile.SmeProfileId,
                ProfileLogo = userProfile.SmeProfile.Logo,
                UserName = userProfile.User.UserName,
                ProfileName = userProfile.SmeProfile.SmeName,
                SmeProfileTypeName = userProfile.SmeProfile.SmeType.GetDescription(),
                UserId = Guid.Parse(userProfile.UserId),
            };

            return result;
        }

        public async Task<List<UserProfileDto>> ConvertToMessageDto(List<UserProfile> userProfiles)
        {
            var result = userProfiles.Select(s => ConvertToMessageDto(s).Result).ToList();

            return result;
        }

        public async Task<UserProfileDto> ConvertToMessageDto(UserProfile userProfile)
        {
            PersianCalendar pc = new PersianCalendar();
            string lastModify = string.Format("{0}/{1}/{2}", pc.GetYear(userProfile.SmeProfile.ModifiedAt?? userProfile.SmeProfile.CreatedAt), pc.GetMonth(userProfile.SmeProfile.ModifiedAt ?? userProfile.SmeProfile.CreatedAt), pc.GetDayOfMonth(userProfile.SmeProfile.ModifiedAt ?? userProfile.SmeProfile.CreatedAt));
            
            var result = new UserProfileDto
            {
                Id = userProfile.Id,
                ProfileId = userProfile.SmeProfileId,
                ProfileLogo = userProfile.SmeProfile.Logo,
                UserName = userProfile.User.UserName,
                ProfileName = userProfile.SmeProfile.SmeName,
                SmeProfileTypeName = userProfile.SmeProfile.SmeType.GetDescription(),
                ManagerName = userProfile.SmeProfile.ManagerName,
                RankId = userProfile.SmeProfile.SmeRankId ?? 1,
                UserId = Guid.Parse(userProfile.UserId),
                LastModify = lastModify,
            };

            return result;
        }
    }
}
