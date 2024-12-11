using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Application.Contracts.Queries.Jornal
{

    public class ReadSmeProfileArticleQuery : Query
    {
        public int SmeProfileId { get; set; }
    }

    public class ReadSmeProfileArticleQueryResponse : QueryResponse
    {
        public List<ArticleDto> List { get; set; }
    }
}
