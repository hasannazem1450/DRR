using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class CreateSiteMessageCommand : Command
    {
        public string MessageSubject { get; set; }
        public string MessageBody { get; set; }
        public int MessageType { get; set; }
        public string MessageImage { get; set; }
        public string senderUserId { get; set; }
    }
    public class CreateSiteMessageCommandResponse : CommandResponse
    {
        public int Id { get; set; }
    }
}
