using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Domain.Identity.Exceptions;
using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DRR.Application.CommandHandlers.Authentication
{
    public class SignOutCommandHandler : CommandHandler<SignOutCommand, SignOutCommandResponse>
    {
        private readonly SignInManager<DRR.Domain.Identity.ApplicationUser> _signInManager;
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public SignOutCommandHandler(SignInManager<DRR.Domain.Identity.ApplicationUser> signInManager, UserManager<DRR.Domain.Identity.ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        public override async Task<SignOutCommandResponse> Executor(SignOutCommand command)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u =>
                    u.Id == _httpContextAccessor.HttpContext.User.Identity.Name);

                await _signInManager.SignOutAsync();
                await _userManager.UpdateSecurityStampAsync(user);
                return new SignOutCommandResponse()
                {
                    Message = "You Signed Out Successfully"
                };
            }
            catch (Exception e)
            {
                throw new IdentitySignOutException();
            }
        }
    }
}
