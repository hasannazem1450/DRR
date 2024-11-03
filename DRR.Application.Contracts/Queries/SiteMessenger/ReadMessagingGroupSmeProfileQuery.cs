using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.SiteMessenger
{
    public class ReadMessagingGroupSmeProfileQuery : Query
    {
        public int Id { get; set; }
    }

    public class ReadMessagingGroupSmeProfileQueryResponse : QueryResponse
    {
        public MessagingGroupSmeProfile Dto { get; set; }
    }
}
