using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Queries.News;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using DRR.Application.Contracts.Queries.Reservation;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.Reservation
{
    public class ReservationController : MainController
    {
        public ReservationController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "خواندن وقت های خالی برای ویزیت یک دکتر ")]
        [HttpGet("read-doctor-reservation")]
        public async Task<IActionResult> RereservationmeProfilereservation([FromQuery] ReadDoctorReservationQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorReservationQuery, ReadDoctorReservationQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ایجاد وقت خالی برای ویزیت یک دکتر ")]
        [HttpPost("create-reservation")]
        public async Task<IActionResult> Createreservation(CreateReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateReservationCommand, CreateReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }


        [SwaggerOperation(Summary = "ویرایش وقت خالی برای ویزیت یک دکتر ")]
        [HttpPut("update-reservation")]
        public async Task<IActionResult> Updatereservation(UpdateReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateReservationCommand, UpdateReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف وقت خالی برای ویزیت یک دکتر ")]
        [HttpDelete("delete-reservation")]
        public async Task<IActionResult> Deletereservation(DeleteReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteReservationCommand, DeleteReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}
