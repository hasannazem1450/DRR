using DRR.Application.Contracts.Commands.Comment;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Comment
{
    public class ReadSmeProfileCommentQuery : Query
    {
        public int SmeProfileId { get; set; }
    }

    public class ReadSmeProfileCommentQueryResponse : QueryResponse
    {
        public ReadSmeProfileCommentQueryResponse()
        {
            List = new List<CommentDto>(); 
        }
        public List<CommentDto> List { get; set; }
    }
}
