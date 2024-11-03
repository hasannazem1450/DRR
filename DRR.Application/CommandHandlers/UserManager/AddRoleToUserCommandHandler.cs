using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.Exceptions;
using DRR.Application.Contracts.Commands.UserManager;
using DRR.Application.MessageCodes.IdentityPersianErrorsHandler;
using DRR.Domain.Identity.Exceptions;
using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace DRR.Application.CommandHandlers.UserManager
{
    public class AddRoleToUserCommandHandler : CommandHandler<AddRoleToUserCommand, AddRoleToUserCommandResponse>
    {
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleToUserCommandHandler(UserManager<DRR.Domain.Identity.ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public override async Task<AddRoleToUserCommandResponse> Executor(AddRoleToUserCommand command)
        {
            var role = await _roleManager.FindByNameAsync(command.UserRoleName);
            if (role == null)
                throw new IdentityException("رول مورد نظر وجود ندارد !", "Role is not exist");

            var user = await _userManager.FindByNameAsync(command.UserName);
            if (role == null)
                throw new IdentityException("کاربر مورد نظر وجود ندارد !", "User is not exist");

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return new AddRoleToUserCommandResponse()
                {
                    Code = 1,
                    Message = "User Role Has Been Created"
                };
            }

            throw new IdentityException(null, result.Errors.First().Description);
        }
    }
}
