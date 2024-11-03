using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.Position;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Profile.Member
{
    public class ReadPositionQuery : Query
    {

    }

    public class ReadPositionQueryResponse : QueryResponse
    {
        public ReadPositionQueryResponse()
        {
            List = new List<PositionDto>();
        }
        public List<PositionDto> List { get; set; }
    }
}
