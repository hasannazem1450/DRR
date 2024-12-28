using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadInsurancesDoctorQuery:Query
    {
        public int DoctorId { get; set; }
    }
    public class ReadInsurancesDoctorQueryResponse : QueryResponse
    {
        public List<DoctorDto> List { get; set; }
    }
}
