using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class UpdateSiteMessageReciverCommand : Command
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public int SmeProfileId { get; set; }
        public int? SiteMessageId { get; set; }
        public int? MessagingGroupId { get; set; }
    }
    public class UpdateSiteMessagereciverCommandResponse : CommandResponse
    {
    }
}