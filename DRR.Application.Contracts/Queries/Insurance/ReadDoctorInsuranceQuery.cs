using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Insurance
{
    public class ReadDoctorInsuranceQuery : Query
    {
        public int Id { get; set; }
    }
    public class ReadDoctorInsuranceQueryResponse : QueryResponse
    {
        public Domain.Insurances.DoctorInsurance Data { get; set; }
    }
}