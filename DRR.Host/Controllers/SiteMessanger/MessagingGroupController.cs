using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Queries.SiteMessenger;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.SiteMessanger
{
    public class MessagingGroupController : MainController
    {
        public MessagingGroupController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-messaginggroup")]
        public async Task<IActionResult> CreateSmeProfile(CreateMessagingGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateMessagingGroupCommand, CreateMessagingGroupCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-messaginggroup")]
        public async Task<IActionResult> UpdateSmeProfile(UpdateMessagingGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<UpdateMessagingGroupCommand, UpdateMessagingGroupCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-messaginggroup")]
        public async Task<IActionResult> DeleteSmeProfile(DeleteMessagingGroupCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteMessagingGroupCommand, DeleteMessagingGroupCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-messaginggroup")]
        public async Task<IActionResult> ReadSmeProfile([FromQuery] ReadMessagingGroupQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadMessagingGroupQuery, ReadMessagingGroupQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

    }
}
