using DRR.Application.Contracts.Queries.Profile.UserProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Profile.UserProfile
{
    public class ReadAllUserProfileFilterQueryHandler : IQueryHandler<ReadAllUserProfilesFilterQuery, ReadAllUserProfilesFilterQueryResponse>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserProfileService _userProfileService;

        public ReadAllUserProfileFilterQueryHandler(IUserProfileRepository userProfileRepository, IUserProfileService userProfileService)
        {
            _userProfileRepository = userProfileRepository;
            _userProfileService = userProfileService;
        }

        public async Task<ReadAllUserProfilesFilterQueryResponse> Execute(ReadAllUserProfilesFilterQuery query,
            CancellationToken cancellationToken)
        {
            var userProfiles = await _userProfileRepository.GetUserProfilesByFilter(query.Name, query.ManagerName, query.Type, query.FromDate, query.ToDate, query.PerPage, query.Page);
            var totalCount = await _userProfileRepository.GetFilteredUserProfilesCount(query.Name, query.ManagerName, query.Type, query.FromDate, query.ToDate);

            var result = new ReadAllUserProfilesFilterQueryResponse()
            {
                List = await _userProfileService.ConvertToMessageDto(userProfiles),
                PageNumber = query.Page,
                TotalCount = totalCount
            };

            return result;
        }
    }
}