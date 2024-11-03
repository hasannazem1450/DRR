using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.SiteMessenger
{
    public class ReadRecivedMessageQuery : Query
    {
        public Guid UserId { get; set; }
    }
    public class ReadRecivedMessageQueryResponse : QueryResponse
    {
        public List<SiteMessageDto> List { get; set; }
    }
}
