using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Queries.BaseInfo.Province;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.BaseInfo.Province
{
    public class ProvinceController : MainController
    {
        public ProvinceController(IDistributor distributor) : base(distributor)
        {
        }

        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن نام استان ها")]
        [HttpGet("read-province")]
        public async Task<IActionResult> ReadProvince(CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadProvinceDropdownQuery, ReadProvinceDropdownQueryResponse>(new ReadProvinceDropdownQuery(), cancellationToken);

            return OkApiResult(result);
        }

        [SwaggerOperation(Summary = "ایجاد استان جدید")]
        [HttpPost("create-province")]
        public async Task<IActionResult> CreateProvince(SignInCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<SignInCommand, SignInCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف استان ها")]
        [HttpDelete("delete-province")]
        public async Task<IActionResult> DeleteProvince(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<SignOutCommand, SignOutCommandResponse>(new SignOutCommand(), cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ویرایش نام استان ها")]
        [HttpPut("update-province")]
        public async Task<IActionResult> UpdateProvince(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<SignOutCommand, SignOutCommandResponse>(new SignOutCommand(), cancellationToken);

            return OkApiResult(result);
        }
    }
}
