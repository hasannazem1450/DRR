using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Profile.Position
{
    public class CreatePositionCommand : Command
    {
        public string Name { get; set; }
    }

    public class CreatePositionCommandResponse : CommandResponse
    {
    }
}
