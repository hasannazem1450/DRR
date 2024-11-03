using DRR.Domain.FileManagement;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.FileManagment;

public interface IDRRFileRespository : IRepository
{
    Task Create(DRRFile DRRFile);
    Task Create(List<DRRFile> DRRFiles);

    Task<DRRFile> ReadById(Guid id);
}