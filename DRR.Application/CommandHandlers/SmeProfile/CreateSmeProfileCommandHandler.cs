using DRR.Application.CommandHandlers.Authentication.Exceptions;
using DRR.Application.CommandHandlers.Specialists.Exceptions;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SmeProfile;

public class CreateSmeProfileCommandHandler : CommandHandler<CreateSmeProfileCommand, CreateSmeProfileCommandResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmeRaterRepository _smeRaterRepository;
    private readonly ISmeProfileService _smeProfileService;
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;

    public CreateSmeProfileCommandHandler(ISmeProfileRepository smeProfileRepository,
        ISmeRaterRepository smeRaterRepository ,ISmeProfileService smeProfileService, 
        IUserProfileRepository userProfileRepository, UserManager<DRR.Domain.Identity.ApplicationUser> userManager)
    {
        _smeProfileRepository = smeProfileRepository;
        _smeRaterRepository = smeRaterRepository;
        _smeProfileService = smeProfileService;
        _userProfileRepository = userProfileRepository;
        _userManager = userManager;
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
            var userExist = await _userManager.Users.FirstOrDefaultAsync(l => l.PhoneNumber == command.NationalCode);

            if (userExist == null)
                throw new UserNotExistException();

  
            var userprofile = new UserProfile(userExist.Id , smeProfile.Id);
            await _userProfileRepository.Create(userprofile);
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