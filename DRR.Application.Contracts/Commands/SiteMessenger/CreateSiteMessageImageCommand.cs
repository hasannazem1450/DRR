using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class CreateSiteMessageImageCommand : Command
    {
        public int SiteMessageId { get; set; }
        public Guid ImageId { get; set; }
    }

    public class CreateSiteMessageImageCommandResponse : CommandResponse
    {
        public int Id { get; set; }
    }
}
