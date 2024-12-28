using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadPatientsDoctorQuery : Query
    {
        public int DoctorId { get; set; }
    }

    public class ReadPatientsDoctorQueryResponse : QueryResponse
    {
        public ReadPatientsDoctorQueryResponse()
        {
            List = new List<PatientDto>();
        }
        public List<PatientDto> List { get; set; }
    }
}
