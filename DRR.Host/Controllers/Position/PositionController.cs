using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Commands.Profile.Position;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Queries.Profile.Member;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.Position
{
    public class PositionController : MainController
    {
        public PositionController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "  افزودن جایگاه شغلی برای مراکز درمانی ")]
        [HttpPost("create-position")]
        public async Task<IActionResult> CreatePosition(CreatePositionCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreatePositionCommand, CreatePositionCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  خواندن جایگاه های شغلی در مراکز درمانی ")]
        [HttpGet("read-position")]
        public async Task<IActionResult> ReadPosition(CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadPositionQuery, ReadPositionQueryResponse>(new ReadPositionQuery(), cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ویرایش جایگاه شغلی در مراکز درمانی ")]
        [HttpPut("update-position")]
        public async Task<IActionResult> UpdatePosition(UpdatePositionCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdatePositionCommand, UpdatePositionCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  حذف جایگاه شغلی در مراکز درمانی ")]
        [HttpDelete("delete-position")]
        public async Task<IActionResult> DeletePosition(DeletePositionCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeletePositionCommand, DeletePositionCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}
