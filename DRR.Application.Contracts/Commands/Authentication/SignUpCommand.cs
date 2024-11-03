using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Authentication
{
    public class SignUpCommand : Command
    {
        public SignUpCommand(string userName, string password, string phoneNumber, string fullname)
        {
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;
            Fullname = fullname;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname { get; set; }
    }

    public class SignUpCommandResponse : CommandResponse
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
