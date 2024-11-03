using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class DeleteSiteMessageImageCommand : Command
    {
        public int Id { get; set; }
    }

    public class DeleteSiteMessageImageCommandResponse : CommandResponse
    {
        public int Id { get; set; }
    }
}
