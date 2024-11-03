using DRR.Application.Contracts.Queries.Profile.UserProfile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Profile.UserProfile
{
  
    public class ReadAllUserProfileQueryHandler : IQueryHandler<ReadAllUserProfileQuery, ReadAllUserProfileQueryResponse>
    {
        private readonly IUserProfileService _userProfileService;

        public ReadAllUserProfileQueryHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public async Task<ReadAllUserProfileQueryResponse> Execute(ReadAllUserProfileQuery query,
            CancellationToken cancellationToken)
        {
            var ra = await _userProfileService.ReadAll();

            var result = new ReadAllUserProfileQueryResponse()
            {
                List = ra
            };

            return result;
        }
    }
}
