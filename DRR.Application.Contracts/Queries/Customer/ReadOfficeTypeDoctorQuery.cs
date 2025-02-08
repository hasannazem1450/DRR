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
    public class ReadOfficeTypeDoctorQuery :Query
    {
        public int OfficeTypeId { get; set; }
    }

    public class ReadOfficeTypeDoctorQueryResponse : QueryResponse
    {
        public List<DoctorDto> List { get; set; }
    }
}
