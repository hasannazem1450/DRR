using DRR.CommandDB;
using Microsoft.EntityFrameworkCore;
using DRR.Utilities.Extensions;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Domain.SiteMessenger;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DRR.CommandDb.Repository.SiteMessenger
{
    public class MessagingGroupSmeProfileRepository : BaseRepository, IMessagingGroupSmeProfileRepository
    {
        public MessagingGroupSmeProfileRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<MessagingGroupSmeProfile> ReadById(int id)
        {
            var result = await _Db.MessagingGroupSmeProfiles.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        public async Task<List<MessagingGroupSmeProfile>> ReadAll()
        {
            var query = _Db.MessagingGroupSmeProfiles;

            return await query.ToListAsync();

        }

        public async Task Delete(int id)
        {
            var result = await _Db.MessagingGroups.FirstOrDefaultAsync(n => n.Id == id);

            _Db.MessagingGroups.Remove(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(MessagingGroupSmeProfile messagingGroupSmeProfile)
        {
            _Db.MessagingGroupSmeProfiles.Update(messagingGroupSmeProfile);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(MessagingGroupSmeProfile messagingGroupSmeProfile)
        {
            await _Db.MessagingGroupSmeProfiles.AddAsync(messagingGroupSmeProfile);
            await _Db.SaveChangesAsync();
        }
    }
}
