using DRR.Application.Contracts.Commands.Reserv;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;

namespace DRR.Host.Controllers.Reserv
{
    public class PatientReservationController : MainController
    {
        public PatientReservationController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "گرفتن وقت برای ویزیت  ")]
        [HttpPost("create-patientreservation")]
        public async Task<IActionResult> CreatePatientReservation(CreatePatientReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreatePatientReservationCommand, CreatePatientReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [SwaggerOperation(Summary = "حذف وقت ویزیت  ")]
        [HttpDelete("delete-patientreservation")]
        public async Task<IActionResult> DeletePatientReservation(DeletePatientReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeletePatientReservationCommand, DeletePatientReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

       

    }
}
