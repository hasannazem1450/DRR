using System;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Commands.RoleManager;
using DRR.Application.Contracts.Commands.UserManager;
using DRR.Application.Contracts.Queries.RoleManager;
using DRR.Application.Contracts.Queries.UserManager;
using DRR.Controllers;
using DRR.Framework.Contracs.Abstracts;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.RoleManager
{

    namespace DRR.Host.Controllers.Authentication
    {
        public class RoleManagerController : MainController
        {
            public RoleManagerController(IDistributor distributor) : base(distributor)
            {
            }

            [SwaggerOperation(Summary = "ایجاد نقش های پایه در دیتابیس ")]
            [HttpPost("create-role-indb")]
            public async Task InitializeRoles(IServiceProvider serviceProvider)
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // بررسی وجود رول‌ها و ایجاد آن‌ها
                foreach (var roleName in new[] { RoleConstants.Admin, RoleConstants.AdminOfDentist,RoleConstants.AdminOfPsychiatrist, RoleConstants.AdminOfJornal,
        RoleConstants.AdminOfSupport, RoleConstants.AdminOfTreatmentCenters})
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
            [SwaggerOperation(Summary = "تخصیص یک نقش به یک کاربر  ")]
            //[Authorize(Roles = RoleConstants.Admin)]
            [HttpPost("add-user-role")]
            public async Task<IActionResult> CreateRole(AddRoleToUserCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<AddRoleToUserCommand, AddRoleToUserCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }
            [SwaggerOperation(Summary = " حذف یک نقش کاربر  ")]
            [Authorize(Roles = RoleConstants.Admin)]
            [HttpPost("delete-user-role")]
            public async Task<IActionResult> DeleteRole(DeleteUserRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<DeleteUserRoleCommand, DeleteUserRoleCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }
            [SwaggerOperation(Summary = "ایجاد یک نقش  ")]
            [HttpPost("create-role")]
            public async Task<IActionResult> CreateRole(CreateRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<CreateRoleCommand, CreateRollCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }
            [SwaggerOperation(Summary = "حذف یک نقش  ")]
            [HttpDelete("delete-role")]
            public async Task<IActionResult> DeleteRole(DeleteRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<DeleteRoleCommand, DeleteRoleCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }
            [SwaggerOperation(Summary = "ویرایش  یک نقش  ")]
            [HttpPut("update-role")]
            public async Task<IActionResult> UpdateRole(UpdateRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<UpdateRoleCommand, UpdateRoleCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }
            [SwaggerOperation(Summary = "خواندن نقش ها ")]
            [HttpGet("read-roles")]
            public async Task<IActionResult> ReadRoles(CancellationToken cancellationToken)
            {
                var result = await Distributor.Send<ReadRoleQuery, ReadRoleQueryResponse>(new ReadRoleQuery(), cancellationToken);

                return OkApiResult(result);
            }
            //[SwaggerOperation(Summary = "خواندن همه  کاربران با نقش ")]
            //[HttpGet("read-usersroles")]
            //public async Task<IActionResult> ReadUsersRoles(CancellationToken cancellationToken)
            //{
            //    var result = await Distributor.Send<ReadUsersRolesQuery, ReadUsersRolesQueryResponse>(new ReadUsersRolesQuery(), cancellationToken);

            //    return OkApiResult(result);
            //}
        }
    }
}
