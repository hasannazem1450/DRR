
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
        [SwaggerOperation(Summary = " جستجو مرکزدرمانی/مطب  ")]
        [HttpGet("search-DoctorTreatmentCenters")]
        public async Task<IActionResult> SearchDoctorTreatmentCenters([FromQuery] SearchDoctorTreatmentCentersQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<SearchDoctorTreatmentCentersQuery, SearchDoctorTreatmentCentersQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " 20 مرکزدرمانی صفحه اول  ")]
        [HttpGet("Read-DoctorTreatmentCenters4FirstPage")]
        public async Task<IActionResult> ReadDoctorTreatmentCenters4FirstPage([FromQuery] ReadDoctorTreatmentCenters4FirstPageQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCenters4FirstPageQuery, ReadDoctorTreatmentCenters4FirstPageQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " 20 مطب شاخص صفحه اول  ")]
        [HttpGet("Read-DoctorOffice4FirstPage")]
        public async Task<IActionResult> ReadDoctorOffice4FirstPage([FromQuery] ReadDoctorOffice4FirstPageQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorOffice4FirstPageQuery, ReadDoctorOffice4FirstPageQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن مرکزدرمانی/مطب بانام فارسی ssr ")]
        [HttpGet("read-DoctorTreatmentCenterByNameSSR")]
        public async Task<IActionResult> DoctorTreatmentCenterByNameSSR([FromQuery] ReadDoctorTreatmentCenterByNameSSRQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCenterByNameSSRQuery, ReadDoctorTreatmentCenterByNameSSRQueryResponse>(query, cancellationToken);
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
        [SwaggerOperation(Summary = " خواندن مرکزدرمانی/مطب های یک دکتر حضوری ")]
        [HttpGet("read-DoctorTreatmentCenterByDoctorIdHozoori")]
        public async Task<IActionResult> DoctorTreatmentCenterByDoctorIdHozoori([FromQuery] ReadDoctorTreatmentCenterHozooriQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCenterHozooriQuery, ReadDoctorTreatmentCenterHozooriQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن مرکزدرمانی/مطب های یک دکتر انلاین ")]
        [HttpGet("read-DoctorTreatmentCenterByDoctorIdOnline")]
        public async Task<IActionResult> DoctorTreatmentCenterByDoctorIdOnline([FromQuery] ReadDoctorTreatmentCenterOnlineQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCenterOnlineQuery, ReadDoctorTreatmentCenterOnlineQueryResponse>(query, cancellationToken);
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
