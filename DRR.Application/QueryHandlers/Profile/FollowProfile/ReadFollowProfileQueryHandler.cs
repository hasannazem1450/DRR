using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Queries.Profile.FollowProfile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;


namespace DRR.Application.QueryHandlers.Profile.FollowProfile
{
    public class ReadFollowProfileQueryHandler : IQueryHandler<ReadFollowProfileQuery, ReadFollowProfileQueryResponse>
    {

        private readonly IFollowProfileService _followProfileService;

        public ReadFollowProfileQueryHandler(IFollowProfileService followProfileService)
        {
            _followProfileService = followProfileService;
        }

        public async Task<ReadFollowProfileQueryResponse> Execute(ReadFollowProfileQuery query,
            CancellationToken cancellationToken)
        {
            var followProfile = await _followProfileService.Read();

            var result = new ReadFollowProfileQueryResponse();

            foreach (var item in followProfile)
            {
                var dto = new FollowProfileDto()
                {
                    Id = item.Id,
                    FollowProfileId = item.FollowProfileId,
                    MyProfileId = item.MyProfileId,
                    FollowProfileLogo = item.FollowProfileLogo,
                    FollowProfileName = item.FollowProfileName,

                };


                result.List.Add(dto);
            }

            return result;
        }
    }
}
