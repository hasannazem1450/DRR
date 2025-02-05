using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Application.Contracts.Queries.Jornal;
using DRR.Configurations.RegisterTypes;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;
using DRR.Application.Contracts.Queries.Insurance;
using DRR.Application.Contracts.Commands.Insurances;

namespace DRR.Host.Controllers.Insurance
{
    public class InsuranceController : MainController
    {
        public InsuranceController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "  نمایش بیمه")]
        [HttpGet("read-insurance")]
        public async Task<IActionResult> ReadInsurance([FromQuery] ReadInsuranceQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadInsuranceQuery, ReadInsuranceQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "  نمایش کل بیمه ها ")]
        [HttpGet("read-all-insurances")]
        public async Task<IActionResult> ReadAllInsurance([FromQuery] ReadInsurancesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadInsurancesQuery, ReadInsurancesQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ایجاد یک بیمه ")]
        [HttpPost("create-insurances")]
        public async Task<IActionResult> CreateInsurance(CreateInsuranceCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateInsuranceCommand, CreateInsuranceCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  حذف یک بیمه ")]
        [HttpDelete("delete-insurances")]
        public async Task<IActionResult> DeleteInsurance(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<DeleteInsuranceCommnad, DeleteInsuranceCommnadResponse>(new DeleteInsuranceCommnad(), cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ویرایش یک بیمه ")]
        [HttpPut("update-insurances")]
        public async Task<IActionResult> UpdateInsurance(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<UpdateInsuranceCommnad, UpdateInsuranceCommnadResponse>(new UpdateInsuranceCommnad(), cancellationToken);

            return OkApiResult(result);
        }
    }
}