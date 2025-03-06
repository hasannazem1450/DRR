using DRR.Application.Contracts.Repository.Profile;
using DRR.CommandDB;
using DRR.Domain.Profile;
using DRR.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Profile;

public class SmeProfileRepository : BaseRepository, ISmeProfileRepository
{
    public SmeProfileRepository(BaseProjectCommandDb db) : base(db)
    {
    }

    public async Task Create(SmeProfile smeProfile)
    {
        await _Db.SmeProfiles.AddAsync(smeProfile);
        await _Db.SaveChangesAsync();
        var smeprofileforselector = _Db.SmeProfiles.Where(x => x.Id == smeProfile.Id).FirstOrDefault();

        if (smeprofileforselector != null)
        {
            var userProfile = new UserProfile(smeProfile.ManagerName, smeProfile.Id);

            await _Db.UserProfiles.AddAsync(userProfile);
            await _Db.SaveChangesAsync();
        }
    }

    public async Task Update(SmeProfile smeProfile)
    {
        _Db.SmeProfiles.Update(smeProfile);

        await _Db.SaveChangesAsync();
    }

    public async Task<List<SmeProfile>> ReadByFilter(string name, int page, int pageSize)
    {
        var query = _Db.SmeProfiles
            .Include(i => i.City)
            .AsQueryable();

        if (name.IsNotNullOrEmpty())
            query = query.Where(w => w.SmeName.Contains(name));

        var result = await query.OrderByDescending(x=>x.Id).Skip((page-1)*pageSize).Take(pageSize)
            .ToListAsync();

        return result;
    }

    public async Task<List<SmeProfile>> Read()
    {
        var result = await _Db.SmeProfiles.Include(i => i.City).ToListAsync();

        return result;
    }

    public async Task<SmeProfile> ReadById(int? id)
    {
        var result = await _Db.SmeProfiles.Include(i => i.City.Province)
            .FirstOrDefaultAsync(s => s.Id == id);

        return result;
    }

    //public async Task Delete(int id)
    //{
    //    var smeProfile = await _Db.SmeProfiles.FirstOrDefaultAsync(s => s.Id == id);
    //    smeProfile.SetIsDeleted(true);

    //    await _Db.SaveChangesAsync();
    //}

    public async Task<List<SmeProfile>> ReadLast(int count)
    {
        var result = await _Db.SmeProfiles.Include(i => i.City)
            .OrderByDescending(o => o.Id).Take(count).ToListAsync();

        return result;
    }
}