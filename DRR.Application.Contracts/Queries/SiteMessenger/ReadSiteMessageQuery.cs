using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.SiteMessenger
{
    public class ReadSiteMessageQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadSiteMessageQueryResponse : QueryResponse
    {
        public SiteMessageDto Dto { get; set; }
    }
}
