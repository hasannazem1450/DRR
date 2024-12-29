using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands;
using DRR.Application.Contracts.Repository;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Controllers.Project
{
    public class ProjectController : MainController
    {
        public ProjectController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "  افزودن فرم ثبت نام  برای مراکز درمانی ")]
        [HttpPost("create-project")]
        public async Task<IActionResult> CreateProject(CreateProjectCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateProjectCommand, CreateProjectCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "  ویرایش فرم ثبت نام  برای مراکز درمانی ")]
        [HttpPost("update-project")]
        public async Task<IActionResult> UpdateProject(CreateProjectCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateProjectCommand, CreateProjectCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
    }
}
