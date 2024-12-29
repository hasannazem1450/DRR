using DRR.Application.Contracts.Commands.Customer;
using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadInsurancesPatientQuery : Query
    {
        public int PatientId { get; set; }
    }
    public class ReadInsurancesPatientQueryResponse : QueryResponse
    {
        public List<PatientInsuranceDto> List { get; set; }
    }
}
