using DRR.Application.Contracts.Queries.Comment;
using DRR.Domain.Comments;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Comments
{
    public interface IArticleCommentRepository : IRepository
    {
        Task<ArticleComment> ReadArticleCommentById(int id);
        Task<List<ArticleComment>> ReadArticleCommentByUserId(int id);
        Task<List<ArticleComment>> ReadArticleCommentByArticleId(int id);

        Task Delete(int id);

        Task Update(Domain.Comments.ArticleComment articleComment);

        Task Create(Domain.Comments.ArticleComment articleComment);
        Task<List<ArticleComment>> Search(ReadAllCommentQuery query);
    }

}
