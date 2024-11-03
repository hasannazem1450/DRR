using DRR.CommandDB;
using Microsoft.EntityFrameworkCore;
using DRR.Utilities.Extensions;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Domain.SiteMessenger;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace DRR.CommandDb.Repository.SiteMessenger
{
    public class SiteMessageRepository : BaseRepository, ISiteMessageRepository
    {
        public SiteMessageRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<SiteMessage> ReadById(int id)
        {
            var result = await _Db.SiteMessages.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        public async Task<List<SiteMessage>> ReadAll()
        {
            var query = _Db.SiteMessages.Include(r => r.SiteMessageRecivers);

            return await query.ToListAsync();

        }

        public async Task Delete(int id)
        {
            var result = await _Db.SiteMessages.FirstOrDefaultAsync(n => n.Id == id);

            _Db.SiteMessages.Remove(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(SiteMessage siteMessage)
        {
            _Db.SiteMessages.Update(siteMessage);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(SiteMessage siteMessage)
        {
            await _Db.SiteMessages.AddAsync(siteMessage);
            await _Db.SaveChangesAsync();
        }

        //public async Task<List<SiteMessage>> ReadByUserId(Guid UserId)
        //{
        //    //var query = await _Db.UserProfiles.Where(r => r.UserId == UserId.ToString()).ToListAsync();
        //    //var query2 = await _Db.SiteMessageRecivers.Include(s => s.SmeProfile).ToListAsync();

        //    //var query =
        //    //   from post in database.Posts
        //    //   join meta in database.Post_Metas on post.ID equals meta.Post_ID
        //    //   where post.ID == id
        //    //   select new { Post = post, Meta = meta };

        //    var qs = from reciver in _Db.SiteMessageRecivers.Include(m => m.SiteMessage) join sme in _Db.UserProfiles.Where(r => r.UserId == UserId.ToString()) on reciver.SmeProfileId equals sme.Id select new { reciver };

        //    var result =(from messages in _Db.SiteMessages join sme in qs on messages.Id equals sme.reciver.SiteMessageId select new { messages }).Union(
        //    from messages in _Db.SiteMessages join sme in _Db.MessagingGroupSmeProfiles on messages.Id equals sme.SmeProfileId join sme2 in qs on messages.Id equals sme2.reciver.SiteMessageId select new { messages });


        //    return result.ToListAsync();

        //}

        public async Task<List<SiteMessage>> ReadByUserId(string userId)
        {
            var result = await _Db.SiteMessageRecivers
                .Include(x => x.SmeProfile.UserProfiles).ThenInclude(x => x.User)
                .Where(w =>
                    w.SmeProfile.UserProfiles.Any(a => a.UserId == userId) ||
                    w.MessagingGroup.MessagingGroupSmeProfiles.Any(x => x.SmeProfile.UserProfiles.Any(a => a.UserId == userId)))
                .Select(s => s.SiteMessage).DistinctBy(x => x.Id).ToListAsync();

            return result;
        }
    }
}
