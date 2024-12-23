using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadReservesDoctorQuery : Query
    {
        public int DoctorTreatmentCenterId { get; set; }
    }

    public class ReadReservesDoctorQueryResponse : QueryResponse
    {
        public int DoctorTreatmentCenterId { get; set; }
    }
}
