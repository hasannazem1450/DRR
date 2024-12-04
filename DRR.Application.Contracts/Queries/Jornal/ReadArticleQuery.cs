using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Jornal
{
   
    public class ReadArticleQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadArticleQueryResponse : QueryResponse
    {
        public ArticleDto Data { get; set; }
    }
}
