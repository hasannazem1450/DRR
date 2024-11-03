using DRR.Framework.Contracts.Abstracts;
using System;

namespace DRR.Application.Contracts.Queries.FileManagment;

public class ReadFileQuery : Query
{
    public Guid Id { get; set; }
}

public class ReadFileQueryResponse : QueryResponse
{
    public byte[] Data { get; set; }
    public string MimeType { get; set; }
}