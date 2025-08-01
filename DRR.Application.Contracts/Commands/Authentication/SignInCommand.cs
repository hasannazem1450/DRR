using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Customer;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Authentication
{
    public class SignInCommand : Command
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [DefaultValue(true)]
        public bool IsPersistent { get; set; }
    }

    public class SignInCommandResponse : CommandResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiredAt { get; set; }
        public string UserFullname { get; set; }
        public int SmeprofileId { get; set; }
        public SmeProfile Smeprofile { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
