using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Queries.Event;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.Event;

[AllowAnonymous]
public class EventInfoController : MainController
{
    public EventInfoController(IDistributor distributor) : base(distributor)
    {
    }

    [HttpPost("create-event")]
    public async Task<IActionResult> Createevent(CreateEventInfoCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<CreateEventInfoCommand, CreateEventInfoCommandResponse>(command, cancellationToken);

        return OkApiResult(result);
    }

    [HttpPut("update-event")]
    public async Task<IActionResult> Updateevent(UpdateEventInfoCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<UpdateEventInfoCommand, UpdateEventInfoCommandResponse>(command, cancellationToken);

        return OkApiResult(result);
    }

    [HttpDelete("delete-event")]
    public async Task<IActionResult> Deleteevent(DeleteEventInfoCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<DeleteEventInfoCommand, DeleteEventInfoCommandResponse>(command, cancellationToken);

        return OkApiResult(result);
    }

    [HttpGet("read-event")]
    public async Task<IActionResult> ReadEvent([FromQuery] ReadEventInfoQuery query,
        CancellationToken cancellationToken)
    {
        var result = await Distributor.Send<ReadEventInfoQuery, ReadEventInfoQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }

    [AllowAnonymous]
    [HttpGet("read-events")]
    public async Task<IActionResult> ReadEvents([FromQuery] ReadEventInfosQuery query,
        CancellationToken cancellationToken)
    {
        var result = await Distributor.Send<ReadEventInfosQuery, ReadEventInfosQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }

    [AllowAnonymous]
    [HttpGet("read-upcoming-events")]
    public async Task<IActionResult> ReadUpcomingEvents([FromQuery] ReadUpcomingEventInfosQuery query,
        CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Send<ReadUpcomingEventInfosQuery, ReadUpcomingEventInfosQueryResponse>(query,
                cancellationToken);

        return OkApiResult(result);
    }

    [AllowAnonymous]
    [HttpPost("read-filtered-events")]
    public async Task<IActionResult> ReadFilteredEvents([FromBody] ReadFilteredEventInfosQuery query,
        CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Send<ReadFilteredEventInfosQuery, ReadFilteredEventInfosQueryResponse>(query,
                cancellationToken);

        return OkApiResult(result);
    }
}