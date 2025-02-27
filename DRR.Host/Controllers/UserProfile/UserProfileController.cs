﻿using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Application.Contracts.Queries.Profile.UserProfile;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using DRR.Application.Contracts.Queries.Profile.SmeTypeReturn;

namespace DRR.Host.Controllers.UserProfile
{
    public class UserProfileController : MainController
    {
        public UserProfileController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-sme-profile")]
        public async Task<IActionResult> CreateUserProfile(CreateUserProfileCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateUserProfileCommand, CreateUserProfileCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [AllowAnonymous]
        [HttpGet("read-all-userprofiles")]
        public async Task<IActionResult> ReadAllUserProfile([FromQuery] ReadAllUserProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllUserProfileQuery, ReadAllUserProfileQueryResponse>(new ReadAllUserProfileQuery(), cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [HttpPost("read-all-userprofiles-filter")]
        public async Task<IActionResult> ReadAllUserProfilesFilter([FromQuery] ReadAllUserProfilesFilterQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllUserProfilesFilterQuery, ReadAllUserProfilesFilterQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [HttpGet("read-userprofiles")]
        public async Task<IActionResult> ReadUserProfileByUserId([FromQuery] ReadUserProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadUserProfileQuery, ReadUserProfileQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [HttpGet("read-userprofiles-type")]
        public async Task<IActionResult> ReadUserProfileByUserId([FromQuery] ReadAllSmeTypesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllSmeTypesQuery, ReadAllSmeTypesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }


    }
}
