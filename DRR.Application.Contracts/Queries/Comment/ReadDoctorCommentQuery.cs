using DRR.Application.Contracts.Commands.Comment;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Comment
{
    public class ReadDoctorCommentQuery : Query
    {
        public int DoctorId { get; set; }
    }
    public class ReadDoctorCommentQueryResponse : QueryResponse
    {
        public ReadDoctorCommentQueryResponse()
        {
            List = new List<CommentDto>();
        }
        public List<CommentDto> List { get; set; }
    }
}
