using DRR.Domain.FileManagement;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.SiteMessenger
{
    public class SiteMessageImage : Entity<int>
    {
        public SiteMessageImage(int siteMessageId, Guid imageId)
        {
            SiteMessageId = siteMessageId;
            ImageId = imageId;
        }

        public int SiteMessageId { get; protected set; }
        public SiteMessage SiteMessage { get; protected set; }

        public Guid ImageId { get; protected set; }
        public DRRFile Image { get; protected set; }

        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
    }
}
