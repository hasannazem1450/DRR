using DRR.Application.Contracts.Queries.News;
using System.Threading.Tasks;
using System.Threading;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using DRR.Application.Contracts.Queries.Jornal;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace DRR.Host.Controllers.Jornal
{
    public class ArticleController : MainController
    {
        public ArticleController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "  نمایش مقالات یک کاربر")]
        [HttpGet("read-smeprofile-articles")]
        public async Task<IActionResult> ReadSmeProfileArticle([FromQuery] ReadSmeProfileArticleQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSmeProfileArticleQuery, ReadArticleQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "  نمایش کل مقالات ")]
        [HttpGet("read-all-articles")]
        public async Task<IActionResult> ReadAllArticle([FromQuery] ReadAllArticleQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllArticleQuery, ReadAllArticleQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ایجاد یک مقالات ")]
        [HttpPost("create-articles")]
        public async Task<IActionResult> CreateArticle(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateArticleCommand, CreateArticleCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  حذف یک مقالات ")]
        [HttpDelete("delete-articles")]
        public async Task<IActionResult> DeleteArticle(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<DeleteCityCommand, DeleteCityCommandResponse>(new DeleteCityCommand(), cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ویرایش یک مقالات ")]
        [HttpPut("update-articles")]
        public async Task<IActionResult> UpdateArticle(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<UpdateCityCommand, UpdateCityCommandResponse>(new UpdateCityCommand(), cancellationToken);

            return OkApiResult(result);
        }
    }
}
