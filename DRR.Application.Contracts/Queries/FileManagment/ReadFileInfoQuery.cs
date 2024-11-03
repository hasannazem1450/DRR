using DRR.Application.Contracts.Commands.FileManagment;
using DRR.Framework.Contracts.Abstracts;
using System;

namespace DRR.Application.Contracts.Queries.FileManagment;

public class ReadFileInfoQuery : Query
{
    public Guid Id { get; set; }
}
public class ReadFileInfoQueryResponse : QueryResponse
{
    public ImageFileDto Info { get; set; }
}