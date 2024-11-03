using DRR.Domain.Articles;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Articles
{
    public interface IArticleTypeRepository : IRepository
    {
        Task<ArticleType> ReadArticleTypeById(int id);

        Task Delete(int id);

        Task Update(Domain.Articles.ArticleType articleType);

        Task Create(Domain.Articles.ArticleType articleType);
    }

}
