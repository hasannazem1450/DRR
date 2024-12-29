using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Queries.SiteMessenger;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.SiteMessanger
{
    public class MessagingGroupSmeProfileController : MainController
    {
        public MessagingGroupSmeProfileController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-messaginggroupsmeprofile")]
        public async Task<IActionResult> CreateMessagingGroupSmeProfile(CreateMessagingGroupSmeProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateMessagingGroupSmeProfileCommand, CreateMessagingGroupSmeProfileCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-messaginggroupsmeprofile")]
        public async Task<IActionResult> UpdateMessagingGroupSmeProfile(UpdateMessagingGroupSmeProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<UpdateMessagingGroupSmeProfileCommand, UpdateMessagingGroupSmeProfileCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-messaginggroupsmeprofile")]
        public async Task<IActionResult> DeleteMessagingGroupSmeProfile(DeleteMessagingGroupSmeProfileCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteMessagingGroupSmeProfileCommand, DeleteMessagingGroupSmeProfileCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-messaginggroupsmeprofile")]
        public async Task<IActionResult> ReadMessagingGroupSmeProfile([FromQuery] ReadMessagingGroupSmeProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadMessagingGroupSmeProfileQuery, ReadMessagingGroupSmeProfileQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
    }
}
