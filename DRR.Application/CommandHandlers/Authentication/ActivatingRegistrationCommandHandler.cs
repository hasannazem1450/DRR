using DRR.Application.CommandHandlers.Authentication.Exceptions;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Repository.Sms;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Authentication;

public class ActivatingRegistrationCommandHandler : CommandHandler<ActivatingRegistrationCommand,
    ActivatingRegistrationCommandResponse>
{

    private readonly ISmsInfoRepository _smsInfoRepository;
    private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;

    public ActivatingRegistrationCommandHandler(ISmsInfoRepository smsInfoRepository, UserManager<DRR.Domain.Identity.ApplicationUser> userManager)
    {
        _smsInfoRepository = smsInfoRepository;
        _userManager = userManager;
    }

    public override async Task<ActivatingRegistrationCommandResponse> Executor(ActivatingRegistrationCommand command)
    {
        var smsInfo = await _smsInfoRepository.ReadLastByReceiverNumber(command.Mobile.ConvertToValidMobile(), SmsType.ActivatingRegistration);

        if (smsInfo != null && smsInfo.Code != command.ActivationCode)
            throw new ActivatingCodeIsInvalidException();

        var userUpdate = _userManager.Users.OrderByDescending(x => x.Id).FirstOrDefault(x => x.PhoneNumber == command.Mobile);
        if (userUpdate != null)
        {
            userUpdate.PhoneNumberConfirmed = true;
            await _userManager.UpdateAsync(userUpdate);
        }

        return new ActivatingRegistrationCommandResponse();
    }
}