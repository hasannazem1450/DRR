
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
    public class DoctorTreatmentCenterController : MainController
    {
        public DoctorTreatmentCenterController(IDistributor distributor) : base(distributor)
        {

        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " چستچو مرکزدرمانی/مطب  ")]
        [HttpGet("search-DoctorTreatmentCenters")]
        public async Task<IActionResult> SearchDoctorTreatmentCenters([FromQuery] SearchDoctorTreatmentCentersQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<SearchDoctorTreatmentCentersQuery, SearchDoctorTreatmentCentersQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن مرکزدرمانی/مطب های یک دکتر ")]
        [HttpGet("read-DoctorTreatmentCenterByDoctorId")]
        public async Task<IActionResult> DoctorTreatmentCenterByDoctorId([FromQuery] ReadDoctorTreatmentCenterQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCenterQuery, ReadDoctorTreatmentCenterQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [SwaggerOperation(Summary = " خواندن همه ")]
        [HttpGet("read-DoctorTreatmentCenters")]
        public async Task<IActionResult> DoctorTreatmentCenters([FromQuery] ReadDoctorTreatmentCentersQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCentersQuery, ReadDoctorTreatmentCentersQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " تخصیص یک مرکزدرمانی/مطب به دکتر ")]
        [HttpPost("create-DoctorTreatmentCenter")]
        public async Task<IActionResult> CreateDoctorTreatmentCenter(CreateDoctorTreatmentCenterCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateDoctorTreatmentCenterCommand, CreateDoctorTreatmentCenterCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک مرکزدرمانی/مطب دکتر ")]
        [HttpPut("update-DoctorTreatmentCenter")]
        public async Task<IActionResult> UpdateDoctorTreatmentCenter(UpdateDoctorTreatmentCenterCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateDoctorTreatmentCenterCommand, UpdateDoctorTreatmentCenterCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک مرکزدرمانی/مطب دکتر ")]
        [HttpDelete("delete-DoctorTreatmentCenter")]
        public async Task<IActionResult> DeleteDoctorTreatmentCenter(DeleteDoctorTreatmentCenterCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteDoctorTreatmentCenterCommand, DeleteDoctorTreatmentCenterCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
