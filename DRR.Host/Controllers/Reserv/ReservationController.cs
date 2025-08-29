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
using Microsoft.AspNetCore.Authorization;
using DRR.Application.Contracts.Queries.Reserv;

namespace DRR.Host.Controllers.Reservation
{
    public class ReservationController : MainController
    {
        public ReservationController(IDistributor distributor) : base(distributor)
        {
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن 4 وقت های خالی برای صفحه اول سایت ")]
        [HttpGet("read-doctor-resevationtop4firstpage")]
        public async Task<IActionResult> ReadReservationtop4firstpage([FromQuery] ReadDoctorReservationtop4Query query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorReservationtop4Query, ReadDoctorReservationQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن وقت های خالی برای ویزیت یک دکتر ")]
        [HttpGet("read-doctor-reservation")]
        public async Task<IActionResult> ReadReservationByDoctorId([FromQuery] ReadDoctorReservationQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorReservationQuery, ReadDoctorReservationQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن وقت های خالی برای ویزیت یک دکتردر یک مرکز درمانی ")]
        [HttpGet("read-doctor-treatmentcenter-reservation")]
        public async Task<IActionResult> ReadReservationByDoctorIdByTreatmentCenterId([FromQuery] ReadDoctorTreatmentCenterReservationQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCenterReservationQuery, ReadDoctorReservationQueryResponse>(query, cancellationToken);

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
        [SwaggerOperation(Summary = "ایجاد وقت خالی برای ویزیت یک دکتر به صورت بازه زمانی ")]
        [HttpPost("create-reservationfromdatetodate")]
        public async Task<IActionResult> Createreservationfromdatetodate(CreateReservationDateToDateCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateReservationDateToDateCommand, CreateReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف وقت خالی برای ویزیت یک دکتر ")]
        [HttpDelete("delete-reservation")]
        public async Task<IActionResult> Deletereservation(DeleteReservationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteReservationCommand, DeleteReservationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن همه قیمت های ویزیت برای رزرو یک دکتر ")]
        [HttpGet("read-all-visitcosts")]
        public async Task<IActionResult> ReadAllVisitCosts([FromQuery] ReadVisitCostQuery command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadVisitCostQuery, ReadVisitCostQueryResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "تعریف قیمت ویزیت برای رزرو یک دکتر ")]
        [HttpPost("create-visitcost")]
        public async Task<IActionResult> CreateVisitCost(CreateVisitCostCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateVisitCostCommand, CreateVisitCostCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ویرایش قیمت ویزیت برای رزرو یک دکتر ")]
        [HttpPost("Update-visitcost")]
        public async Task<IActionResult> UpdateVisitCost(UpdateVisitCostCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateVisitCostCommand, UpdateVisitCostCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن همه انواع ویزیت برای رزرو یک دکتر ")]
        [HttpGet("read-all-visittypes")]
        public async Task<IActionResult> ReadAllVisitTypes([FromQuery] ReadVisitTypeQuery command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadVisitTypeQuery, ReadVisitTypeQueryResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "تعریف نوع ویزیت برای رزرو یک دکتر ")]
        [HttpPost("create-visittype")]
        public async Task<IActionResult> CreateVisitType(CreateVisitTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateVisitTypeCommand, CreateVisitTypeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ویرایش نوع ویزیت برای رزرو یک دکتر ")]
        [HttpPost("Update-visittype")]
        public async Task<IActionResult> UpdateVisitType(UpdateVisitTypeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateVisitTypeCommand, UpdateVisitTypeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
