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
    public class OfficeTypeController : MainController
    {
        public OfficeTypeController(IDistributor distributor) : base(distributor)
        {

        }
        [SwaggerOperation(Summary = " خواندن یک نوع مطب ")]
        [HttpGet("read-OfficeType")]
        public async Task<IActionResult> ReadSpecilist([FromQuery] ReadOfficeTypeQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadOfficeTypeQuery, ReadOfficeTypeQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن همه ")]
        [HttpGet("read-OfficeTypes")]
        public async Task<IActionResult> ReadSpecilists([FromQuery] ReadOfficeTypesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadOfficeTypesQuery, ReadOfficeTypesQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ایجاد یک نوع مطب ")]
        [HttpPost("create-OfficeType")]
        public async Task<IActionResult> CreateSpecilist(CreateOfficeTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateOfficeTypeCommand, CreateOfficeTypeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک نوع مطب ")]
        [HttpPut("update-OfficeType")]
        public async Task<IActionResult> UpdateDoctor(UpdateOfficeTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateOfficeTypeCommand, UpdateOfficeTypeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک نوع مطب ")]
        [HttpDelete("delete-OfficeType")]
        public async Task<IActionResult> DeleteDoctor(DeleteOfficeTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteOfficeTypeCommand, DeleteOfficeTypeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
