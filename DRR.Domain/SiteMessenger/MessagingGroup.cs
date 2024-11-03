using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.SiteMessenger
{
    public class MessagingGroup : Entity<int>
    {
        public MessagingGroup(string name)
        {
            Name = name;
        }
        public void Update(string name)
        {
            Name = name;
        }
        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
        public string Name { get; protected set; }

        public ICollection<MessagingGroupSmeProfile> MessagingGroupSmeProfiles { get; protected set; }
        public ICollection<SiteMessageReciver> SiteMessageRecivers { get; protected set; }
    }
}
