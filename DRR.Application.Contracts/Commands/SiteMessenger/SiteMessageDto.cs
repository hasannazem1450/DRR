using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class SiteMessageDto
    {
        public string MessageSubject { get; set; }
        public string MessageBody { get; set; }
        public int MessageType { get; set; }
        public string MessageImage { get; set; }
        public string SenderUserId { get; set; }
    }
}
