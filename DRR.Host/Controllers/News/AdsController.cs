using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Queries.News;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.News
{
    public class AdsController : MainController
    {
        public AdsController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpGet("read-smeprofile-ads")]
        public async Task<IActionResult> ReadSmeProfileads([FromQuery]ReadSmeProfileAdsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSmeProfileAdsQuery, ReadAdsQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPost("create-ads")]
        public async Task<IActionResult> Createads(CreateAdsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateAdsCommand, CreateAdsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        //[HttpGet("read-ads")]
        //public async Task<IActionResult> Readads(CancellationToken cancellationToken)
        //{
        //    var result = await Handler.Query<ReadSmeProfileadsQuery, ReadadsQueryResponse>(new ReadSmeProfileadsQuery(), cancellationToken);

        //    return OkApiResult(result);
        //}

       

        [HttpPut("update-ads")]
        public async Task<IActionResult> Updateads(UpdateAdsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateAdsCommand, UpdateAdsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-ads")]
        public async Task<IActionResult> Deleteads(DeleteAdsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteAdsCommand, DeleteAdsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}
