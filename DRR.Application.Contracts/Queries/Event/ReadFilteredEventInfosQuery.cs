using DRR.Application.Contracts.Commands.Event;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Queries.Event;

public class ReadFilteredEventInfosQuery : Query
{
    public string? Name { get; set; }
    public int? ProvinceId { get; set; }
    public int[]? States { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}

public class ReadFilteredEventInfosQueryResponse : QueryResponse
{ 
    public List<EventInfoDto> List { get; set; }
}