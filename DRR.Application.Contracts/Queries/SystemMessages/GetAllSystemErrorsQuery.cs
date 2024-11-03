using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Queries.SystemMessages;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.SystemMessages
{
    public class GetAllSystemErrorsQuery : Query
    {

    }

    public class GetAllSystemErrorsQueryResponse : QueryResponse
    {
        public GetAllSystemErrorsQueryResponse()
        {
            List = new List<SystemErrorDto>();
        }
        public List<SystemErrorDto> List { get; set; }
    }
}
