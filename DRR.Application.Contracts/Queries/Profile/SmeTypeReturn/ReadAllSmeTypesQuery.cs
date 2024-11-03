using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Profile.SmeTypeReturn
{
    public class ReadAllSmeTypesQuery : Query
    {
    }

    public class ReadAllSmeTypesQueryResponse : QueryResponse
    {
        public List<SmeTypeDto> List { get; set; }
    }
}
