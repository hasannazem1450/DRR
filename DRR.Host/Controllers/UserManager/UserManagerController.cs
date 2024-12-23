using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.RoleManager;
using DRR.Application.Contracts.Commands.UserManager;
using DRR.Application.Contracts.Queries.RoleManager;
using DRR.Application.Contracts.Queries.UserManager;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.UserManager
{
    public class UserManagerController : MainController
    {
        public UserManagerController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = " ایجاد یک کاربر ادمین ")]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateUserCommand, CreateUserCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " خواندن یک کاربر ادمین ")]
        [HttpGet("read-user")]
        public async Task<IActionResult> ReadUser([FromQuery]ReadUserQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadUserQuery, ReadUserQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک کاربر ادمین ")]
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteUserCommand, DeleteUserCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک کاربر ادمین ")]
        [HttpPut("update-user")]
        public async Task<IActionResult> ReadUser(UpdateUserCommand command,CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateUserCommand, UpdateUserCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " افزودن نقش به یک کاربر ادمین ")]
        [HttpPost("add-role-to-user")]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<AddRoleToUserCommand, AddRoleToUserCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " خواندن نقش های یک کاربر ادمین ")]
        [HttpGet("read-user-role")]
        public async Task<IActionResult> ReadUserRole([FromQuery]ReadUserRoleQuery command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadUserRoleQuery, ReadUserRoleQueryResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف نقش های یک کاربر ادمین ")]
        [HttpDelete("delete-user-role")]
        public async Task<IActionResult> DeleteUserRole(DeleteUserRoleCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteUserRoleCommand, DeleteUserRoleCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
