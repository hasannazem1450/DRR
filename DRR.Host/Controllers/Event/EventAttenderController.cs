﻿using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Queries.Event;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.Event;

[AllowAnonymous]
public class EventAttenderController : MainController
{
    public EventAttenderController(IDistributor distributor) : base(distributor)
    {
    }
    [AllowAnonymous]
    [SwaggerOperation(Summary = " ثبت نام در همایش")]
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateEventAttenderCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<CreateEventAttenderCommand, CreateEventAttenderCommandResponse>(command,
                cancellationToken);

        return OkApiResult(result);
    }
    [AllowAnonymous]
    [HttpGet("read-attender-types")]
    public async Task<IActionResult> ReadAttenderTypes([FromQuery] ReadAttenderTypesQuery query,
        CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Send<ReadAttenderTypesQuery, ReadAttenderTypesQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }
}