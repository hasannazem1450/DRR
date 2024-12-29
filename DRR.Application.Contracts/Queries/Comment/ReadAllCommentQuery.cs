using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Comment;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Comment
{
    public class ReadAllCommentQuery : Query
    {

    }
    public class ReadAllCommentQueryResponse : QueryResponse
    {
        public ReadAllCommentQueryResponse()
        {
            List = new List<CommentDto>();
        }
        public List<CommentDto> List { get; set; }
    }
}