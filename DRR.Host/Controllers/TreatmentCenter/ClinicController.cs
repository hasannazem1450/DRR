
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
    public class ClinicController : MainController
    {
        public ClinicController(IDistributor distributor) : base(distributor)
        {

        }
        [SwaggerOperation(Summary = " خواندن یک مرکز درمانی ")]
        [HttpGet("read-Clinic")]
        public async Task<IActionResult> ReadClinic([FromQuery] ReadClinicQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadClinicQuery, ReadClinicQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن همه ")]
        [HttpGet("read-Clinics")]
        public async Task<IActionResult> ReadClinics([FromQuery] ReadClinicsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadClinicsQuery, ReadClinicsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ایجاد یک مرکز درمانی ")]
        [HttpPost("create-Clinic")]
        public async Task<IActionResult> CreateClinic(CreateClinicCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateClinicCommand, CreateClinicCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک مرکز درمانی ")]
        [HttpPut("update-Clinic")]
        public async Task<IActionResult> UpdateClinic(UpdateClinicCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateClinicCommand, UpdateClinicCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک مرکز درمانی ")]
        [HttpDelete("delete-Clinic")]
        public async Task<IActionResult> DeleteClinic(DeleteClinicCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteClinicCommand, DeleteClinicCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
