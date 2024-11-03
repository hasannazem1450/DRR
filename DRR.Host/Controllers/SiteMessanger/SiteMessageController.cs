using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Queries.SiteMessenger;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.SiteMessanger
{
    public class SiteMessageController : MainController
    {
        public SiteMessageController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-sitemessage")]
        public async Task<IActionResult> CreateSmeProfile(CreateSiteMessageCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateSiteMessageCommand, CreateSiteMessageCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-sitemessage")]
        public async Task<IActionResult> UpdateSmeProfile(UpdateSiteMessageCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<UpdateSiteMessageCommand, UpdateSiteMessageCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-sitemessage")]
        public async Task<IActionResult> DeleteSmeProfile(DeleteSiteMessageCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteSiteMessageCommand, DeleteSiteMessageCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-sitemessage")]
        public async Task<IActionResult> ReadSmeProfile([FromQuery] ReadSiteMessageQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSiteMessageQuery, ReadSiteMessageQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPost("create-sitemessage-image")]
        public async Task<IActionResult> CreateSiteMessageImage(CreateSiteMessageImageCommand command, CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateSiteMessageImageCommand, CreateSiteMessageImageCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-sitemessage-image")]
        public async Task<IActionResult> DeleteSiteMessageImage(DeleteSiteMessageImageCommand command, CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteSiteMessageImageCommand, DeleteSiteMessageImageCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }


        [HttpGet("read-recived-message")]
        public async Task<IActionResult> ReadRecivedMessage([FromQuery] ReadRecivedMessageQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadRecivedMessageQuery, ReadRecivedMessageQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
    }
}
