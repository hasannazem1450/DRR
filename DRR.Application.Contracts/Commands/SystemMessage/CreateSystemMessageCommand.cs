using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;

namespace DRR.Application.Contracts.Commands.SystemMessage
{
    public class CreateSystemMessageCommand : Command
    {
        public TypeSystemMessage TypeMessage { get; set; }

        public int Code { get; set; }

        public List<SystemDataMessageDto> List { get; set; }
    }
}
