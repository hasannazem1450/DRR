using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class CreateSiteMessageReciverCommand : Command
    {
        public int SiteMessageId { get; set; }
        public List<int>? SmeProfileIdList { get; set; }
        public List<int>? MessagingGroupIdList { get; set; }
    }
    public class CreateSiteMessageReciverCommandResponse : CommandResponse
    {
    }
}
