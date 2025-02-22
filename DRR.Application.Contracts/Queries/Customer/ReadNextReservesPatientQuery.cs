using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadNextReservesPatientQuery :Query
    {
        public int PatientId { get; set; }
    }
    public class ReadNextReservesPatientQueryResponse : QueryResponse
    {
        public List<PatientReservationDto> List { get; set; }
    }
}
