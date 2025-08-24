using DRR.Application.Contracts.Commands.Comment;
using DRR.Application.Contracts.Services.Jornal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Comment
{
    public class ArticleCommentService : IArticleCommentService
    {
        public async Task<List<ArticleCommentDto>> ConvertToDto(List<DRR.Domain.Comments.ArticleComment> acomments)
        {
            var result = acomments.Select(s => ConvertToDto(s).Result).ToList();

            return result;
        }

        public async Task<ArticleCommentDto> ConvertToDto(DRR.Domain.Comments.ArticleComment acomment)
        {
            var result = new ArticleCommentDto
            {
                Id = acomment.Id,
                Desc = acomment.Desc,
                ArticleId = acomment.SmeProfileId,
                CommentDate = acomment.CommentDate,
                SmeProfileId =acomment.SmeProfileId,
                IsAccept = acomment.IsAccept,
                SmeProfile = acomment.SmeProfile,
                Article = acomment.Article
            };

            return result;
        }
    }
}
