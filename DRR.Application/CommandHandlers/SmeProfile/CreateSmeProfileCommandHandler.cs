using DRR.Application.CommandHandlers.Specialists.Exceptions;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SmeProfile;

public class CreateSmeProfileCommandHandler : CommandHandler<CreateSmeProfileCommand, CreateSmeProfileCommandResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeRaterRepository _smeRaterRepository;
    private readonly ISmeProfileService _smeProfileService;

    public CreateSmeProfileCommandHandler(ISmeProfileRepository smeProfileRepository,
        ISmeRaterRepository smeRaterRepository ,ISmeProfileService smeProfileService)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeRaterRepository = smeRaterRepository;
        _smeProfileService = smeProfileService;
    }

    public override async Task<CreateSmeProfileCommandResponse> Executor(CreateSmeProfileCommand command)
    {
        var size = await _smeProfileService.GetFileSizeKb(command.Logo);
        if (size < 30)
        {
            var smeProfile = new Domain.Profile.SmeProfile(command.SmeName, command.NationalCode, command.BusinessCode,
            command.ManagerName, command.RegisterNumber, command.EconomyCode, command.PermitNo,
            command.ManagerPhoneNumber, command.ManagerEmail, command.AboutUs, command.TellNumber,
            command.ActivitySubject, command.SmeEmail, command.SmeWebsite, command.Address, command.CityId, command.SmeRankId,
            command.Status, command.Logo, command.Headerpic, command.Postalcode,
            (SmeType)command.SmeType);

            await _smeProfileRepository.Create(smeProfile);
            return new CreateSmeProfileCommandResponse
            {
                Id = smeProfile.Id
            };
        }
        else
        {
            throw new SpecialistException();
        }
       
    }
}