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
    public class MessagingGroupSmeProfileController : MainController
    {
        public MessagingGroupSmeProfileController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "افزودن یک کاربر به یک گروه پیام دهی ")]
        [HttpPost("create-messaginggroupsmeprofile")]
        public async Task<IActionResult> CreateMessagingGroupSmeProfile(CreateMessagingGroupSmeProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateMessagingGroupSmeProfileCommand, CreateMessagingGroupSmeProfileCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ویرایش یک کاربر و اتصال دادن به یک گروه دیگر پیام دهی ")]
        [HttpPut("update-messaginggroupsmeprofile")]
        public async Task<IActionResult> UpdateMessagingGroupSmeProfile(UpdateMessagingGroupSmeProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<UpdateMessagingGroupSmeProfileCommand, UpdateMessagingGroupSmeProfileCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف یک کاربر از یک گروه پیام دهی ")]
        [HttpDelete("delete-messaginggroupsmeprofile")]
        public async Task<IActionResult> DeleteMessagingGroupSmeProfile(DeleteMessagingGroupSmeProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteMessagingGroupSmeProfileCommand, DeleteMessagingGroupSmeProfileCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خواندن کاربران موجود در یک گروه پیام دهی ")]
        [HttpGet("read-messaginggroupsmeprofile")]
        public async Task<IActionResult> ReadMessagingGroupSmeProfile([FromQuery] ReadMessagingGroupSmeProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadMessagingGroupSmeProfileQuery, ReadMessagingGroupSmeProfileQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
    }
}
