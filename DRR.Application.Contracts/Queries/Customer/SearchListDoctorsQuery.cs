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
    public class SearchListDoctorsQuery : Query
    {
        public int pagesize { get; set; } = 20;
        public int pageNumber { get; set; } = 1;
        public string? DoctorName { get; set; }
        public string? doctorFamily { get; set; }
        public string? specialist { get; set; }
        
    }

    public class SearchListDoctorsQueryResponse : QueryResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public List<DoctorDto> List { get; set; }
    }
}
