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
    public class SearchDoctorsQuery : Query
    {
        public string? DoctorName { get; set; }
        public string? doctorFamily { get; set; }
        public string? specialist { get; set; }
        public string? docExperiance { get; set; }
        public string? desc { get; set; }

        

        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }

    }

    public class SearchDoctorsQueryResponse : QueryResponse
    {
        public List<DoctorDto> List { get; set; }
    }
}
