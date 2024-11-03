using DRR.Application.CommandHandlers.Authentication.Exceptions;
using DRR.Application.Contracts.ACLs.Sms;
using DRR.Application.Contracts.ACLs.Sms.Models;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Repository.Sms;
using DRR.Domain.Sms;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Settings;
using DRR.Utilities.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Authentication;

public class
    GenerateRegistrationCodeCommandHandler : CommandHandler<GenerateRegistrationCodeCommand,
        GenerateRegistrationCodeCommandResponse>
{
    private readonly ISmsAcl _smsAcl;
    private readonly ISmsInfoRepository _smsInfoRepository;
    private readonly SmsSetting _smsSetting;

    public GenerateRegistrationCodeCommandHandler(ISmsAcl smsAcl, ISmsInfoRepository smsInfoRepository,
        IOptions<SmsSetting> smsOptions)
    {
        _smsAcl = smsAcl;
        _smsInfoRepository = smsInfoRepository;
        _smsSetting = smsOptions.Value;
    }

    public override async Task<GenerateRegistrationCodeCommandResponse> Executor(
        GenerateRegistrationCodeCommand command)
    {
        var activationCode = new Random().Next(10000, 99999).ToString();
        var message = _smsSetting.ActivatingRegistrationMessage.Replace("{activationCode}", activationCode);
        var receiverMobile = command.Mobile.RemoveMobilePrefix();

        var smsAclOutputModel = await _smsAcl.Send(new SmsAclInputModel { Message = message, Receiver = receiverMobile });

        if (!smsAclOutputModel.IsSuccess)
            throw new ActivatingCodeNotSendedException();

        var smsInfo = new SmsInfo(_smsSetting.Sender, receiverMobile.ConvertToValidMobile(), message, activationCode,
            SmsType.ActivatingRegistration);

        await _smsInfoRepository.Create(smsInfo);

        return new GenerateRegistrationCodeCommandResponse();
    }
}