using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Http;
using System;

namespace DRR.Application.Contracts.Commands.FileManagment;

public class UploadFileCommand : Command
{
    public IFormFile FormFile { get; set; }
}

public class UploadFileCommandResponse : CommandResponse
{
    public Guid Id { get; set; }
}