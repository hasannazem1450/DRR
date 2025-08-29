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
    public class ReadVisitCostQuery : Query
    {
        
    }
    public class ReadVisitCostQueryResponse : QueryResponse
    {
        public ReadVisitCostQueryResponse()
        {
            List = new List<VisitCost>();
        }
        public List<VisitCost> List { get; set; }
    }
}
