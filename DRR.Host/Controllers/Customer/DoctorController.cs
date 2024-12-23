using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
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
        [SwaggerOperation(Summary = "خواندن پروفایل دکتر بر حسب فرد وارد شونده حقیقی یا حقوقی")]
        [HttpGet("read-smeprofile-doctors")]
        public async Task<IActionResult> ReadSmeProfileDoctors([FromQuery]ReadDoctorQuery query , CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorQuery, ReadDoctorQueryResponse> (query , cancellationToken);
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
        [SwaggerOperation(Summary = "خواندن بیمه های طرف قرارداد با دکتر")]
        [HttpGet("read-insurances-doctor")]
        public async Task<IActionResult> ReadInsurancesDoctors([FromQuery] ReadInsurancesDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadInsurancesDoctorQuery, ReadInsurancesDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خواندن انواع ویریت های دکتر")]
        [HttpGet("read-visittype-doctor")]
        public async Task<IActionResult> ReadVisitTypeDoctors([FromQuery] ReadVisitTypeDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadVisitTypeDoctorQuery, ReadVisitTypeDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }

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
        [SwaggerOperation(Summary = "جستجو در کلیه دکترها")]
        [HttpGet("search-doctors")]
        public async Task<IActionResult> ReadSearchDoctors([FromQuery] SearchDoctorsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<SearchDoctorsQuery, SearchDoctorsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
    }
}
