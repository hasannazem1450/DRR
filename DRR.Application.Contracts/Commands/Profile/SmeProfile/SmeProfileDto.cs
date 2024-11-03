using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.BaseInfo;
using DRR.Domain.Profile;

namespace DRR.Application.Contracts.Commands.Profile.SmeProfile
{
    public class SmeProfileDto
    {
        public int Id { get; set; }
        public string SmeName { get; set; }
        public string NationalCode { get; set; }
        public string BusinessCode { get; set; }
        public string ManagerName { get; set; }
        public string RegisterNumber { get; set; }
        public string EconomyCode { get; set; }
        public string PermitNo { get; set; }
        public string ManagerPhoneNumber { get; set; }
        public string ManagerEmail { get; set; }
        public string AboutUs { get; set; }
        public string TellNumber { get; set; }
        public string ActivitySubject { get; set; }
        public string SmeEmail { get; set; }
        public string SmeWebsite { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public string Logo { get; set; }
        public string Headerpic { get; set; }
        public string Postalcode { get; set; }
        public int SmeType { get; set; }
        public string SmeTypeName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string IndustrialParkName { get; set; }
        public int SmeRankId { get; set; }
    }
}
