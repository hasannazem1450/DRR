using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Insurance
{
    public class ReadInsurancesQuery : Query
    {
    }
    public class ReadInsurancesQueryResponse : QueryResponse
    {
        public List<Domain.Insurances.Insurance> List { get; set; }
    }
}
