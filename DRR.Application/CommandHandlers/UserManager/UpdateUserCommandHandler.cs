using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.Exceptions;
using DRR.Application.Contracts.Commands.UserManager;
using DRR.Domain.Identity.Exceptions;
using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DRR.Application.CommandHandlers.UserManager
{
    public class UpdateUserHandler : CommandHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;

        public UpdateUserHandler(UserManager<DRR.Domain.Identity.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public override async Task<UpdateUserCommandResponse> Executor(UpdateUserCommand command)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == command.UserName);

            if (user == null)
                throw new IdentityException("کاربر مورد نظر وجود ندارد !", "User is not exist !");

            user.UserName = command.List.UserName;
            user.NormalizedUserName = command.List.NormalizedUserName;
            user.Email = command.List.Email;
            user.EmailConfirmed = command.List.EmailConfirmed;
            user.PasswordHash = command.List.PasswordHash;
            user.SecurityStamp = command.List.SecurityStamp;
            user.ConcurrencyStamp = command.List.ConcurrencyStamp;
            user.PhoneNumber = command.List.PhoneNumber;
            user.PhoneNumberConfirmed = command.List.PhoneNumberConfirmed;
            user.TwoFactorEnabled = command.List.TwoFactorEnabled;
            user.LockoutEnabled = command.List.LockoutEnabled;
            user.AccessFailedCount = command.List.AccessFailedCount;

            

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new UpdateUserCommandResponse()
                {
                    Message = "User has been updated successfully"
                };
            }

            throw new IdentityException(null, result.Errors.First().Description);

        }
    }
}
