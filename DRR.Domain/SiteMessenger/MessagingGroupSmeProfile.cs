using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.SiteMessenger
{
    public class MessagingGroupSmeProfile : Entity<int>
    {
        public MessagingGroupSmeProfile(int smeProfileId, int messagingGroupId)
        {
            SmeProfileId = smeProfileId;
            MessagingGroupId = messagingGroupId;

        }

        public int SmeProfileId { get; protected set; }
        public SmeProfile SmeProfile { get; protected set; }
        public int MessagingGroupId { get; protected set; }
        public MessagingGroup MessagingGroup { get; protected set; }

        public void Update(int smeProfileId, int siteMessageId)
        {
            SmeProfileId = smeProfileId;
            MessagingGroupId = siteMessageId;
        }
    }
}
