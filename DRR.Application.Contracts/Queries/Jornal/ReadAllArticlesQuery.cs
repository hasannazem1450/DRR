using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Jornal
{
    public class ReadAllArticlesQuery : Query
    {
        public int ArticleTypeId { get; set; } = 1;
    }
    public class ReadAllArticlesQueryResponse : QueryResponse
    {
        public List<ArticleDto> List { get; set; }
    }
}
