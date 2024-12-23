using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadNextReservesDoctorQuery :Query
    {
        public int DoctorId { get; set; }
    }
    public class ReadNextReservesDoctorQueryResponse : QueryResponse
    {
        public List<Domain.Reserv.Reservation> List { get; set; }
    }
}
