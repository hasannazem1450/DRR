using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Insurance
{
    public class ReadDoctorInsurancesQuery : Query
    {
    }
    public class ReadDoctorInsurancesQueryResponse : QueryResponse
    {
        public List<Domain.Insurances.DoctorInsurance> List { get; set; }
    }
}
