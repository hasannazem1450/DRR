using DRR.Application.Contracts.Queries.Profile.SmeProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Profile.SmeProfile;

public class
    ReadFilteredSmeProfileQueryHandler : IQueryHandler<ReadFilteredSmeProfileQuery, ReadFilteredSmeProfileQueryResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeProfileService _smeProfileService;

    public ReadFilteredSmeProfileQueryHandler(ISmeProfileRepository smeProfileRepository, ISmeProfileService smeProfileService)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeProfileService = smeProfileService;
    }

    public async Task<ReadFilteredSmeProfileQueryResponse> Execute(ReadFilteredSmeProfileQuery query, CancellationToken cancellationToken)
    {
        var smeProfiles = await _smeProfileRepository.ReadByFilter(query.Name ?? "", query.Page, query.PageSize);

        var result = new ReadFilteredSmeProfileQueryResponse
        {
            List = await _smeProfileService.ConvertToDto(smeProfiles)
        };

        return result;
    }
}