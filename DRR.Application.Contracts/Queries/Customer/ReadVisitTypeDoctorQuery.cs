using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Event;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadVisitTypeDoctorQuery :Query
    {
        public int VisitTYpeId { get; set; }
    }

    public class ReadVisitTypeDoctorQueryResponse : QueryResponse
    {
        public List<DoctorDto> List { get; set; }
    }
}
