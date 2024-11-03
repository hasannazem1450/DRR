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
    public class CreateRoleCommandHandler : CommandHandler<CreateRoleCommand, CreateRollCommandResponse>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public override async Task<CreateRollCommandResponse> Executor(CreateRoleCommand command)
        {
            var roll = new IdentityRole(command.RollName);
            var result = await _roleManager.CreateAsync(roll);

            if (result.Succeeded)
            {
                return new CreateRollCommandResponse()
                {
                    Message = "Role Has Been Created Successfully"
                };
            }
            else
            {
                throw new CreateRoleException(result.Errors.First().Description);
            }
        }
    }
}
