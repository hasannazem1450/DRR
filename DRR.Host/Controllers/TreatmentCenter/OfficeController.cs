﻿using System.Threading.Tasks;
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
    public class OfficeController : MainController
    {
        public OfficeController(IDistributor distributor) : base(distributor)
        {

        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن یک مطب ")]
        [HttpGet("read-Office")]
        public async Task<IActionResult> ReadOfficeId([FromQuery] ReadOfficeQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadOfficeQuery, ReadOfficeQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن همه ")]
        [HttpGet("read-Offices")]
        public async Task<IActionResult> ReadOffices([FromQuery] ReadOfficesQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadOfficesQuery, ReadOfficesQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ایجاد یک مطب ")]
        [HttpPost("create-Office")]
        public async Task<IActionResult> CreateOffice(CreateOfficeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateOfficeCommand, CreateOfficeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک مطب ")]
        [HttpPut("update-Office")]
        public async Task<IActionResult> UpdateOffice(UpdateOfficeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateOfficeCommand, UpdateOfficeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک مطب ")]
        [HttpDelete("delete-Office")]
        public async Task<IActionResult> DeleteOffice(DeleteOfficeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteOfficeCommand, DeleteOfficeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
