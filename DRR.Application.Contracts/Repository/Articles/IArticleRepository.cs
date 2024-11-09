﻿using DRR.Domain.Articles;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Articles
{
    public interface IArticleRepository : IRepository
    {
        Task<Article> ReadArticleById(int id);
        Task<List<Article>> ReadArticleByUserId(int id);
        Task<List<Article>> ReadArticleByArticleTypeId(int id);

        Task Delete(int id);

        Task Update(Domain.Articles.Article article);

        Task Create(Domain.Articles.Article article);
    }

}