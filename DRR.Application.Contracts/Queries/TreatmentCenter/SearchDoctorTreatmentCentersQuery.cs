using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.TreatmentCenter
{
    public class SearchDoctorTreatmentCentersQuery: Query
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string SpecialistIds { get; set; }
        public string SpecialistName { get; set; }
        public string ClinicTypeName { get; set; }
        public string OfficeTypeName { get; set; }
        public string DoctorTreatmentCenterName { get; set; }
        public string Desc { get; set; }


    }
    public class SearchDoctorTreatmentCentersQueryResponse : QueryResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public List<DoctorTreatmentCenterDto> List { get; set; }
    }
}
