using DRR.Application.Contracts.Commands.Jornal;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Jornal
{
    public class SearchArticlesQuery : Query
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }

    }
    public class SearchArticlesQueryResponse : QueryResponse
    {
        public List<ArticleDto> List { get; set; }
    }
}