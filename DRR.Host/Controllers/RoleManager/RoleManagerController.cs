using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Commands.RoleManager;
using DRR.Application.Contracts.Queries.RoleManager;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.RoleManager
{

    namespace DRR.Host.Controllers.Authentication
    {
        public class RoleManagerController : MainController
        {
            public RoleManagerController(IDistributor distributor) : base(distributor)
            {
            }

            [HttpPost("create-role")]
            public async Task<IActionResult> CreateRole(CreateRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<CreateRoleCommand, CreateRollCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }

            [HttpDelete("delete-role")]
            public async Task<IActionResult> DeleteRole(DeleteRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<DeleteRoleCommand, DeleteRoleCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }

            [HttpPut("update-role")]
            public async Task<IActionResult> UpdateRole(UpdateRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<UpdateRoleCommand, UpdateRoleCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }

            [HttpGet("read-role")]
            public async Task<IActionResult> ReadRole(CancellationToken cancellationToken)
            {
                var result = await Distributor.Send<ReadRoleQuery, ReadRoleQueryResponse>(new ReadRoleQuery(), cancellationToken);

                return OkApiResult(result);
            }
        }
    }
}
