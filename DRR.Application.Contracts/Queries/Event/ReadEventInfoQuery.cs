using DRR.Application.Contracts.Commands.Event;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Event;

public class ReadEventInfoQuery : Query
{
    public int Id { get; set; }
}

public class ReadEventInfoQueryResponse : QueryResponse
{
    public EventInfoDto Data { get; set; }
}