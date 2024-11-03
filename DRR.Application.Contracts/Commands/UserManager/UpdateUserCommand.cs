using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.UserManager
{
    public class UpdateUserCommand : Command
    {
        public string UserName { get; set; }

        public AspUserNetDto List { get; set; }
    }

    public class UpdateUserCommandResponse : CommandResponse
    {
        public string Message { get; set; }
        public string Prefix { get; set; }
        public int Code { get; set; }
    }
}
