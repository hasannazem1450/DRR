using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Queries.Profile.FollowProfile;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.FollowProfile
{
    public class FollowProfileController : MainController
    {
        public FollowProfileController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpGet("read-FollowProfile")]
        public async Task<IActionResult> ReadSmeProfileAds([FromQuery] ReadFollowProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadFollowProfileQuery, ReadFollowProfileQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPost("create-FollowProfile")]
        public async Task<IActionResult> CreateAds(CreateFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateFollowProfileCommand, CreateFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }



        [HttpPut("update-FollowProfile")]
        public async Task<IActionResult> UpdateAds(UpdateFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateFollowProfileCommand, UpdateFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-FollowProfile")]
        public async Task<IActionResult> DeleteAds(DeleteFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteFollowProfileCommand, DeleteFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
