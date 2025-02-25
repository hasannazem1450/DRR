using DRR.Application.Contracts.Commands.Reserv;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;
using DRR.Application.Contracts.Queries.Reservation;
using Microsoft.AspNetCore.Authorization;
using DRR.Application.Contracts.Queries.Reserv;

namespace DRR.Host.Controllers.Reserv
{
    public class PatientReservationController : MainController
    {
        public PatientReservationController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "خواندن یک وقت گرفته شده توسط مریض ")]
        [HttpGet("read-patientreservation-byid")]
        public async Task<IActionResult> ReadPatientReservationById([FromQuery] ReadPatientReservationQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadPatientReservationQuery, ReadPatientReservationQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خواندن کل وقت های گرفته شده توسط مریضها ")]
        [HttpGet("read-all-patientreservations")]
        public async Task<IActionResult> ReadAllPatientReservations([FromQuery] ReadAllPatientReservationsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllPatientReservationsQuery, ReadAllPatientReservationsQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خواندن وقت های گرفته شده توسط یک مریض ")]
        [HttpGet("read-patientreservation-bypatientid")]
        public async Task<IActionResult> ReadPatientReservationByPatientId([FromQuery] ReadPatientReservationsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadPatientReservationsQuery, ReadPatientReservationsQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
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
