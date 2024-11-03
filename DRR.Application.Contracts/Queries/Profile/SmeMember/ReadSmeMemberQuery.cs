using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.SmeMember;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Profile.SmeMember
{
    public class ReadSmeMemberQuery : Query
    {

    }

    public class ReadSmeMemberQueryResponse : QueryResponse
    {
        public ReadSmeMemberQueryResponse()
        {
            List = new List<SmeMemberDto>();
        }
        public List<SmeMemberDto> List { get; set; }
    }
}
