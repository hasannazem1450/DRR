using DRR.Domain.Customer;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;


namespace DRR.Application.Contracts.Queries.Insurance
{
    public class ReadDoctorsInsuranceQuery : Query
    {
        public int InsuranceId { get; set; }
    }
    public class ReadDoctorsInsuranceQueryResponse : QueryResponse
    {
        public List<Doctor> List { get; set; }
    }
}
