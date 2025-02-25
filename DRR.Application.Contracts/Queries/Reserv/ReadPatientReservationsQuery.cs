using DRR.Application.Contracts.Commands.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Reserv
{
    public class ReadPatientReservationsQuery : Query
    {
        public int PatientId { get; set; }
        
    }
    public class ReadPatientReservationsQueryResponse : QueryResponse
    {
        public ReadPatientReservationsQueryResponse()
        {
            List = new List<PatientReservationDto>();
        }
        public List<PatientReservationDto> List { get; set; }
    }
}
