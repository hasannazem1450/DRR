using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Event;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadPatientQuery : Query
    {
    }
    public class ReadPatientQueryResponse : QueryResponse
    {
        public List<PatientDto> List { get; set; }
    }

    public class SearchPatientQuery : Query
    {
        public ReadPatientQueryFilters? Filters { get; set; }
    }
    public class ReadPatientQueryFilters
    {
        public int? ProvinceId { get; set; }
        public string PatientName { get; set; }
        public string PatientFamily { get; set; }
        public string NationalId { get; set; }
        public int BirthNumber { get; set; }
        public string BirthDate { get; set; }
        public string speciality { get; set; }

        public string bimeh { get; set; }
        public string cityname { get; set; }

    }
}

