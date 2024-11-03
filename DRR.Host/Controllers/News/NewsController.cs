using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Queries.News;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.News
{
    public class NewsController : MainController
    {
        public NewsController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpGet("read-smeprofile-news")]
        public async Task<IActionResult> ReadSmeProfileNews([FromQuery]ReadSmeProfileNewsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSmeProfileNewsQuery, ReadNewsQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPost("create-news")]
        public async Task<IActionResult> CreateNews(CreateNewsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateNewsCommand, CreateNewsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        //[HttpGet("read-news")]
        //public async Task<IActionResult> ReadNews(CancellationToken cancellationToken)
        //{
        //    var result = await Handler.Query<ReadSmeProfileNewsQuery, ReadNewsQueryResponse>(new ReadSmeProfileNewsQuery(), cancellationToken);

        //    return OkApiResult(result);
        //}

       

        [HttpPut("update-news")]
        public async Task<IActionResult> UpdateNews(UpdateNewsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateNewsCommand, UpdateNewsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-news")]
        public async Task<IActionResult> DeleteNews(DeleteNewsCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteNewsCommand, DeleteNewsCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}
