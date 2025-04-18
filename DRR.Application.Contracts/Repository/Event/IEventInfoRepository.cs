using DRR.Domain.Event;
using DRR.Framework.Contracts.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Event;

public interface IEventInfoRepository : IRepository
{
    Task<EventInfo> ReadEventInfoById(int id);

    Task Delete(int id);

    Task Update(EventInfo ev);

    Task Create(EventInfo ev);

    Task<List<EventInfo>> ReadEventInfos();
    Task<List<EventInfo>> Search(List<string> searchTerms);
}