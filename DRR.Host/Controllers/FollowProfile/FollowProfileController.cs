using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Queries.Profile.FollowProfile;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.FollowProfile
{
    public class FollowProfileController : MainController
    {
        public FollowProfileController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = " خواندن علاقه مندی های یک کاربر ")]
        [HttpGet("read-FollowProfile")]
        public async Task<IActionResult> ReadSmeProfileFollows([FromQuery] ReadFollowProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadFollowProfileQuery, ReadFollowProfileQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  افزودن پزشک به علاقه مندی ")]
        [HttpPost("create-FollowProfile")]
        public async Task<IActionResult> CreateFollow(CreateFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateFollowProfileCommand, CreateFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  افزودن مقاله به علاقه مندی ")]
        [HttpPost("create-FollowProfile")]
        public async Task<IActionResult> CreateArticleFollow(CreateFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateFollowProfileCommand, CreateFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [SwaggerOperation(Summary = "  حذف پزشک از علاقه مندی ")]
        [HttpDelete("delete-FollowProfile")]
        public async Task<IActionResult> DeleteFolllow(DeleteFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteFollowProfileCommand, DeleteFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
