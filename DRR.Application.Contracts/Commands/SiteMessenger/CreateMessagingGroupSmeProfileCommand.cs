using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class CreateMessagingGroupSmeProfileCommand : Command
    {
    }
    public class CreateMessagingGroupSmeProfileCommandResponse : CommandResponse
    {
        public int Id { get; set; }
    }
}
