using DRR.Application.Contracts.Commands.Reserv;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Reserv
{
    public class ReadVisitTypeQuery : Query
    {

    }
    public class ReadVisitTypeQueryResponse : QueryResponse
    {
        public ReadVisitTypeQueryResponse()
        {
            List = new List<VisitType>();
        }
        public List<VisitType> List { get; set; }
    }
}
