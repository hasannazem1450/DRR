﻿using DRR.Application.Contracts.Queries.News;
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
        [AllowAnonymous]
        [SwaggerOperation(Summary = "  نمایش یک مقاله")]
        [HttpGet("read-article-byid")]
        public async Task<IActionResult> ReadArticleById([FromQuery] ReadArticleQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadArticleQuery, ReadArticleQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "  نمایش مقالات یک کاربر")]
        [HttpGet("read-smeprofile-articles")]
        public async Task<IActionResult> ReadSmeProfileArticle([FromQuery] ReadSmeProfileArticleQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSmeProfileArticleQuery, ReadSmeProfileArticleQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "  نمایش کل مقالات ")]
        [HttpGet("read-all-articles")]
        public async Task<IActionResult> ReadAllArticles([FromQuery] ReadAllArticlesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllArticlesQuery, ReadAllArticlesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [SwaggerOperation(Summary = " نمایش کل مقالات متنی ")]
        [HttpGet("read-all-articles-text")]
        public async Task<IActionResult> ReadAllArticlesText([FromQuery] ReadAllArticlesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllArticlesQuery, ReadAllArticlesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [SwaggerOperation(Summary = "  نمایش کل مقالات صوتی ")]
        [HttpGet("read-all-articles-voice")]
        public async Task<IActionResult> ReadAllArticlesVoice([FromQuery] ReadAllArticlesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllArticlesQuery, ReadAllArticlesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [SwaggerOperation(Summary = "  نمایش کل مقالات تصویری ")]
        [HttpGet("read-all-articles-video")]
        public async Task<IActionResult> ReadAllArticlesVideo([FromQuery] ReadAllArticlesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllArticlesQuery, ReadAllArticlesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " جستجو در کل مقالات تصویری ")]
        [HttpGet("search-articles")]
        public async Task<IActionResult> SearchArticlesVideo([FromQuery] SearchArticlesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<SearchArticlesQuery, SearchArticlesQueryResponse>(query, cancellationToken);

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

            var result = await Distributor.Push<DeleteArticleCommand, DeleteArticleCommandResponse>(new DeleteArticleCommand(), cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ویرایش یک مقالات ")]
        [HttpPut("update-articles")]
        public async Task<IActionResult> UpdateArticle(UpdateArticleCommand command, CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<UpdateArticleCommand, UpdateArticleCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
