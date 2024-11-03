using DRR.Application.Contracts.Queries.Profile.SmeProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Profile.SmeProfile;

public class ReadSmeProfileQueryHandler : IQueryHandler<ReadSmeProfileQuery, ReadSmeProfileQueryResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeProfileService _smeProfileService;

    public ReadSmeProfileQueryHandler(ISmeProfileRepository smeProfileRepository, ISmeProfileService smeProfileService)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeProfileService = smeProfileService;
    }

    public async Task<ReadSmeProfileQueryResponse> Execute(ReadSmeProfileQuery query,
        CancellationToken cancellationToken)
    {
        var smeProfile = await _smeProfileRepository.ReadById(query.Id);

        var result = new ReadSmeProfileQueryResponse
        {
            Dto = await _smeProfileService.ConvertToDto(smeProfile)
        };

        return result;
    }
}