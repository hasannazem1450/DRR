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
    public class MessagingGroupRepository : BaseRepository, IMessagingGroupRepository
    {
        public MessagingGroupRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<MessagingGroup> ReadById(int id)
        {
            var result = await _Db.MessagingGroups.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        public async Task<List<MessagingGroup>> ReadAll()
        {
            var query = _Db.MessagingGroups;

            return await query.ToListAsync();

        }

        public async Task Delete(int id)
        {
            var result = await _Db.MessagingGroups.FirstOrDefaultAsync(n => n.Id == id);

            _Db.MessagingGroups.Remove(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(MessagingGroup messagingGroup)
        {
            _Db.MessagingGroups.Update(messagingGroup);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(MessagingGroup messagingGroup)
        {
            await _Db.MessagingGroups.AddAsync(messagingGroup);
            await _Db.SaveChangesAsync();
        }
    }
}
