using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Queries.SiteMessenger;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.SiteMessanger
{
    public class SiteMessageReciverController : MainController
    {
        public SiteMessageReciverController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-sitemessagereciver")]
        public async Task<IActionResult> CreateSiteMessageRecive(CreateSiteMessageReciverCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<CreateSiteMessageReciverCommand, CreateSiteMessageReciverCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-sitemessagereciver")]
        public async Task<IActionResult> UpdateSiteMessageRecive(UpdateSiteMessageReciverCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<UpdateSiteMessageReciverCommand, UpdateSiteMessagereciverCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-sitemessagereciver")]
        public async Task<IActionResult> DeleteSiteMessageRecive(DeleteSiteMessageReciverCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await Distributor.Push<DeleteSiteMessageReciverCommand, DeleteSiteMessageReciverCommandResponse>(command,
                    cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-sitemessagereciver")]
        public async Task<IActionResult> ReadSiteMessageRecive([FromQuery] ReadSiteMessageReciverQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSiteMessageReciverQuery, ReadSiteMessageReciverQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

    }
}
