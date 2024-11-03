using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.SiteMessenger
{
    public class SiteMessageImageDto
    {
        public int Id { get; set; }
        public int SiteMessageId { get; set; }
        public Guid ImageId { get; set; }

    }
}
