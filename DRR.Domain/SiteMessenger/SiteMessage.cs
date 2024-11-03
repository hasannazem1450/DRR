using DRR.Domain.Identity;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.SiteMessenger
{
    public class SiteMessage : Entity<int>
    {

        public SiteMessage(string senderUserId, string messageSubject, string messageBody, int messageType, string messageImage)
        {
            MessageSubject = messageSubject;
            MessageBody = messageBody;
            MessageType = messageType;
            MessageImage = messageImage;
            SenderUserId = senderUserId;
        }
        public void Update(string messageSubject, string messageBody, int messageType, string messageImage)
        {
            MessageSubject = messageSubject;
            MessageBody = messageBody;
            MessageType = messageType;
            MessageImage = messageImage;
        }
        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
        public string MessageSubject { get; set; }
        public string MessageBody { get; set; }
        public int MessageType { get; set; }
        public string MessageImage { get; set; }
        public string SenderUserId { get; set; }

        public ApplicationUser SenderUser { get; protected set; }

        public ICollection<SiteMessageReciver> SiteMessageRecivers { get; protected set; }
    }
}
