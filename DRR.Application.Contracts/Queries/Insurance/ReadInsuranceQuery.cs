using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Insurance
{
    public class ReadInsuranceQuery : Query
    {
        public int Id { get; set; }
    }
    public class ReadInsuranceQueryResponse : QueryResponse
    {
        public Domain.Insurances.Insurance Data { get; set; }
    }
}
