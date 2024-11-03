using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.RoleManager;
using DRR.Application.Contracts.Commands.UserManager;
using DRR.Application.Contracts.Queries.RoleManager;
using DRR.Application.Contracts.Queries.UserManager;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.UserManager
{
    public class UserManagerController : MainController
    {
        public UserManagerController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateUserCommand, CreateUserCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-user")]
        public async Task<IActionResult> ReadUser([FromQuery]ReadUserQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadUserQuery, ReadUserQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteUserCommand, DeleteUserCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> ReadUser(UpdateUserCommand command,CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateUserCommand, UpdateUserCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPost("add-role-to-user")]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<AddRoleToUserCommand, AddRoleToUserCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-user-role")]
        public async Task<IActionResult> ReadUserRole([FromQuery]ReadUserRoleQuery command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadUserRoleQuery, ReadUserRoleQueryResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-user-role")]
        public async Task<IActionResult> DeleteUserRole(DeleteUserRoleCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteUserRoleCommand, DeleteUserRoleCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
