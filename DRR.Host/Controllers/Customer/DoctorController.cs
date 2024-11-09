using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.Customer
{
    public class DoctorController : MainController
    {
        public DoctorController(IDistributor distributor): base(distributor)
        {

        }
        [HttpGet("read-smeprofile-doctors")]
        public async Task<IActionResult> ReadSmeProfileDoctors([FromQuery]ReadDoctorQuery query , CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorQuery, ReadDoctorQueryResponse> (query , cancellationToken);
            return OkApiResult(result);
        }

        [HttpPost("create-doctor")]
        public async Task<IActionResult> CreateDoctor(CreateDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateDoctorCommand, CreateDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-Doctor")]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateDoctorCommand, UpdateDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-Doctor")]
        public async Task<IActionResult> DeleteDoctor(DeleteDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteDoctorCommand, DeleteDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
