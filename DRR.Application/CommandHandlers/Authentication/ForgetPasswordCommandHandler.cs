
using System.Text;
using DRR.Application.CommandHandlers.Authentication.Exceptions;
using DRR.Application.CommandHandlers.Exceptions;
using DRR.Application.Contracts.Commands;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Repository;
using DRR.Domain.Identity;
using DRR.Domain.Identity.Exceptions;
using DRR.Framework.Contracts.Abstracts;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DRR.Application.Contracts.ACLs.Sms;
using DRR.Application.Contracts.ACLs.Sms.Models;
using DRR.Settings;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DRR.Domain.Sms;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Application.Contracts.Repository.Sms;
using System.Threading.Tasks;
using System;

namespace DRR.Application.CommandHandlers.Authentication
{
    public class ForgetPasswordCommandHandler : CommandHandler<ForgetPasswordCommand, ForgetPasswordCommandResponse>
    {
        private readonly SignInManager<DRR.Domain.Identity.ApplicationUser> _signInManager;
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;
        private readonly ISmsInfoRepository _smsInfoRepository;
        private readonly JwtSetting JwtSetting;
        private readonly SmsSetting _smsSetting;
        private readonly ISmsAcl _smsAcl;

        public ForgetPasswordCommandHandler(ISmsInfoRepository smsInfoRepository, SignInManager<DRR.Domain.Identity.ApplicationUser> signInManager, UserManager<DRR.Domain.Identity.ApplicationUser> userManager, IOptions<JwtSetting> options, ISmsAcl smsAcl, IOptions<SmsSetting> smsOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _smsAcl = smsAcl;
            _smsSetting = smsOptions.Value;
            JwtSetting = options.Value;
            _smsInfoRepository = smsInfoRepository;
        }



        //todo
        public override async Task<ForgetPasswordCommandResponse> Executor(ForgetPasswordCommand command)
        {
            if (command.UserName.IsNullOrEmptyExtension())
                throw new UserNameAndPasswordAreNullException();
            if (command.PhoneNumber.Length != 13 && command.UserName.Length != 10)
                throw new UserNameOrPhoneNumberIsNotValidException();
            if (!command.UserName.IsNationalCodeValid())
                throw new IdentityException("شماره ملی معتبر نمیباشد .", "NationalCode is not valid .");


            var user = new ApplicationUser
            {
                UserName = command.UserName,
                PhoneNumber = command.PhoneNumber.ConvertToValidMobile()
            };

            var userExist = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == command.UserName.ToUpper());
            if (userExist != null)
            {
                //////////////////////////////////////////////////sms
                var activationCode = new Random().Next(10000, 99999).ToString();
                var message = _smsSetting.ActivatingRegistrationMessage.Replace("{activationCode}", activationCode);
                var receiverMobile = command.PhoneNumber.RemoveMobilePrefix();

                var smsAclOutputModel = await _smsAcl.Send(new SmsAclInputModel { Message = message, Receiver = receiverMobile });
                if (!smsAclOutputModel.IsSuccess)
                    throw new ActivatingCodeNotSendedException();

                var smsInfo = new SmsInfo(_smsSetting.Sender, receiverMobile.ConvertToValidMobile(), message, activationCode,
                    SmsType.ActivatingRegistration);

                await _smsInfoRepository.Create(smsInfo);
                /////////////
                return new ForgetPasswordCommandResponse()
                {
                Message = "Sms Sent..."
                };
            }

            throw new IdentityException(null, "problem");
        }
    }
}
