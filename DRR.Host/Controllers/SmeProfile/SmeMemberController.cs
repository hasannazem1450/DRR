using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.SmeMember;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Queries.Profile.SmeMember;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.SmeProfile
{
    public class SmeMemberController : MainController
    {
        public SmeMemberController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-sme-member")]
        public async Task<IActionResult> SignUp(CreateSmeMemberCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateSmeMemberCommand, CreateSmeMemberCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-sme-member")]
        public async Task<IActionResult> SignUp(CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSmeMemberQuery, ReadSmeMemberQueryResponse>(new ReadSmeMemberQuery(), cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-sme-member")]
        public async Task<IActionResult> SignUp(UpdateSmeMemberCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateSmeMemberCommand, UpdateSmeMemberCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-sme-member")]
        public async Task<IActionResult> SignUp(DeleteSmeMemberCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteSmeMemberCommand, DeleteSmeMemberCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}
