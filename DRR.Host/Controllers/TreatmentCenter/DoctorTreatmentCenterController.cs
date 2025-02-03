﻿
using System.Threading.Tasks;
using System.Threading;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Commands.TreatmentCenters;

namespace DRR.Host.Controllers.TreatmentCenter
{
    public class DoctorTreatmentCenterController : MainController
    {
        public DoctorTreatmentCenterController(IDistributor distributor) : base(distributor)
        {

        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن مرکزدرمانی/مطب های یک دکتر ")]
        [HttpGet("read-DoctorTreatmentCenterByDoctorId")]
        public async Task<IActionResult> ReadSpecilist([FromQuery] ReadDoctorTreatmentCenterQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCenterQuery, ReadDoctorTreatmentCenterQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن همه ")]
        [HttpGet("read-DoctorTreatmentCenters")]
        public async Task<IActionResult> ReadSpecilists([FromQuery] ReadDoctorTreatmentCentersQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorTreatmentCentersQuery, ReadDoctorTreatmentCentersQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " تخصیص یک مرکزدرمانی/مطب به دکتر ")]
        [HttpPost("create-DoctorTreatmentCenter")]
        public async Task<IActionResult> CreateSpecilist(CreateDoctorTreatmentCenterCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateDoctorTreatmentCenterCommand, CreateDoctorTreatmentCenterCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک مرکزدرمانی/مطب دکتر ")]
        [HttpPut("update-DoctorTreatmentCenter")]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorTreatmentCenterCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateDoctorTreatmentCenterCommand, UpdateDoctorTreatmentCenterCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک مرکزدرمانی/مطب دکتر ")]
        [HttpDelete("delete-DoctorTreatmentCenter")]
        public async Task<IActionResult> DeleteDoctor(DeleteDoctorTreatmentCenterCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteDoctorTreatmentCenterCommand, DeleteDoctorTreatmentCenterCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
