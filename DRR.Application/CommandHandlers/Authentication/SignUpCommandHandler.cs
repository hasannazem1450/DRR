
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
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DRR.Application.CommandHandlers.Authentication
{
    public class SignUpCommandHandler : CommandHandler<SignUpCommand, SignUpCommandResponse>
    {
        private readonly SignInManager<DRR.Domain.Identity.ApplicationUser> _signInManager;
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;
        private readonly ISmsInfoRepository _smsInfoRepository;
        private readonly JwtSetting JwtSetting;
        private readonly SmsSetting _smsSetting;
        private readonly ISmsAcl _smsAcl;

        public SignUpCommandHandler(ISmsInfoRepository smsInfoRepository, SignInManager<DRR.Domain.Identity.ApplicationUser> signInManager, UserManager<DRR.Domain.Identity.ApplicationUser> userManager, IOptions<JwtSetting> options, ISmsAcl smsAcl, IOptions<SmsSetting> smsOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _smsAcl = smsAcl;
            _smsSetting = smsOptions.Value;
            JwtSetting = options.Value;
            _smsInfoRepository = smsInfoRepository;
        }


        //public override async Task<SignUpCommandResponse> Executor(SignUpCommand command)
        //{
        //    if (command.PhoneNumber.Length != 13 && command.UserName.Length != 10)
        //        throw new UserNameOrPhoneNumberIsNotValidException();
        //    if (!command.UserName.IsNationalCodeValid())
        //        throw new IdentityException("شماره ملی معتبر نمیباشد .", "NationalCode is not valid .");


        //    var user = new ApplicationUser
        //    {
        //        UserName = command.UserName,
        //        PhoneNumber = command.PhoneNumber,
        //        Fullname = command.Fullname
        //    };

        //    var userCreate = await _userManager.CreateAsync(user, command.Password);
        //    if (userCreate.Succeeded)
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEY@#");
        //        var tokenDescription = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //                {
        //                    new Claim(ClaimTypes.Name, userExist.Id)
        //                }
        //            ),
        //            Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(JwtSetting.Time)),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
        //                SecurityAlgorithms.HmacSha256Signature),
        //        };
        //        var token = tokenHandler.CreateToken(tokenDescription);
        //        var tokenString = tokenHandler.WriteToken(token);

        //        await _userManager.RemoveAuthenticationTokenAsync(userExist, userExist.Id, tokenString);
        //        var newRefreshToken = await _userManager.GenerateUserTokenAsync(userExist, "Default", tokenString);
        //        await _userManager.SetAuthenticationTokenAsync(userExist, userExist.UserName, "Authorization", tokenString);

        //        return new SignUpCommandResponse()
        //        {
        //            Token = $"Bearer {tokenString}",
        //            ExpiredAt = JwtSetting.Time,
        //            RefreshToken = $"Bearer {tokenString}",
        //            UserFullname = userExist.Fullname ?? "",
        //            Code = 1,
        //            Message = "User Has Been Created"
        //        };
        //    }


        //    throw new IdentityException(null, userCreate.Errors.First().Description);

        //}

        //todo
        public override async Task<SignUpCommandResponse> Executor(SignUpCommand command)
        {
            ////
            ///halat sabtnam va vorood ba code paiamaki
            ///
            ///

            if (command.UserName.Length == 11)
            {
                var usertemp = new ApplicationUser
                {
                    UserName = command.UserName,
                    PhoneNumber = command.UserName.ConvertToValidMobile(),
                    Fullname = command.Fullname,
                    
                };
                var usertempExist = await _userManager.Users.FirstOrDefaultAsync(l => l.UserName == command.UserName);

                if (usertempExist == null)
                { //throw new UserNotExistException();
                    var usertempCreate = await _userManager.CreateAsync(usertemp, "String123456");
                    if (usertempCreate.Succeeded)
                    {
                        if (command.UserName.IsNullOrEmptyExtension())
                            throw new UserNameAndPasswordAreNullException();

                        //////////////////////////////////////////////////sms
                        var activationCode = new Random().Next(10000, 99999).ToString();
                        var message = _smsSetting.ActivatingRegistrationMessage.Replace("{activationCode}", activationCode);
                        var receiverMobile = command.UserName.RemoveMobilePrefix();

                        var smsAclOutputModel = await _smsAcl.Send(new SmsAclInputModel { Message = message, Receiver = receiverMobile });
                        if (!smsAclOutputModel.IsSuccess)
                            throw new ActivatingCodeNotSendedException();

                        var smsInfo = new SmsInfo(_smsSetting.Sender, receiverMobile.ConvertToValidMobile(), message, activationCode,
                            SmsType.ActivatingRegistration);

                        await _smsInfoRepository.Create(smsInfo);
                        /////////////
                        return null;

                    }
                }else
                {
                    var activationCode = new Random().Next(10000, 99999).ToString();
                    var message = _smsSetting.ActivatingRegistrationMessage.Replace("{activationCode}", activationCode);
                    var receiverMobile = command.UserName.RemoveMobilePrefix();

                    var smsAclOutputModel = await _smsAcl.Send(new SmsAclInputModel { Message = message, Receiver = receiverMobile });
                    if (!smsAclOutputModel.IsSuccess)
                        throw new ActivatingCodeNotSendedException();

                    var smsInfo = new SmsInfo(_smsSetting.Sender, receiverMobile.ConvertToValidMobile(), message, activationCode,
                        SmsType.ActivatingRegistration);

                    await _smsInfoRepository.Create(smsInfo);
                    /////////////
                    return null;
                }
                
            }




            ////
            ///halat sabtnam va vorood ba ramz sabet
            ///
            ///
            if (command.PhoneNumber.Length != 13 && command.UserName.Length != 10)
                throw new UserNameOrPhoneNumberIsNotValidException();
            if (!command.UserName.IsNationalCodeValid())
                throw new IdentityException("شماره ملی معتبر نمیباشد .", "NationalCode is not valid .");
            ApplicationUser user;
            if (_userManager.FindByNameAsync(command.UserName).Result != null)
            {
                user = _userManager.FindByNameAsync(command.UserName).Result;
                if (user.PhoneNumberConfirmed != true)
                {
                    user.PhoneNumber = command.PhoneNumber.ConvertToValidMobile();
                    user.Fullname = command.Fullname;
                    await _userManager.UpdateAsync(user);
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


                    if (command.UserName.Length == 10)
                    {
                        var userExist = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == command.UserName.ToUpper());
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEYMY_BIG_SECRET_KEYMY_BIG_SECRET_KEYMY_BIG_SECRET_KEY@#");
                        var tokenDescription = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                                {
                            new Claim(ClaimTypes.Name, userExist.Id)
                                }
                            ),
                            Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(JwtSetting.Time)),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature),
                        };
                        var token = tokenHandler.CreateToken(tokenDescription);
                        var tokenString = tokenHandler.WriteToken(token);

                        await _userManager.RemoveAuthenticationTokenAsync(userExist, userExist.Id, tokenString);
                        var newRefreshToken = await _userManager.GenerateUserTokenAsync(userExist, "Default", tokenString);
                        await _userManager.SetAuthenticationTokenAsync(userExist, userExist.UserName, "Authorization", tokenString);

                        return new SignUpCommandResponse()
                        {
                            Token = $"Bearer {tokenString}",
                            ExpiredAt = JwtSetting.Time,
                            RefreshToken = $"Bearer {tokenString}",
                            UserFullname = userExist.Fullname ?? "",
                            Code = 1,
                            Message = "User Has Been Created"
                        };
                    }
                }
            }
            else
            {
                user = new ApplicationUser
                {
                    UserName = command.UserName,
                    PhoneNumber = command.PhoneNumber.ConvertToValidMobile(),
                    Fullname = command.Fullname
                };
                var userCreate = await _userManager.CreateAsync(user, command.Password);
                if (userCreate.Succeeded)
                {
                    if (command.UserName.IsNullOrEmptyExtension())
                        throw new UserNameAndPasswordAreNullException();

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


                    if (command.UserName.Length == 10)
                    {
                        var userExist = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == command.UserName.ToUpper());
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEYMY_BIG_SECRET_KEYMY_BIG_SECRET_KEYMY_BIG_SECRET_KEY@#");
                        var tokenDescription = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                                {
                            new Claim(ClaimTypes.Name, userExist.Id)
                                }
                            ),
                            Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(JwtSetting.Time)),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature),
                        };
                        var token = tokenHandler.CreateToken(tokenDescription);
                        var tokenString = tokenHandler.WriteToken(token);

                        await _userManager.RemoveAuthenticationTokenAsync(userExist, userExist.Id, tokenString);
                        var newRefreshToken = await _userManager.GenerateUserTokenAsync(userExist, "Default", tokenString);
                        await _userManager.SetAuthenticationTokenAsync(userExist, userExist.UserName, "Authorization", tokenString);

                        return new SignUpCommandResponse()
                        {
                            Token = $"Bearer {tokenString}",
                            ExpiredAt = JwtSetting.Time,
                            RefreshToken = $"Bearer {tokenString}",
                            UserFullname = userExist.Fullname ?? "",
                            Code = 1,
                            Message = "User Has Been Created"
                        };
                    }
                    //TODO:FindByPhoneNumber
                    else
                    {
                        if (command.UserName.Length != 13)
                        {
                            command.UserName = command.UserName.ConvertToValidMobile();
                        }

                        var userExist = await _userManager.Users.FirstOrDefaultAsync(l => l.PhoneNumber == command.UserName);

                        if (userExist == null)
                            throw new UserNotExistException();

                        var signOn = await _signInManager.PasswordSignInAsync(userExist.UserName, command.Password, false, false);

                        if (!signOn.Succeeded) throw new IdentityUsernameOrPasswordException();


                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEYMY_BIG_SECRET_KEYMY_BIG_SECRET_KEYMY_BIG_SECRET_KEY@#");
                        var tokenDescription = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                                {
                            new Claim(ClaimTypes.Name, userExist.Id)
                                }
                            ),
                            Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(JwtSetting.Time)),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature),
                        };
                        var token = tokenHandler.CreateToken(tokenDescription);
                        var tokenString = tokenHandler.WriteToken(token);


                        await _userManager.RemoveAuthenticationTokenAsync(userExist, userExist.Id, tokenString);
                        var newRefreshToken = await _userManager.GenerateUserTokenAsync(userExist, "Default", tokenString);
                        await _userManager.SetAuthenticationTokenAsync(userExist, userExist.UserName, "Authorization", tokenString);

                        return new SignUpCommandResponse()
                        {
                            Token = $"Bearer {tokenString}",
                            ExpiredAt = JwtSetting.Time,
                            RefreshToken = $"Bearer {tokenString}",
                            Code = 1,
                            Message = "User Has Been Created"
                        };
                    }



                }

                throw new IdentityException(null, userCreate.Errors.First().Description);
            }


            return new SignUpCommandResponse();

        }
    }
}
