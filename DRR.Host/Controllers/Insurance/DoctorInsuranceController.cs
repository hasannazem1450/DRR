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
        [SwaggerOperation(Summary = "   نمایش بیمه های یک دکتر")]
        [HttpGet("read-DoctorInsurance")]
        public async Task<IActionResult> ReadDoctorInsurance([FromQuery] ReadDoctorInsuranceQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorInsuranceQuery, ReadDoctorInsuranceQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "  نمایش کل بیمه های دکترها ")]
        [HttpGet("read-all-DoctorInsurances")]
        public async Task<IActionResult> ReadAllDoctorInsurance([FromQuery] ReadDoctorInsurancesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorInsurancesQuery, ReadDoctorInsurancesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "   ایجاد یک بیمه برای یک دکتر ")]
        [HttpPost("create-DoctorInsurances")]
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