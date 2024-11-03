using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.SiteMessenger
{
    public class SiteMessageReciver : Entity<int>
    {
        public SiteMessageReciver(int siteMessageId, int? smeProfileId, int? messagingGroupId)
        {
            IsRead = false;
            SiteMessageId = siteMessageId;
            SmeProfileId = smeProfileId;
            MessagingGroupId = messagingGroupId;
        }

        public bool IsRead { get; protected set; }

        public int SiteMessageId { get; protected set; }
        public SiteMessage SiteMessage { get; protected set; }

        public int? SmeProfileId { get; protected set; }
        public SmeProfile SmeProfile { get; protected set; }

        public int? MessagingGroupId { get; protected set; }
        public MessagingGroup MessagingGroup { get; protected set; }

        public void SetIsRead(bool isRead)
        {
            IsRead = isRead;
        }

        public void Update(int? smeProfileId, int? messagingGroupId, bool isRead)
        {
            SmeProfileId = smeProfileId;
            MessagingGroupId = messagingGroupId;
            IsRead = isRead;
        }
    }
}
