using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using DRR.Application.Contracts.Services.Profile;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DRR.Application.Services.Profile
{
    public class FollowProfileService : IFollowProfileService
    {
        private readonly IFollowProfileRepository _followProfileRepository;

        public FollowProfileService(IFollowProfileRepository followProfileRepository)
        {
            _followProfileRepository = followProfileRepository;
        }

        public async Task<List<FollowProfileDto>> Read()
        {
            var position = await _followProfileRepository.Read();

            var result = new List<FollowProfileDto>();

            foreach (var item in position)
            {
                var dto = new FollowProfileDto()
                {
                    Id = item.Id,
                    FollowProfileId = item.FollowProfileId,
                    MyProfileId = item.MyProfileId,
                    FollowProfileLogo = item.FollowProfileLogo,
                    FollowProfileName = item.FollowProfileName,

                };

                result.Add(dto);
            }

            return result;
        }

        public async Task<FollowProfileDto> ReadById(int id)
        {
            var result = await _followProfileRepository.ReadById(id);

            var dto = new FollowProfileDto()
            {
                Id = result.Id,
                FollowProfileId = result.FollowProfileId,
                MyProfileId = result.MyProfileId,
                FollowProfileLogo = result.FollowProfileLogo,
                FollowProfileName = result.FollowProfileName,

            };

            return dto;
        }
    }
}
