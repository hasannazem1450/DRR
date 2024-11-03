using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class UpdateMessagingGroupSmeProfileCommand : Command
    {
        public int SmeProfileId { get; set; }
        public int MessagingGroupId { get; set; }
    }
    public class UpdateMessagingGroupSmeProfileCommandResponse : CommandResponse
    {
        public int Id { get; set; }
    }
}
