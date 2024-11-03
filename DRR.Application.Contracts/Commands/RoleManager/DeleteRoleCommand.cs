using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.RoleManager
{
    public class DeleteRoleCommand : Command
    {
        public DeleteRoleCommand(string rollName)
        {
            RollName = rollName;
        }

        public string RollName { get; set; }
    }

    public class DeleteRoleCommandResponse : CommandResponse
    {
        public string Message { get; set; }
        public string Prefix { get; set; }
        public int Code { get; set; }
    }
}
