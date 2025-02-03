using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Repository.News;
using DRR.CommandDB;
using Microsoft.EntityFrameworkCore;
using DRR.Utilities.Extensions;

namespace DRR.CommandDb.Repository.News
{
    public class AdsRepository : BaseRepository, IAdsRepository
    {
        public AdsRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Domain.News.Ads> ReadById(int id)
        {
            var result = await _Db.Ads.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        public async Task<List<Domain.News.Ads>> Read()
        {
            var query = _Db.Ads.AsQueryable();
            if (query != null)
                query = query.Where(q => q.IsDeleted == false);

          

            return await query.ToListAsync();
           
        }

        public async Task Delete(int id)
        {
            var result = await _Db.Ads.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Ads.Remove(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(Domain.News.Ads ads)
        {
            var result = await this.ReadById(ads.Id);

            result.Title = ads.Title;
            result.Description = ads.Description;
            result.HeadLine = ads.HeadLine;
            result.Photo = ads.Photo;
            result.SmeProfileId = ads.SmeProfileId;

            _Db.Ads.Update(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(Domain.News.Ads news)
        {
            await _Db.Ads.AddAsync(news);
            await _Db.SaveChangesAsync();
        }

        public async Task<List<Domain.News.Ads>> ReadAdsBySmeProfileId (int SmeProfileId)
        {
            var result = await _Db.Ads.Where(c => c.SmeProfileId == SmeProfileId).ToListAsync();

            return result;
        }
    }
}
