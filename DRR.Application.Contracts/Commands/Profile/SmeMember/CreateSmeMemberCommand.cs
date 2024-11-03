using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Profile.SmeMember
{
    public class CreateSmeMemberCommand : Command
    {
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }
        public int SmeProfileId { get; set; }
        public int PositionId { get; set; }
    }

    public class CreateSmeMemberCommandResponse : CommandResponse
    {
    }
}
