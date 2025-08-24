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
        public int pagesize { get; set; } = 10;
        public int pageNumber { get; set; } = 1;
        public int TotalRecords { get; set; }
        public string SearchInComment { get; set; }
    }
    public class ReadAllCommentQueryResponse : QueryResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public AllCommentDto AllCommentDto { get; set; }
    }
}