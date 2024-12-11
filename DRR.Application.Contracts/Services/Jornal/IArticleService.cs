using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Domain.Articles;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.Jornal
{
    public interface IArticleService:IService
    {
        Task<List<ArticleDto>> OrderDesc(List<ArticleDto> articleList);
        Task<List<ArticleDto>> ConvertTo(List<Article> articleList);
        Task<ArticleDto> ConvertTo(Article article);
    }
}
