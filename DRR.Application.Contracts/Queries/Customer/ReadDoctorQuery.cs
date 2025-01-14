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
    public class ReadDoctorsBySmeprofileQuery : Query
    {
        public int SmeProfileId {  get; set; } 
    }
    public class ReadDoctorsBySpecialityQuery : Query
    {
        public int SpecialistId { get; set; }
    }
    public class ReadDoctorQuery : Query
    {
        public int Id { get; set; }
    }
    public class ReadAllDoctorsQuery : Query
    {
        
    }
   
    public class ReadDoctorQueryResponse : QueryResponse
    {
        public DoctorDto Data { get; set; }
    }


    public class ReadDoctorDoctorsQuery : Query
    {
        public ReadDoctorQueryFilters? Filters { get; set; }
    }

    public class ReadDoctorsQueryResponse : QueryResponse
    {
        public ReadDoctorsQueryResponse()
        {
            List = new List<DoctorDto>();
        }
        public List<DoctorDto> List { get; set; }
    }

    public class ReadDoctorQueryFilters
    {
        public string DoctorName { get; set; }
        public string DoctorFamily { get; set; }

        public string NationalId { get; set; }

        public string Bimeh { get; set; }
        public string CityName { get; set; }

    }
}
