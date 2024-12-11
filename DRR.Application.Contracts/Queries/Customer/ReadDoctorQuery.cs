using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.News;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadDoctorQuery : Query
    {
        public int SmeProfileId {  get; set; }
    }

    public class SearchDoctorsQuery : Query
    {
        public ReadDoctorQueryFilters? Filters { get; set; }
    }

    public class ReadDoctorQueryResponse : QueryResponse
    {
        public ReadDoctorQueryResponse()
        {
            List = new List<DoctorDto>();
        }
        public List<DoctorDto> List { get; set; }
    }

    public class ReadDoctorQueryFilters
    {
        public int? ProvinceId { get; set; }
        public string Name { get; set; }

        public string speciality { get; set; }

        public string bimeh { get; set; }
        public string cityname { get; set; }

    }
}
