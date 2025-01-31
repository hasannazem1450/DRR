using DRR.Application.CommandHandlers.SmeProfile.Exceptions;
using DRR.Application.CommandHandlers.Specialists.Exceptions;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SmeProfile;

public class UpdateSmeProfileCommandHandler : CommandHandler<UpdateSmeProfileCommand, UpdateSmeProfileCommandResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeRaterRepository _smeRaterRepository;
    private readonly ISmeProfileService _smeProfileService;

    public UpdateSmeProfileCommandHandler(ISmeProfileRepository smeProfileRepository,
        ISmeRaterRepository smeRaterRepository)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeRaterRepository = smeRaterRepository;
    }

    public override async Task<UpdateSmeProfileCommandResponse> Executor(UpdateSmeProfileCommand command)
    {
        var smeProfile = await _smeProfileRepository.ReadById(command.Id);

        if (smeProfile == null)
            throw new SmeProfileNotExistException();

        var size = await _smeProfileService.GetFileSizeKb(command.Logo);

        if (size < 30)
        {
            smeProfile.Update(command.SmeName, command.NationalCode, command.BusinessCode, command.ManagerName,
          command.RegisterNumber, command.EconomyCode, command.PermitNo, command.ManagerPhoneNumber,
          command.ManagerEmail, command.AboutUs, command.TellNumber, command.ActivitySubject, command.SmeEmail,
          command.SmeWebsite, command.Address, command.CityId, command.SmeRankId, command.Status, command.Logo,
          command.Headerpic, command.Postalcode, (SmeType)command.SmeType);

            await _smeProfileRepository.Update(smeProfile);

            return new UpdateSmeProfileCommandResponse();
        }
        else
        {
            throw new SpecialistException();
        }


    }
}