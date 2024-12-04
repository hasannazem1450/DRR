﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Jornal
{
    public class ReadAllArticleQuery : Query
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }
        public int ArticleTypeId { get; set; }

        public string Link { get; set; }
        public Guid? DRRFileId { get; set; }
        public string Authors { get; set; }
        public int SmeProfileId { get; set; }
    }
    public class ReadAllArticleQueryResponse : QueryResponse
    {
        public List<ArticleDto> List { get; set; }
    }
}
