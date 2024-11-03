using DRR.Application.Contracts.Repository.Event;
using DRR.CommandDB;
using DRR.Domain.Event;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Event;

public class EventAttenderRepository : BaseRepository, IEventAttenderRepository
{
    public EventAttenderRepository(BaseProjectCommandDb db) : base(db)
    {

    }

    public async Task Create(EventAttender eventAttender)
    {
        await _Db.EventAttenders.AddAsync(eventAttender);
        await _Db.SaveChangesAsync();
    }

    public async Task<EventAttender> ReadById(int id)
    {
        var result = await _Db.EventAttenders.FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }

    public async Task<List<EventAttender>> ReadByEvent(int eventId)
    {
        var result = await _Db.EventAttenders.Where(x => x.EventInfoId == eventId).ToListAsync();

        return result;
    }

    public async Task<List<EventAttender>> ReadByAttender(int smeProfileId)
    {
        var result = await _Db.EventAttenders.Where(x => x.SmeProfileId == smeProfileId).ToListAsync();

        return result;
    }
}