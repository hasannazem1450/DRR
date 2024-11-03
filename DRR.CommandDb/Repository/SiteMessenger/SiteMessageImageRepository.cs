using DRR.Application.Contracts.Repository.SiteMessanger;
using DRR.CommandDB;
using DRR.Domain.SiteMessenger;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.SiteMessenger
{

    public class SiteMessageImageRepository : BaseRepository, ISiteMessageImageRepository
    {
        public SiteMessageImageRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<SiteMessageImage> ReadById(int id)
        {
            var result = await _Db.SiteMessageImages.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        public async Task<List<SiteMessageImage>> ReadBySiteMessageId(int siteMessageId)
        {
            var result = await _Db.SiteMessageImages.Where(n => n.SiteMessageId == siteMessageId).ToListAsync();

            return result;
        }

        //public async Task Delete(int id)
        //{
        //    var result = await _Db.SiteMessageImages.FirstOrDefaultAsync(n => n.Id == id);

        //    _Db.SiteMessageImages.Remove(result);

        //    await _Db.SaveChangesAsync();
        //}

        public async Task Update(SiteMessageImage siteMessageImage)
        {
            _Db.SiteMessageImages.Update(siteMessageImage);
            await _Db.SaveChangesAsync();
        }

        public async Task Create(SiteMessageImage siteMessageImage)
        {
            await _Db.SiteMessageImages.AddAsync(siteMessageImage);
            await _Db.SaveChangesAsync();
        }
    }
}
