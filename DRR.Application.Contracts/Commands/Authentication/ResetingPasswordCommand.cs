using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Authentication
{
    public class ResetingPasswordCommand : Command
    {
        public ResetingPasswordCommand(string userName, string phoneNumber, string activationcode)
        {
            UserName = userName;
            PhoneNumber = phoneNumber;
            activationCode = activationcode;
        }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string activationCode { get; set; }
    }
    public class ResetingPasswordCommandResponse : CommandResponse
    {
        public bool IsUserOk { get; set; }
    }
}
