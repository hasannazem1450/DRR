using DRR.Application.Contracts.Repository.FileManagment;
using DRR.CommandDB;
using DRR.Domain.FileManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.FileManagment;

public class DRRFileRespository : BaseRepository, IDRRFileRespository
{
    public DRRFileRespository(BaseProjectCommandDb db) : base(db)
    {
    }

    public async Task Create(DRRFile DRRFile)
    {
        await _Db.DRRFiles.AddAsync(DRRFile);

        await _Db.SaveChangesAsync();
    }

    public async Task Create(List<DRRFile> DRRFiles)
    {
        await _Db.DRRFiles.AddRangeAsync(DRRFiles);

        await _Db.SaveChangesAsync();
    }

    public async Task<DRRFile> ReadById(Guid id)
    {
        var result = await _Db.DRRFiles.FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }
}