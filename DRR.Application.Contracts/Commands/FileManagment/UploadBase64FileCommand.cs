using DRR.Framework.Contracts.Abstracts;
using System;

namespace DRR.Application.Contracts.Commands.FileManagment;

public class UploadBase64FileCommand : Command
{
    public string FileName { get; set; }
    public string Base64 { get; set; }
    public string Extension { get; set; }
}

public class UploadBase64FileCommandResponse : CommandResponse
{
    public Guid Id { get; set; }
}