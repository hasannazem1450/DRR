using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Authentication
{
    public class ForgetPasswordCommand : Command
    {
        public ForgetPasswordCommand(string userName, string phoneNumber)
        {
            UserName = userName;
            PhoneNumber = phoneNumber;
        }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ForgetPasswordCommandResponse : CommandResponse
    {
        public string Message { get; set; }
    }
}
