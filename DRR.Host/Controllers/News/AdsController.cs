using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Queries.News;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.News
{
    public class AdsController : MainController
    {
        public AdsController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "  خواندن تبلیغ های یک کاربر ")]
        [HttpGet("read-smeprofile-ads")]
        public async Task<IActionResult> ReadSmeProfileads([FromQuery]ReadSmeProfileAdsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSmeProfileAdsQuery, ReadAdsQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ایجاد یک تبلیغ ")]
        [HttpPost("create-ads")]
        public async Task<IActionResult> Createads(CreateAdsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateAdsCommand, CreateAdsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "   تبلیغ های صفحه اول ")]
        [HttpGet("read-ads")]
        public async Task<IActionResult> Readads([FromQuery] ReadAdsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAdsQuery, ReadAdsQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }


        [SwaggerOperation(Summary = "  ویرایش یک تبلیغ ")]
        [HttpPut("update-ads")]
        public async Task<IActionResult> Updateads(UpdateAdsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateAdsCommand, UpdateAdsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  حذف یک تبلیغ ")]
        [HttpDelete("delete-ads")]
        public async Task<IActionResult> Deleteads(DeleteAdsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteAdsCommand, DeleteAdsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}
