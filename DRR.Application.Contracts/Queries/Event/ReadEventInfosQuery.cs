using DRR.Application.Contracts.Commands.Event;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Queries.Event;

public class ReadEventInfosQuery : Query
{
}

public class ReadEventInfosQueryResponse : QueryResponse
{
    public List<EventInfoDto> List { get; set; }
}