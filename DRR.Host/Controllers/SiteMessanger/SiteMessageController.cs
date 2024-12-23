using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Queries.SiteMessenger;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.SiteMessanger
{
    public class SiteMessageController : MainController
    {
        public SiteMessageController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "ایجاد یک پیام برای ارسال به یک گروه پیام دهی ")]
        [HttpPost("create-sitemessage")]
        public async Task<IActionResult> CreateSmeProfile(CreateSiteMessageCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateSiteMessageCommand, CreateSiteMessageCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ویرایش یک پیام برای ارسال به یک گروه پیام دهی ")]
        [HttpPut("update-sitemessage")]
        public async Task<IActionResult> UpdateSmeProfile(UpdateSiteMessageCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<UpdateSiteMessageCommand, UpdateSiteMessageCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف یک پیام برای ارسال به یک گروه پیام دهی ")]
        [HttpDelete("delete-sitemessage")]
        public async Task<IActionResult> DeleteSmeProfile(DeleteSiteMessageCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteSiteMessageCommand, DeleteSiteMessageCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "نمایش یک پیام برای ارسال به یک گروه پیام دهی ")]
        [HttpGet("read-sitemessage")]
        public async Task<IActionResult> ReadSmeProfile([FromQuery] ReadSiteMessageQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSiteMessageQuery, ReadSiteMessageQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ایجاد عکس برای یک پیام برای ارسال به یک گروه پیام دهی ")]
        [HttpPost("create-sitemessage-image")]
        public async Task<IActionResult> CreateSiteMessageImage(CreateSiteMessageImageCommand command, CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateSiteMessageImageCommand, CreateSiteMessageImageCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف عکس برای یک پیام برای ارسال به یک گروه پیام دهی ")]
        [HttpDelete("delete-sitemessage-image")]
        public async Task<IActionResult> DeleteSiteMessageImage(DeleteSiteMessageImageCommand command, CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteSiteMessageImageCommand, DeleteSiteMessageImageCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [SwaggerOperation(Summary = "خواندن  پیام های دیده شده ارسالی  ")]
        [HttpGet("read-recived-message")]
        public async Task<IActionResult> ReadRecivedMessage([FromQuery] ReadRecivedMessageQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadRecivedMessageQuery, ReadRecivedMessageQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
    }
}
