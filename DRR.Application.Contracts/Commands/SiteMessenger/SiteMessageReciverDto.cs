using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class SiteMessageReciverDto
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public int SmeProfileId { get; set; }
        public int? SiteMessageId { get; set; }
        public int? MessagingGroupId { get; set; }
    }
}
