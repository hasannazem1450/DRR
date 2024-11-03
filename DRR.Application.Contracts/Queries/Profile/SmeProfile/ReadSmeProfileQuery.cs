using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Profile.SmeProfile;

public class ReadSmeProfileQuery : Query
{
    public int Id { get; set; }
}

public class ReadSmeProfileQueryResponse : QueryResponse
{
    public SmeProfileDto Dto { get; set; }
}