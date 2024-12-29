using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using System.Threading.Tasks;
using System.Threading;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using DRR.Application.Contracts.Specialist;
using DRR.Application.Contracts.Commands.Specialist;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.Specialist
{
    public class SpecialistController : MainController
    {
        public SpecialistController(IDistributor distributor) : base(distributor)
        {

        }
        [SwaggerOperation(Summary = " خواندن یک تخصص ")]
        [HttpGet("read-specialist")]
        public async Task<IActionResult> ReadSpecilists([FromQuery] ReadSpecialistQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSpecialistQuery, ReadSpecialistQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ایجاد یک تخصص ")]
        [HttpPost("create-specialist")]
        public async Task<IActionResult> CreateSpecilist(CreateSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateSpecialistCommand, CreateSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک تخصص ")]
        [HttpPut("update-specialist")]
        public async Task<IActionResult> UpdateDoctor(UpdateSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateSpecialistCommand, UpdateSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک تخصص ")]
        [HttpDelete("delete-specialist")]
        public async Task<IActionResult> DeleteDoctor(DeleteSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteSpecialistCommand, DeleteSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
