using DRR.Application.Contracts.Commands.Comment;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Jornal
{
    public interface IArticleCommentService :IService
    {
        Task<List<ArticleCommentDto>> ConvertToDto(List<DRR.Domain.Comments.ArticleComment> acomments);
        Task<ArticleCommentDto> ConvertToDto(DRR.Domain.Comments.ArticleComment acomment);
    }
}
