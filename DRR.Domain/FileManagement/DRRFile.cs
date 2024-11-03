
using DRR.Framework.Contracts.Abstracts;
using System;

namespace DRR.Domain.FileManagement;

public class DRRFile : Entity<Guid>
{
    public DRRFile(string originalName, string extension, string entityName)
    {
        Id = Guid.NewGuid();
        OriginalName = originalName;
        Extension = extension;
        EntityName = entityName;
    }

    public string OriginalName { get; protected set; }
    public string Extension { get; protected set; }
    public string EntityName { get; protected set; }
    public int? SizeKb { get; protected set; }
    public string? FullPath { get; protected set; }


    public void SetFullPath(string fullPath)
    {
        FullPath = fullPath;
    }

    public void SetSize(int size)
    {
        SizeKb = size;
    }

}