using System.Threading;
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
public class EventInfoController : MainController
{
    public EventInfoController(IDistributor distributor) : base(distributor)
    {
    }
    [SwaggerOperation(Summary = " ایجاد یک همایش یا نمایشگاه")]
    [HttpPost("create-event")]
    public async Task<IActionResult> Createevent(CreateEventInfoCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<CreateEventInfoCommand, CreateEventInfoCommandResponse>(command, cancellationToken);

        return OkApiResult(result);
    }
    [SwaggerOperation(Summary = " ویرایش یک همایش یا نمایشگاه")]
    [HttpPut("update-event")]
    public async Task<IActionResult> Updateevent(UpdateEventInfoCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<UpdateEventInfoCommand, UpdateEventInfoCommandResponse>(command, cancellationToken);

        return OkApiResult(result);
    }
    [SwaggerOperation(Summary = " حذف یک همایش یا نمایشگاه")]
    [HttpDelete("delete-event")]
    public async Task<IActionResult> Deleteevent(DeleteEventInfoCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<DeleteEventInfoCommand, DeleteEventInfoCommandResponse>(command, cancellationToken);

        return OkApiResult(result);
    }
    [SwaggerOperation(Summary = " خواندن جزیات یک همایش یا نمایشگاه")]
    [HttpGet("read-event")]
    public async Task<IActionResult> ReadEvent([FromQuery] ReadEventInfoQuery query,
        CancellationToken cancellationToken)
    {
        var result = await Distributor.Send<ReadEventInfoQuery, ReadEventInfoQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }

    [AllowAnonymous]
    [SwaggerOperation(Summary = "  خواندن کل همایش یا نمایشگاه های سایت")]
    [HttpGet("read-events")]
    public async Task<IActionResult> ReadEvents([FromQuery] ReadEventInfosQuery query,
        CancellationToken cancellationToken)
    {
        var result = await Distributor.Send<ReadEventInfosQuery, ReadEventInfosQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }

    [AllowAnonymous]
    [SwaggerOperation(Summary = "  خواندن  همایش یا نمایشگاه های صفحه اول سایت")]
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
    [SwaggerOperation(Summary = "  جستجو در کل همایش یا نمایشگاه های سایت")]
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