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
    public class NewsRepository : BaseRepository, INewsRepository
    {
        public NewsRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Domain.News.News> ReadById(int id)
        {
            var result = await _Db.News.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        public async Task<List<Domain.News.News>> Read(NewsDto newsDto)
        {
            var query = _Db.News.AsQueryable();
            if (newsDto.Title != null)
                query = query.Where(q => q.Title == newsDto.Title);

            if (!newsDto.HeadLine.IsNotNullOrEmpty())
                query = query.Where(q => q.HeadLine == newsDto.HeadLine);

            return await query.ToListAsync();
           
        }

        public async Task Delete(int id)
        {
            var result = await _Db.News.FirstOrDefaultAsync(n => n.Id == id);

            _Db.News.Remove(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(Domain.News.News news)
        {
            var result = await this.ReadById(news.Id);

            result.Title = news.Title;
            result.Description = news.Description;
            result.HeadLine = news.HeadLine;
            result.Photo = news.Photo;
            result.SmeProfileId = news.SmeProfileId;

            _Db.News.Update(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(Domain.News.News news)
        {
            await _Db.News.AddAsync(news);
            await _Db.SaveChangesAsync();
        }

        public async Task<List<Domain.News.News>> ReadNewsBySmeProfileId (int SmeProfileId)
        {
            var result = await _Db.News.Where(c => c.SmeProfileId == SmeProfileId).ToListAsync();

            return result;
        }
    }
}
