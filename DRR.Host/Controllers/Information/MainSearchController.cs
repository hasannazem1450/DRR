using DRR.Application.Contracts.Queries.Customer;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using DRR.Application.Contracts.Queries.Information;

namespace DRR.Host.Controllers.Information
{
    public class MainSearchController : MainController
    {
        public MainSearchController(IDistributor distributor) : base(distributor)
        {

        }
        [AllowAnonymous]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [SwaggerOperation(Summary = "سرچ کلی سایت با دیپ لرن")]
        [HttpGet("searchall")]
        public async Task<IActionResult> SearchAll([FromQuery] MainSearchQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<MainSearchQuery, MainSearchQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
    }
}
