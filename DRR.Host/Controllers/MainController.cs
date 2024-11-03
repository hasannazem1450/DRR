using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Controllers;

[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
//[SystemMessageActionFilter]
public class MainController : ControllerBase
{
    protected readonly IDistributor Distributor;

    public MainController(IDistributor distributor)
    {
        Distributor = distributor;
    }

    protected IActionResult OkApiResult(dynamic tResult)
    {
        return Ok(new ApiResult(CommandResponseSuccessful.CreateSuccessful(), tResult));
    }

    protected IActionResult OkApiResult()
    {
        return Ok(new ApiResult(CommandResponseSuccessful.CreateSuccessful()));
    }
}