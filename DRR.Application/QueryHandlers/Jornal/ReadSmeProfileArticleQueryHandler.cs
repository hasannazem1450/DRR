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
    public class ReadSmeProfileArticleQueryHandler : IQueryHandler<ReadSmeProfileArticleQuery, ReadSmeProfileArticleQueryResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleService _articleService;

        public ReadSmeProfileArticleQueryHandler(IArticleRepository articleRepository, IArticleService articleService)
        {
            _articleRepository = articleRepository;
            _articleService = articleService;
        }

        public async Task<ReadSmeProfileArticleQueryResponse> Execute(ReadSmeProfileArticleQuery query,
            CancellationToken cancellationToken)
        {
            var articleList = await _articleRepository.ReadArticleBySmeProfileId(query.SmeProfileId);

            var result = new ReadSmeProfileArticleQueryResponse
            {
                List = await _articleService.OrderDesc(await _articleService.ConvertTo(articleList))
            };

            return result;
        }
    }
}
