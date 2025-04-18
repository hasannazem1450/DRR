using DRR.Application.Contracts.Repository.Event;
using DRR.CommandDB;
using DRR.Domain.Event;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRR.Utilities.Extensions;

namespace DRR.CommandDb.Repository.Event;

public class EventInfoRepository : BaseRepository, IEventInfoRepository
{
    public EventInfoRepository(BaseProjectCommandDb db) : base(db)
    {
    }

    public async Task<List<EventInfo>> ReadEventInfos()
    {
        var query = await _Db.EventInfos.Include(i => i.Province).ToListAsync();

        return query;
    }

    public async Task<EventInfo> ReadEventInfoById(int id)
    {
        var result = await _Db.EventInfos.Include(i => i.Province).FirstOrDefaultAsync(c => c.Id == id);

        return result;
    }

    public async Task Create(EventInfo Event)
    {
        await _Db.EventInfos.AddAsync(Event);
        await _Db.SaveChangesAsync();
    }

    public async Task Update(EventInfo eventInfo)
    {
        var result = await ReadEventInfoById(eventInfo.Id);

        result.Update(eventInfo.Name, eventInfo.Photo, eventInfo.StartDate, eventInfo.EndDate, eventInfo.Periority,
            eventInfo.ProvinceId);

        _Db.EventInfos.Update(result);

        await _Db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var result = await _Db.EventInfos.FirstOrDefaultAsync(n => n.Id == id);

        _Db.EventInfos.Remove(result);

        await _Db.SaveChangesAsync();
    }
    public async Task<List<EventInfo>> Search(List<string> searchTerms)
    {
        var query = _Db.EventInfos
            .Include(i => i.Province)
            .Where(w => !w.IsDeleted);

        foreach (var searchTerm in searchTerms.Where(w => w.IsNotNullOrEmpty()))
            query = query.Where(w =>
                w.Province.Name.Contains(searchTerm) ||
                w.Name.Contains(searchTerm)
            );

        var result = await query.ToListAsync();

        return result;
    }
}