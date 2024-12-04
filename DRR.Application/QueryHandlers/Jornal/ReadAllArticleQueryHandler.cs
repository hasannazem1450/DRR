using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Queries.Jornal;
using DRR.Application.Contracts.Repository.Articles;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.QueryHandlers.Jornal
{
    public class ReadAllArticleQueryHandler : IQueryHandler<ReadAllArticleQuery, ReadAllArticleQueryResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleService _articleService;

        public ReadAllArticleQueryHandler(IArticleRepository articleRepository, IArticleService articleService)
        {
            _articleRepository = articleRepository;
            _articleService = articleService;
        }

        public async Task<ReadAllArticleQueryResponse> Execute(ReadAllArticleQuery query,
            CancellationToken cancellationToken)
        {
            var articleList = await _articleRepository.Read(query.Title ?? "", query.HeadLine ?? "");

            var result = new ReadAllArticleQueryResponse
            {
                List = await _articleService.OrederDesc(await _articleService.ConvertTo(articleList))
            };

            return result;
        }
    }
}
