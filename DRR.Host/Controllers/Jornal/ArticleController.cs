using DRR.Application.Contracts.Queries.News;
using System.Threading.Tasks;
using System.Threading;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using DRR.Application.Contracts.Queries.Jornal;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Commands.Jornal;

namespace DRR.Host.Controllers.Jornal
{
    public class ArticleController : MainController
    {
        public ArticleController(IDistributor distributor) : base(distributor)
        {
        }
        [HttpGet("read-smeprofile-articles")]
        public async Task<IActionResult> ReadSmeProfileads([FromQuery] ReadSmeProfileArticleQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSmeProfileArticleQuery, ReadArticleQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [HttpPost("create-articles")]
        public async Task<IActionResult> Createads(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateArticleCommand, CreateArticleCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
