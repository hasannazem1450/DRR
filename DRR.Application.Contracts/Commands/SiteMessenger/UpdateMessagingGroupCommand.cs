using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class UpdateMessagingGroupCommand : Command
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
    public class UpdateMessagingGroupCommandResponse : CommandResponse
    {
        public int Id { get; set; }
    }
}