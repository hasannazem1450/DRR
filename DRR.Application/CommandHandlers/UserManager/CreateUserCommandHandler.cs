using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.Exceptions;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Commands.UserManager;
using DRR.Domain.Identity;
using DRR.Domain.Identity.Exceptions;
using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace DRR.Application.CommandHandlers.UserManager
{
    public class CreateUserCommandHandler : CommandHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;

        public CreateUserCommandHandler(UserManager<DRR.Domain.Identity.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public override async Task<CreateUserCommandResponse> Executor(CreateUserCommand command)
        {
            var user = new ApplicationUser
            {
                UserName = command.UserName,
                Email = command.Email,
            };

            var userCreate = await _userManager.CreateAsync(user, command.Password);
            if (userCreate.Succeeded)
            {
                return new CreateUserCommandResponse()
                {
                    Code = 1,
                    Message = "User Has Been Created"
                };
            }

            throw new IdentityException(null, userCreate.Errors.First().Description);

        }
    }
}
