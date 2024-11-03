using DRR.Domain.Profile;
using DRR.Framework.Contracts.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Profile;

public interface ISmeProfileRepository : IRepository
{
    Task Create(SmeProfile smeProfile);

    Task Update(SmeProfile smeProfile);

    //Task Delete(int id);
    Task<List<SmeProfile>> Read();
    Task<List<SmeProfile>> ReadByFilter(string name, int page, int pageSize);
    Task<SmeProfile> ReadById(int? id);
    Task<List<SmeProfile>> ReadLast(int count);
}