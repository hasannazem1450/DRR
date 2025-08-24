using DRR.Application.Contracts.Repository.Comments;
using DRR.CommandDB;
using DRR.Domain.Comments;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Utilities.Extensions;
using DRR.Application.Contracts.Queries.Comment;

namespace DRR.CommandDb.Repository.Comments
{
    public class ArticleCommentRepository : BaseRepository, IArticleCommentRepository
    {
        public ArticleCommentRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<ArticleComment> ReadArticleCommentById(int id)
        {
            var result = await _Db.ArticleComments.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<ArticleComment>> ReadArticleCommentByUserId(int id)
        {
            var result = await _Db.ArticleComments.Where(c => c.SmeProfileId == id).ToListAsync();

            return result;
        }
        public async Task<List<ArticleComment>> ReadArticleCommentByArticleId(int id)
        {
            var result = await _Db.ArticleComments.Where(c => c.ArticleId == id).ToListAsync();

            return result;
        }
        public async Task Create(ArticleComment ArticleComment)
        {
            await _Db.ArticleComments.AddAsync(ArticleComment);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Comments.ArticleComment ArticleComment)
        {
            var result = await this.ReadArticleCommentById(ArticleComment.Id);

            result.Desc = ArticleComment.Desc;
            result.SmeProfileId = ArticleComment.SmeProfileId;
            result.ArticleId = ArticleComment.ArticleId;
            result.CommentDate = ArticleComment.CommentDate;
            result.IsAccept = ArticleComment.IsAccept;


            _Db.ArticleComments.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.ArticleComments.FirstOrDefaultAsync(n => n.Id == id);

            _Db.ArticleComments.Remove(result);

            await _Db.SaveChangesAsync();
        }
        public async Task<List<ArticleComment>> Search(ReadAllCommentQuery query)
        {
            var q = _Db.ArticleComments
                .Where(w => !w.IsDeleted);
            if (query.SearchInComment != null && query.SearchInComment.Length > 2)
            {
                var searchArticleCommentTerms = query.SearchInComment.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();


                foreach (var searchTerm in searchArticleCommentTerms.Where(w => w.IsNotNullOrEmpty()))
                    q = q.Where(w =>
                        w.Desc.Contains(searchTerm) ||
                        w.Article.Title.Contains(searchTerm) ||
                        w.Article.ShortDesc.Contains(searchTerm)
                    );
            }
            query.TotalRecords = q.Count();

            var result = await q.Skip((query.pageNumber - 1) * query.pagesize).Take(query.pagesize).ToListAsync();

            return result;
        }

    }

}
