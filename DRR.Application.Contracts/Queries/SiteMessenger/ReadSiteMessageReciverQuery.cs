using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.SiteMessenger
{
    public class ReadSiteMessageReciverQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadSiteMessageReciverQueryResponse : QueryResponse
    {
        public SiteMessageReciverDto Dto { get; set; }
    }
}
