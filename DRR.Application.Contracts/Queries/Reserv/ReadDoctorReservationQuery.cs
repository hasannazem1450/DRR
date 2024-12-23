using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Reservation
{
    public class ReadDoctorReservationQuery :Query
    {
        public int DoctorId {  get; set; }
    }

    public class ReadDoctorReservationQueryResponse : QueryResponse
    {
        public List<ReservationDto> Data { get; set; }
    }
}
