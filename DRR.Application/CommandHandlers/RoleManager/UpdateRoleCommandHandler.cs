using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.RoleManager;
using DRR.Domain.Identity.Exceptions;
using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace DRR.Application.CommandHandlers.RoleManager
{
    public class UpdateRoleCommandHandler : CommandHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UpdateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public override async Task<UpdateRoleCommandResponse> Executor(UpdateRoleCommand command)
        {
            var role = await _roleManager.FindByNameAsync(command.OldRoleName);

            if (role == null)
                throw new DeleteRoleException("Role Does Not Exist");

            role.Name = command.NewRoleName;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return new UpdateRoleCommandResponse()
                {
                    Message = "Role Has Been Updated Successfully"
                };
            }
            else
            {
                throw new DeleteRoleException(result.Errors.First().ToString());
            }
        }
    }
}
