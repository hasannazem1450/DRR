using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Queries.Event;

public class ReadAttenderTypesQuery : Query
{
}

public class ReadAttenderTypesQueryResponse : QueryResponse
{
    public List<EventAttenderTypeDto> List { get; set; }
}