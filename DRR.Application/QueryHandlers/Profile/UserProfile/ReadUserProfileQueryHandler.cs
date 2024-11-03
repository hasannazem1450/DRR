using DRR.Application.Contracts.Queries.Profile.UserProfile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Markers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace DRR.Application.QueryHandlers.Profile.UserProfile
{
    public class ReadUserProfileQueryHandler : IQueryHandler<ReadUserProfileQuery, ReadUserProfileQueryResponse>
    {
        private readonly IUserProfileService _userProfileService;

        public ReadUserProfileQueryHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public async Task<ReadUserProfileQueryResponse> Execute(ReadUserProfileQuery query,
            CancellationToken cancellationToken)
        {
            var users = await _userProfileService.ReadByUserId(query.Metadata.UserId);

            var result = new ReadUserProfileQueryResponse()
            {
                List = users.OrderByDescending(x => x.Id).ToList()
        };

            return result;
        }
}
}
