using DRR.Application.Contracts.Repository.Articles;
using DRR.CommandDB;
using DRR.Domain.Articles;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Articles
{
    public class ArticleTypeRepository : BaseRepository, IArticleTypeRepository
    {
        public ArticleTypeRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<ArticleType> ReadArticleTypeById(int id)
        {
            var result = await _Db.ArticleTypes.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task Create(ArticleType ArticleType)
        {
            await _Db.ArticleTypes.AddAsync(ArticleType);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Articles.ArticleType ArticleType)
        {
            var result = await this.ReadArticleTypeById(ArticleType.Id);

            result.Type = ArticleType.Type;


            _Db.ArticleTypes.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.ArticleTypes.FirstOrDefaultAsync(n => n.Id == id);

            _Db.ArticleTypes.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
