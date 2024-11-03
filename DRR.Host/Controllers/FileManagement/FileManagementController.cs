using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.FileManagment;
using DRR.Application.Contracts.Queries.FileManagment;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Controllers.FileManagement;

public class FileManagementController : MainController
{
    public FileManagementController(IDistributor distributor) : base(distributor)
    {
    }

    [AllowAnonymous]
    [HttpGet("read-file")]
    public async Task<IActionResult> ReadFile([FromQuery] ReadFileQuery query, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Send<ReadFileQuery, ReadFileQueryResponse>(query, cancellationToken);

        var ms = new MemoryStream(result.Data);
        return new FileStreamResult(ms, result.MimeType);
    }

    [AllowAnonymous]
    [HttpGet("read-file-info")]
    public async Task<IActionResult> ReadFileInfo([FromQuery] ReadFileInfoQuery query, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Send<ReadFileInfoQuery, ReadFileInfoQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<UploadFileCommand, UploadFileCommandResponse>(
                new UploadFileCommand { FormFile = file }, cancellationToken);

        return OkApiResult(result);
    }
[AllowAnonymous]
    [HttpPost("upload-batch")]
    public async Task<IActionResult> UploadBatch(IFormFile[] files, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<UploadBatchFileCommand, UploadBatchFileCommandResponse>(
                new UploadBatchFileCommand {FormFiles = files}, cancellationToken);

        return OkApiResult(result);
    }

    [HttpPost("upload-base64")]
    public async Task<IActionResult> UploadBase64(UploadBase64FileCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<UploadBase64FileCommand, UploadBase64FileCommandResponse>(command,
                cancellationToken);

        return OkApiResult(result);
    }

    //[HttpGet("read-file")]
    //public async Task<IActionResult> ReadFile([FromQuery] ReadAttenderTypesQuery query,
    //    CancellationToken cancellationToken)
    //{
    //    var result =
    //        await Distributor.Send<ReadAttenderTypesQuery, ReadAttenderTypesQueryResponse>(query, cancellationToken);

    //    return OkApiResult(result);
    //}
}