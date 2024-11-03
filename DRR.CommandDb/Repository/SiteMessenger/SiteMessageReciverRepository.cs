using DRR.CommandDB;
using Microsoft.EntityFrameworkCore;
using DRR.Utilities.Extensions;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Domain.SiteMessenger;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DRR.CommandDb.Repository.SiteMessenger
{
    public class SiteMessageReciverRepository : BaseRepository, ISiteMessageReciverRepository
    {
        public SiteMessageReciverRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<SiteMessageReciver> ReadById(int id)
        {
            var result = await _Db.SiteMessageRecivers.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        public async Task<List<SiteMessageReciver>> ReadAll()
        {
            var query = _Db.SiteMessageRecivers;

            return await query.ToListAsync();

        }

        public async Task Delete(int id)
        {
            var result = await _Db.SiteMessageRecivers.FirstOrDefaultAsync(n => n.Id == id);

            _Db.SiteMessageRecivers.Remove(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(SiteMessageReciver siteMessagesme)
        {
            _Db.SiteMessageRecivers.Update(siteMessagesme);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(SiteMessageReciver siteMessagesme)
        {
            await _Db.SiteMessageRecivers.AddAsync(siteMessagesme);
            await _Db.SaveChangesAsync();
        }

        public async Task Create(List<SiteMessageReciver> siteMessageRecivers)
        {
            await _Db.SiteMessageRecivers.AddRangeAsync(siteMessageRecivers);
            await _Db.SaveChangesAsync();
        }
    }
}
