using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Queries.Profile.SmeProfile;

public class ReadLatestSmeProfilesQuery : Query
{
}

public class ReadLatestSmeProfilesQueryResponse : QueryResponse
{
    public List<SmeProfileDto> Profiles { get; set; }
}