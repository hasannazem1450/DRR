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
    public class DeleteRoleCommandHandler : CommandHandler<DeleteRoleCommand, DeleteRoleCommandResponse>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public override async Task<DeleteRoleCommandResponse> Executor(DeleteRoleCommand command)
        {
            var roll = await _roleManager.FindByNameAsync(command.RollName);
            if (roll == null)
                throw new DeleteRoleException("Role Does Not Exist");
            
            var result = await _roleManager.DeleteAsync(roll);

            if (result.Succeeded)
            {
                return new DeleteRoleCommandResponse()
                {
                    Message = "Role Has Been Deleted Successfully"
                };
            }
            else
            {
                throw new DeleteRoleException(result.Errors.First().ToString());
            }
        }
    }
}
