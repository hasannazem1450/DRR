using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Insurance
{
    public class ReadDoctorsInsurancesQuery : Query
    {
    }
    public class ReadDoctorsInsurancesQueryResponse : QueryResponse
    {
        public List<DoctorInsuranceDto> List { get; set; }
    }
}
