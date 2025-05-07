using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.Customer
{
    public class DoctorController : MainController
    {
        public DoctorController(IDistributor distributor): base(distributor)
        {

        }
        [AllowAnonymous]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [SwaggerOperation(Summary = "خواندن پروفایل دکتر ها")]
        [HttpGet("read-all-doctors")]
        public async Task<IActionResult> ReadAllDoctors([FromQuery] ReadAllDoctorsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllDoctorsQuery, ReadDoctorsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن دکتر بانام فارسی ssr ")]
        [HttpGet("read-DoctorByNameSSR")]
        public async Task<IActionResult> DoctorByNameSSR([FromQuery] ReadDoctorByNameSSRQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorByNameSSRQuery, ReadDoctorByNameSSRQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن پروفایل یک دکتر ")]
        [HttpGet("read-doctor-byid")]
        public async Task<IActionResult> ReadDoctor([FromQuery] ReadDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorQuery, ReadDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خواندن پروفایل دکتر بر حسب فرد وارد شونده حقیقی یا حقوقی")]
        [HttpGet("read-smeprofile-doctors")]
        public async Task<IActionResult> ReadSmeProfileDoctors([FromQuery]ReadDoctorsBySmeprofileQuery query , CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorsBySmeprofileQuery, ReadDoctorsQueryResponse> (query , cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن پروفایل دکتر ها بر حسب تخصص")]
        [HttpGet("read-doctors-byspeciality")]
        public async Task<IActionResult> ReadDoctorsBySpeciality([FromQuery] ReadDoctorsBySpecialityQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorsBySpecialityQuery, ReadDoctorsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ایجاد یک دکتر")]
        [HttpPost("create-doctor")]
        public async Task<IActionResult> CreateDoctor(CreateDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateDoctorCommand, CreateDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ویرایش یک دکتر")]
        [HttpPut("update-Doctor")]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateDoctorCommand, UpdateDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف یک دکتر")]
        [HttpDelete("delete-Doctor")]
        public async Task<IActionResult> DeleteDoctor(DeleteDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteDoctorCommand, DeleteDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن بیمه های طرف قرارداد با دکتر")]
        [HttpGet("read-insurances-doctor")]
        public async Task<IActionResult> ReadInsurancesDoctors([FromQuery] ReadInsurancesDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadInsurancesDoctorQuery, ReadInsurancesDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن انواع ویزیت های دکتر")]
        [HttpGet("read-visittype-doctor")]
        public async Task<IActionResult> ReadVisitTypeDoctors([FromQuery] ReadOfficeTypeDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadOfficeTypeDoctorQuery, ReadOfficeTypeDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن نزدیک ترین زمان ویزیت این دکتر")]
        [HttpGet("read-nextreserves-doctor")]
        public async Task<IActionResult> ReadReservesDoctor([FromQuery] ReadNextReservesDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadNextReservesDoctorQuery, ReadNextReservesDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خواندن تمام ویزیت های داده شده این دکتر")]
        [HttpGet("read-all-reserves-doctor")]
        public async Task<IActionResult> ReadAllReservesDoctor([FromQuery] ReadReservesDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadReservesDoctorQuery, ReadReservesDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خواندن تمامی مریض های تا اکنون این دکتر")]
        [HttpGet("read-patients-doctor")]
        public async Task<IActionResult> ReadPatientsDoctor([FromQuery] ReadPatientsDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadPatientsDoctorQuery, ReadPatientsDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "جستجو در کلیه دکترها")]
        [HttpGet("search-doctors")]
        public async Task<IActionResult> ReadSearchDoctors([FromQuery] SearchDoctorsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<SearchDoctorsQuery, SearchDoctorsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "جستجو در کلیه دکترها لیست ادمین")]
        [HttpGet("search-list-doctors")]
        public async Task<IActionResult> ReadSearchListDoctors([FromQuery] SearchListDoctorsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<SearchListDoctorsQuery, SearchListDoctorsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن اولین نوبت خالی این دکتر")]
        [HttpGet("readfirstfreeturns")]
        public async Task<IActionResult> ReadFirstFreeTurns([FromQuery] ReadFirstFreeTurnsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadFirstFreeTurnsQuery, ReadFirstFreeTurnsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن پروفایل دکتر ها بر حسب مرکز درمانی")]
        [HttpGet("read-doctors-bytreatmentcenterid")]
        public async Task<IActionResult> ReadDoctorsInTreatmentCenter([FromQuery] ReadDoctorsInTreatmentCenterQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorsInTreatmentCenterQuery, ReadDoctorsInTreatmentCenterQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
    }
}
