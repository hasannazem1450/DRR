using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Comment
{
    public class AllCommentDto
    {
        public List<CommentDto> CommentDtos { get; set; }
        public List<ArticleCommentDto> ArticleCommentDtos { get; set; }
    }
}
