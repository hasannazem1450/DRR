using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Queries.BaseInfo.Province;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.BaseInfo.Province
{
    public class ProvinceController : MainController
    {
        public ProvinceController(IDistributor distributor) : base(distributor)
        {
        }

        [AllowAnonymous]
        [HttpGet("read-province")]
        public async Task<IActionResult> ReadProvince(CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadProvinceDropdownQuery, ReadProvinceDropdownQueryResponse>(new ReadProvinceDropdownQuery(), cancellationToken);

            return OkApiResult(result);
        }


        [HttpPost("create-province")]
        public async Task<IActionResult> CreateProvince(SignInCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<SignInCommand, SignInCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-province")]
        public async Task<IActionResult> DeleteProvince(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<SignOutCommand, SignOutCommandResponse>(new SignOutCommand(), cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-province")]
        public async Task<IActionResult> UpdateProvince(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<SignOutCommand, SignOutCommandResponse>(new SignOutCommand(), cancellationToken);

            return OkApiResult(result);
        }
    }
}
