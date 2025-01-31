using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Profile.SmeProfile
{
    public class CreateSmeProfileCommand : Command
    {
        public string SmeName { get; set; }
        public string NationalCode { get; set; }
        public string? BusinessCode { get; set; }
        public string? ManagerName { get; set; }
        public string? RegisterNumber { get; set; }
        public string? EconomyCode { get; set; }
        public string? PermitNo { get; set; }
        public string ManagerPhoneNumber { get; set; }
        public string ManagerEmail { get; set; }
        public string AboutUs { get; set; }
        public string TellNumber { get; set; }
        public string ActivitySubject { get; set; }
        public string SmeEmail { get; set; }
        public string SmeWebsite { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int SmeRankId { get; set; }
        public bool Status { get; set; }
        public string Logo { get; set; }
        public string Headerpic { get; set; }
        public string Postalcode { get; set; }
        public int SmeType { get; set; }

    }

    public class CreateSmeProfileCommandResponse : CommandResponse
    {
        public int Id { get; set; }
    }
}
