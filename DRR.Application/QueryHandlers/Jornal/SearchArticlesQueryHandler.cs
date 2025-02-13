using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Queries.Jornal;
using DRR.Application.Contracts.Repository.Articles;
using DRR.Application.Contracts.Services.Jornal;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.QueryHandlers.Jornal
{
    public class SearchArticlesQueryHandler : IQueryHandler<SearchArticlesQuery, SearchArticlesQueryResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleService _articleService;

        public SearchArticlesQueryHandler(IArticleRepository articleRepository, IArticleService articleService)
        {
            _articleRepository = articleRepository;
            _articleService = articleService;
        }

        public async Task<SearchArticlesQueryResponse> Execute(SearchArticlesQuery query,
            CancellationToken cancellationToken)
        {
            var articleList = await _articleRepository.Search(query.Title ?? "", query.ShortDesc ?? "", query.Desc ?? "");

            var result = new SearchArticlesQueryResponse
            {
                List = await _articleService.OrderDesc(await _articleService.ConvertTo(articleList))
            };

            return result;
        }
    }
}
