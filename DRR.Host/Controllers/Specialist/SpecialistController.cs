using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using System.Threading.Tasks;
using System.Threading;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using DRR.Application.Contracts.Specialist;
using DRR.Application.Contracts.Commands.Specialist;

namespace DRR.Host.Controllers.Specialist
{
    public class SpecialistController : MainController
    {
        public SpecialistController(IDistributor distributor) : base(distributor)
        {

        }
        [HttpGet("read-specialist")]
        public async Task<IActionResult> ReadSpecilists([FromQuery] ReadSpecialistQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSpecialistQuery, ReadSpecialistQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }

        [HttpPost("create-specialist")]
        public async Task<IActionResult> CreateSpecilist(CreateSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateSpecialistCommand, CreateSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-specialist")]
        public async Task<IActionResult> UpdateDoctor(UpdateSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateSpecialistCommand, UpdateSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-specialist")]
        public async Task<IActionResult> DeleteDoctor(DeleteSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteSpecialistCommand, DeleteSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
