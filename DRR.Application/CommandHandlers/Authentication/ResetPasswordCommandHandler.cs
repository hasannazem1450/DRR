using DRR.Application.CommandHandlers.Authentication.Exceptions;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Domain.Identity;
using DRR.Framework.Contracts.Abstracts;
using DRR.Settings;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Authentication
{
    internal class ResetPasswordCommandHandler : CommandHandler<ResetPasswordCommand, ResetPasswordCommandResponse>
    {
        private readonly SignInManager<DRR.Domain.Identity.ApplicationUser> _signInManager;
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;
        private readonly JwtSetting JwtSetting;

        public ResetPasswordCommandHandler(SignInManager<DRR.Domain.Identity.ApplicationUser> signInManager, UserManager<DRR.Domain.Identity.ApplicationUser> userManager, IOptions<JwtSetting> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            JwtSetting = options.Value;
        }


        public override async Task<ResetPasswordCommandResponse> Executor(ResetPasswordCommand command)
        {
            var userSelect = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.NormalizedUserName == command.UserName.ToUpper());

            if (userSelect.ObjectIsAnyNullOrEmpty())
                throw new UserNotExistException();
            else
            {
                var tokenp = await _userManager.GeneratePasswordResetTokenAsync(userSelect);
                var userUpdate = await _userManager.ResetPasswordAsync(userSelect ,tokenp, command.Password);
                if (userUpdate != null)
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

                    return new ResetPasswordCommandResponse()
                    {
                        Token = $"Bearer {tokenString}",
                        ExpiredAt = JwtSetting.Time,
                        RefreshToken = $"Bearer {tokenString}",
                        UserFullname = userExist.Fullname ?? "",
                        Code = 1,
                        Message = "User Has Been Updated"
                    };
                }


            }

            throw new UserNotExistException();
        }
    }
}
