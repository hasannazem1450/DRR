using DRR.Application.Contracts.Commands.Insurances;
using DRR.Application.Contracts.Queries.Insurance;
using DRR.Configurations.RegisterTypes;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;

namespace DRR.Host.Controllers.Insurance
{
    public class DoctorInsuranceController : MainController
    {
        public DoctorInsuranceController(IDistributor distributor) : base(distributor)
        {
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "   نمایش بیمه ")]
        [HttpGet("read-DoctorInsurance-byid")]
        public async Task<IActionResult> ReadDoctorInsuranceById([FromQuery] ReadDoctorInsuranceQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorInsuranceQuery, ReadDoctorInsuranceQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "   نمایش بیمه های یک دکتر")]
        [HttpGet("read-insurances-bydoctorid")]
        public async Task<IActionResult> ReadDoctorInsurances([FromQuery] ReadDoctorInsurancesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorInsurancesQuery, ReadDoctorInsurancesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "   نمایش دکترها دارای بیمه خاص")]
        [HttpGet("read-doctors-byinsuranceid")]
        public async Task<IActionResult> ReadDoctorsInsurance([FromQuery] ReadDoctorsInsuranceQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorsInsuranceQuery, ReadDoctorsInsuranceQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "  نمایش کل بیمه های دکترها ")]
        [HttpGet("read-all-DoctorInsurances")]
        public async Task<IActionResult> ReadAllDoctorInsurance([FromQuery] ReadDoctorsInsurancesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorsInsurancesQuery, ReadDoctorsInsurancesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "   ایجاد یک بیمه برای یک دکتر ")]
        [HttpPost("create-DoctorInsurance")]
        public async Task<IActionResult> CreateDoctorInsurance(CreateDoctorInsuranceCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateDoctorInsuranceCommand, CreateDoctorInsuranceCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  حذف بیمه یک دکتر ")]
        [HttpDelete("delete-DoctorInsurances")]
        public async Task<IActionResult> DeleteDoctorInsurance(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<DeleteDoctorInsuranceCommnad, DeleteDoctorInsuranceCommnadResponse>(new DeleteDoctorInsuranceCommnad(), cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ویرایش بیمه یک دکتر ")]
        [HttpPut("update-DoctorInsurances")]
        public async Task<IActionResult> UpdateDoctorInsurance(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<UpdateDoctorInsuranceCommnad, UpdateDoctorInsuranceCommnadResponse>(new UpdateDoctorInsuranceCommnad(), cancellationToken);

            return OkApiResult(result);
        }
    }
}