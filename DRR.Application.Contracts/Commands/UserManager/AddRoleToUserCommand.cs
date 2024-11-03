using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.UserManager
{
    public class AddRoleToUserCommand : Command
    {
        public AddRoleToUserCommand(string userName, string userRoleName)
        {
            UserName = userName;
            UserRoleName = userRoleName;
        }

        public string UserName { get; set; }
        public string UserRoleName { get; set; }
    }

    public class AddRoleToUserCommandResponse : CommandResponse
    {
        public string Message { get; set; }
        public string Prefix { get; set; }
        public int Code { get; set; }
    }
}
