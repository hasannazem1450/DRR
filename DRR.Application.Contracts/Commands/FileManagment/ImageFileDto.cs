using System;

namespace DRR.Application.Contracts.Commands.FileManagment;

public class ImageFileDto
{
    public Guid Id { get; set; }
    public string OriginalName { get; set; }
    public DateTime? LastModified { get; set; }
    public string JalaliLastModified { get; set; }
    public string Extension { get; set; }
    public string MimeType { get; set; }
}