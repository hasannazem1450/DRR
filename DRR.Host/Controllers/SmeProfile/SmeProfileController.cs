using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Queries.Profile.SmeProfile;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.SmeProfile;

public class SmeProfileController : MainController
{
    public SmeProfileController(IDistributor distributor) : base(distributor)
    {
    }

    [HttpPost("create-sme-profile")]
    public async Task<IActionResult> CreateSmeProfile(CreateSmeProfileCommand command,
        CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<CreateSmeProfileCommand, CreateSmeProfileCommandResponse>(command,
                cancellationToken);

        return OkApiResult(result);
    }

    [HttpPut("update-sme-profile")]
    public async Task<IActionResult> UpdateSmeProfile(UpdateSmeProfileCommand command,
        CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<UpdateSmeProfileCommand, UpdateSmeProfileCommandResponse>(command,
                cancellationToken);

        return OkApiResult(result);
    }

    [HttpDelete("delete-sme-profile")]
    public async Task<IActionResult> DeleteSmeProfile(DeleteSmeProfileCommand command,
        CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<DeleteSmeProfileCommand, DeleteSmeProfileCommandResponse>(command,
                cancellationToken);

        return OkApiResult(result);
    }

    [AllowAnonymous]
    [HttpGet("read-filtered-sme-profile")]
    public async Task<IActionResult> ReadFilteredSmeProfile([FromQuery] ReadFilteredSmeProfileQuery query, CancellationToken cancellationToken)
    {
        var result = await Distributor.Send<ReadFilteredSmeProfileQuery, ReadFilteredSmeProfileQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }

    [HttpGet("read-sme-profile")]
    public async Task<IActionResult> ReadSmeProfile([FromQuery] ReadSmeProfileQuery query, CancellationToken cancellationToken)
    {
        var result = await Distributor.Send<ReadSmeProfileQuery, ReadSmeProfileQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }

    [AllowAnonymous]
    [HttpGet("read-latest-sme-profiles")]
    public async Task<IActionResult> ReadLatestSmeProfile([FromQuery] ReadLatestSmeProfilesQuery query,
        CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Send<ReadLatestSmeProfilesQuery, ReadLatestSmeProfilesQueryResponse>(query,
                cancellationToken);

        return OkApiResult(result);
    }

    [HttpGet("read-pre-sme-profile")]
    public async Task<IActionResult> ReadPreSmeProfile(CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Send<ReadPreSmeProfileQuery, ReadPreSmeProfileQueryResponse>(new ReadPreSmeProfileQuery(),
                cancellationToken);

        return OkApiResult(result);
    }
}