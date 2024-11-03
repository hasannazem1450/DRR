using DRR.Application.Contracts.Queries.Profile.SmeProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Profile.SmeProfile;

public class ReadPreSmeProfileQueryHandler : IQueryHandler<ReadPreSmeProfileQuery, ReadPreSmeProfileQueryResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeProfileService _smeProfileService;

    public ReadPreSmeProfileQueryHandler(ISmeProfileRepository smeProfileRepository,
        ISmeProfileService smeProfileService)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeProfileService = smeProfileService;
    }


    public async Task<ReadPreSmeProfileQueryResponse> Execute(ReadPreSmeProfileQuery query,
        CancellationToken cancellationToken)
    {
        var smeProfiles = await _smeProfileRepository.Read();

        var result = new ReadPreSmeProfileQueryResponse
        {
            List = await _smeProfileService.ConvertToPreDto(smeProfiles)
        };

        return result;
    }
}