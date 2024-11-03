using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.SiteMessenger
{
    public class ReadMessagingGroupQuery : Query
    {
        public int Id { get; set; }
    }
    public class ReadMessagingGroupQueryResponse : QueryResponse
    {
        public MessagingGroup Dto { get; set; }
    }
}
