using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadDoctorsInTreatmentCenterQuery : Query
    {
        public Guid TreatmentCenterId { get; set; }
    }
    public class ReadDoctorsInTreatmentCenterQueryResponse : QueryResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public List<DoctorBoxDto> List { get; set; }
    }
}
