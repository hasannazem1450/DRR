using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Commands.FileManagment;

public class UploadBatchFileCommand : Command
{
    public IFormFile[] FormFiles { get; set; }
}

public class UploadBatchFileCommandResponse : CommandResponse
{
    public List<Guid> IdList { get; set; }
}