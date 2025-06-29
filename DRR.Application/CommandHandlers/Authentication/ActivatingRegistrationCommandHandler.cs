using DRR.Application.CommandHandlers.Authentication.Exceptions;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Repository.Sms;
using DRR.Domain.Identity.Exceptions;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Settings;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Repository.Profile;
using Microsoft.Extensions.Options;
using DRR.Application.Contracts.Repository.Customer;

namespace DRR.Application.CommandHandlers.Authentication;

public class ActivatingRegistrationCommandHandler : CommandHandler<ActivatingRegistrationCommand,
    ActivatingRegistrationCommandResponse>
{
    private readonly SignInManager<DRR.Domain.Identity.ApplicationUser> _signInManager;
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly ISmeProfileRepository _smeProfileRepository;
    private readonly ISmsInfoRepository _smsInfoRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;
    private readonly JwtSetting JwtSetting;

    public ActivatingRegistrationCommandHandler(ISmsInfoRepository smsInfoRepository, 
        UserManager<DRR.Domain.Identity.ApplicationUser> userManager, 
        SignInManager<DRR.Domain.Identity.ApplicationUser> signInManager, 
        IOptions<JwtSetting> options, IUserProfileRepository userProfileRepository, 
        IPatientRepository patientRepository, ISmeProfileRepository smeProfileRepository)
    {
        _smsInfoRepository = smsInfoRepository;
        _userManager = userManager;
        _signInManager = signInManager;
        JwtSetting = options.Value;
        _userProfileRepository = userProfileRepository;
        _patientRepository = patientRepository;
        _smeProfileRepository = smeProfileRepository;
    }

    public override async Task<ActivatingRegistrationCommandResponse> Executor(ActivatingRegistrationCommand command)
    {
        var smsInfo = await _smsInfoRepository.ReadLastByReceiverNumber(command.Mobile.ConvertToValidMobile(), SmsType.ActivatingRegistration);

        if (smsInfo != null && smsInfo.Code != command.ActivationCode)
            throw new ActivatingCodeIsInvalidException();

        var userUpdate = _userManager.Users.OrderByDescending(x => x.Id).FirstOrDefault(x => x.PhoneNumber == command.Mobile.ConvertToValidMobile());
        DRR.Domain.Profile.SmeProfile smeprofile = null;
        if (userUpdate != null)
        {
            userUpdate.PhoneNumberConfirmed = true;
            await _userManager.UpdateAsync(userUpdate);

            //var signOn = await _signInManager.PasswordSignInAsync(userUpdate.UserName, "Nn123456", false , false);
            //if (!signOn.Succeeded) throw new IdentityUsernameOrPasswordException();



            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEYMY_BIG_SECRET_KEYMY_BIG_SECRET_KEYMY_BIG_SECRET_KEY@#");
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim(ClaimTypes.Name, userUpdate.Id)
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(JwtSetting.Time)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenString = tokenHandler.WriteToken(token);

            await _userManager.RemoveAuthenticationTokenAsync(userUpdate, userUpdate.Id, tokenString);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(userUpdate, "Default", tokenString);
            await _userManager.SetAuthenticationTokenAsync(userUpdate, userUpdate.UserName, "Authorization", tokenString);

            int smeProfileid = 0;

            
            var smer = _userProfileRepository.ReadByUserId(new Guid(userUpdate.Id));
            if (smer.Result.Count() > 0)
            { 
                smeProfileid = smer.Result.FirstOrDefault().SmeProfileId;
                smeprofile = await _smeProfileRepository.ReadById(smeProfileid);
            }
            else
            {
                var smep = new DRR.Domain.Profile.SmeProfile(userUpdate.Fullname, userUpdate.UserName, userUpdate.UserName, userUpdate.Id,
                    "", "", "", "", "", "", "", "", "", "", "", 1, 2, true, "", "", "", SmeType.Business);
                await _smeProfileRepository.Create(smep);
                smeProfileid = smep.Id;
                smeprofile = smep;
            }


            return new ActivatingRegistrationCommandResponse()
            {
                Token = $"Bearer {tokenString}",
                ExpiredAt = JwtSetting.Time,
                RefreshToken = $"Bearer {tokenString}",
                UserFullname = userUpdate.Fullname ?? "",
                SmeprofileId = smeProfileid,
                Smeprofile = smeprofile,
                Patients = await _patientRepository.ReadPatientBySmeProfileId(smeProfileid),
            };
        }

        return new ActivatingRegistrationCommandResponse();
    }
}