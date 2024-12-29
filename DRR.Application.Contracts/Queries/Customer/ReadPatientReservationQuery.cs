using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadPatientReservationQuery : Query
    {
        public int PatientId { get; set; }
    }
    public class ReadPatientReservationQueryResponse : QueryResponse
    {
        public ReadPatientReservationQueryResponse()
        {
            List = new List<PatientReservationDto>();
        }
        public List<PatientReservationDto> List { get; set; }
    }
}
