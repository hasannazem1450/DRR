using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Queries.News;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using DRR.Application.Contracts.Queries.Reservation;
using DRR.Application.Contracts.Commands.Reserv;

namespace DRR.Host.Controllers.Reservation
{
    public class ReservationController : MainController
    {
        public ReservationController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpGet("read-doctor-reservation")]
        public async Task<IActionResult> RereservationmeProfilereservation([FromQuery] ReadDoctorReservationQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorReservationQuery, ReadDoctorReservationQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPost("create-reservation")]
        public async Task<IActionResult> Createreservation(CreateReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateReservationCommand, CreateReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        

        [HttpPut("update-reservation")]
        public async Task<IActionResult> Updatereservation(UpdateReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateReservationCommand, UpdateReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-reservation")]
        public async Task<IActionResult> Deletereservation(DeleteReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteReservationCommand, DeleteReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}
