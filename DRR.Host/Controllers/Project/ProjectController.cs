using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands;
using DRR.Application.Contracts.Repository;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Controllers.Project
{
    public class ProjectController : MainController
    {
        public ProjectController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-project")]
        public async Task<IActionResult> GetPaymentToken(CreateProjectCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateProjectCommand, CreateProjectCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
    }
}
