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
    public class MessagingGroupController : MainController
    {
        public MessagingGroupController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "ایجاد یک گروه جدید پیام دهی ")]
        [HttpPost("create-messaginggroup")]
        public async Task<IActionResult> CreateSmeProfile(CreateMessagingGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateMessagingGroupCommand, CreateMessagingGroupCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ویرایش نام یک گروه پیام دهی ")]
        [HttpPut("update-messaginggroup")]
        public async Task<IActionResult> UpdateSmeProfile(UpdateMessagingGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<UpdateMessagingGroupCommand, UpdateMessagingGroupCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف یک گروه پیام دهی ")]
        [HttpDelete("delete-messaginggroup")]
        public async Task<IActionResult> DeleteSmeProfile(DeleteMessagingGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteMessagingGroupCommand, DeleteMessagingGroupCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خواندن کل گروه های پیام دهی ")]
        [HttpGet("read-messaginggroup")]
        public async Task<IActionResult> ReadSmeProfile([FromQuery] ReadMessagingGroupQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadMessagingGroupQuery, ReadMessagingGroupQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

    }
}
