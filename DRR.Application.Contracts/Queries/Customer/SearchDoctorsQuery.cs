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
        public int Id { get; set; }
        public int pagesize { get; set; } = 20;
        public int pageNumber { get; set; } = 1;
        public string? DoctorName { get; set; }
        public string? doctorFamily { get; set; }
        public string? specialistIds { get; set; }
        public string? docExperiance { get; set; }
        public string? docInstaLink { get; set; }
        public string? desc { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public string BimehTakmili {  get; set; }
        public string BimeAsli {  get; set; }
        public bool? JustOnline { get; set; }
        public bool? HasTurn { get; set; }
        public bool? AcceptInsurance { get; set; }
        public bool? Gender { get; set; } 
        public string Sdate { get; set; }
        public string Edate { get; set; }
        public int? OnlineTypeId { get; set; }
        public bool? OfficeOrClinicHozoori { get; set; }
        public int TotalRecords { get; set; }
    }

    public class SearchDoctorsQueryResponse : QueryResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public List<DoctorBoxDto> List { get; set; }
    }
}
