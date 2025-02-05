using DRR.Application.Contracts.Queries.Jornal;
using DRR.Application.Contracts.Repository.Articles;
using DRR.Application.Contracts.Services.Jornal;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Jornal
{
    public class ReadArticleQueryHandler : IQueryHandler<ReadArticleQuery, ReadArticleQueryResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleService _articleService;

        public ReadArticleQueryHandler(IArticleRepository articleRepository, IArticleService articleService)
        {
            _articleRepository = articleRepository;
            _articleService = articleService;
        }

        public async Task<ReadArticleQueryResponse> Execute(ReadArticleQuery query,
            CancellationToken cancellationToken)
        {
            var article = await _articleRepository.ReadArticleById(query.Id);

            var result = new ReadArticleQueryResponse
            {
                Data = await _articleService.ConvertTo(article)
            };

            return result;
        }
    }
}
