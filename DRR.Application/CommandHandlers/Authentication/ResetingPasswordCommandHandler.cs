using DRR.Application.CommandHandlers.Exceptions;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Domain.Identity;
using DRR.Framework.Contracts.Abstracts;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Authentication
{
    public class ResetingPasswordCommandHandler : CommandHandler<ResetingPasswordCommand, ResetingPasswordCommandResponse>
    {

        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;

        public ResetingPasswordCommandHandler(UserManager<DRR.Domain.Identity.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<ResetingPasswordCommandResponse> Executor(ResetingPasswordCommand command)
        {
            
            var user = new ApplicationUser
            {
                UserName = command.UserName,
                PhoneNumber = command.PhoneNumber.ConvertToValidMobile()
            };

            var userExist = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == command.UserName.ToUpper());
            if (userExist != null)
            {
                return new ResetingPasswordCommandResponse()
                {
                    IsUserOk = true
                };
            }

            throw new IdentityException(null, "problem");
        }
    }
}
