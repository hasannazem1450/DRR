﻿using System;
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
    public class ReadAllArticlesQueryHandler : IQueryHandler<ReadAllArticlesQuery, ReadAllArticlesQueryResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleService _articleService;

        public ReadAllArticlesQueryHandler(IArticleRepository articleRepository, IArticleService articleService)
        {
            _articleRepository = articleRepository;
            _articleService = articleService;
        }

        public async Task<ReadAllArticlesQueryResponse> Execute(ReadAllArticlesQuery query,
            CancellationToken cancellationToken)
        {
            var articleList = await _articleRepository.ReadArticlesByArticleTypeId(query.ArticleTypeId);

            var result = new ReadAllArticlesQueryResponse
            {
                List = await _articleService.OrderDesc(await _articleService.ConvertTo(articleList))
            };

            return result;
        }
    }
}
