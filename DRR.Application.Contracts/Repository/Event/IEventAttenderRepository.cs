using DRR.Domain.Event;
using DRR.Framework.Contracts.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Event;

public interface IEventAttenderRepository : IRepository
{
    Task Create(EventAttender eventAttender);
    Task<EventAttender> ReadById(int id);
    Task<List<EventAttender>> ReadByEvent(int eventId);
    Task<List<EventAttender>> ReadByAttender(int smeProfileId);
}