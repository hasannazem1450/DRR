using System.Threading.Tasks;
using System.Threading;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Commands.TreatmentCenters;

namespace DRR.Host.Controllers.TreatmentCenter
{
    public class ClinicTypeController : MainController
    {
        public ClinicTypeController(IDistributor distributor) : base(distributor)
        {

        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن یک مرکز درمانی ")]
        [HttpGet("read-ClinicType")]
        public async Task<IActionResult> ReadClinicTypeById([FromQuery] ReadClinicTypeQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadClinicTypeQuery, ReadClinicTypeQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن همه ")]
        [HttpGet("read-ClinicTypes")]
        public async Task<IActionResult> ReadClinicTypes([FromQuery] ReadClinicTypesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadClinicTypesQuery, ReadClinicTypesQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ایجاد یک مرکز درمانی ")]
        [HttpPost("create-ClinicType")]
        public async Task<IActionResult> CreateClinicType(CreateClinicTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateClinicTypeCommand, CreateClinicTypeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک مرکز درمانی ")]
        [HttpPut("update-ClinicType")]
        public async Task<IActionResult> UpdateClinicType(UpdateClinicTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateClinicTypeCommand, UpdateClinicTypeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک مرکز درمانی ")]
        [HttpDelete("delete-ClinicType")]
        public async Task<IActionResult> DeleteClinicType(DeleteClinicTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteClinicTypeCommand, DeleteClinicTypeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
