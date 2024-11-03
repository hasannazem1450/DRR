using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Queries.Profile.SmeProfile;

public class ReadFilteredSmeProfileQuery : Query
{
    public string? Name { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class ReadFilteredSmeProfileQueryResponse : QueryResponse
{
    public List<SmeProfileDto> List { get; set; }
}