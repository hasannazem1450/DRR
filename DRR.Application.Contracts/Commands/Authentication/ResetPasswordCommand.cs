using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Authentication
{
    public class ResetPasswordCommand : Command
    {
        public ResetPasswordCommand(string userName, string phoneNumber, string password)
        {
            UserName = userName;
            PhoneNumber = phoneNumber;
            Password = password;
            
        }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

    }
    public class ResetPasswordCommandResponse : CommandResponse
    {
        public string Message { get; set; }
        public string Prefix { get; set; }
        public int Code { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiredAt { get; set; }
        public string UserFullname { get; set; }
    }
}
