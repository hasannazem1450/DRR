using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Profile;

public interface ISmeProfileService : IService
{
    Task<List<SmeProfileDto>> ConvertToDto(List<SmeProfile> smeProfiles);
    Task<SmeProfileDto> ConvertToDto(SmeProfile smeProfile);

    Task<List<PreSmeProfileDto>> ConvertToPreDto(List<SmeProfile> smeProfiles);
    Task<PreSmeProfileDto> ConvertToPreDto(SmeProfile smeProfile);
}