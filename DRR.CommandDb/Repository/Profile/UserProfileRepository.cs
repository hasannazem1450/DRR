using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.CommandDB;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Profile
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<UserProfile>> ReadAll()
        {
            var result = await _Db.UserProfiles.Include(sm => sm.SmeProfile).Include(u => u.User).ToListAsync();

            return result;
        }
        public async Task<List<UserProfile>> ReadByUserId(Guid userid)
        {
            var result = await _Db.UserProfiles.Include(s => s.SmeProfile).Include(u => u.User).Where(c => c.UserId == userid.ToString()).ToListAsync();

            return result;
        }
        public async Task Delete(int id)
        {
            var userProfile = await _Db.UserProfiles.FirstOrDefaultAsync(s => s.Id == id);

            _Db.UserProfiles.Remove(userProfile);

            await _Db.SaveChangesAsync();

        }
        public async Task Create(UserProfile userProfile)
        {
            await _Db.UserProfiles.AddAsync(userProfile);
            await _Db.SaveChangesAsync();
        }

        public async Task<List<UserProfile>> GetUserProfilesByFilter(string? name, string? managerName, SmeType? smeType, string? smeFromDate, string? smeToDate, int perPage, int page)
        {
            var query = GetFilteredQueryable(name, managerName, smeType, smeFromDate?.ToGregorianDateTime(), smeToDate?.ToGregorianDateTime());

            var result = await query.Skip(page * perPage).Take(perPage).ToListAsync();

            return result;
        }

        public async Task<int> GetFilteredUserProfilesCount(string? name, string? managerName, SmeType? smeType, string? smeFromDate, string? smeToDate)
        {
            var query = GetFilteredQueryable(name, managerName, smeType, smeFromDate?.ToGregorianDateTime(), smeToDate?.ToGregorianDateTime());

            var result = await query.CountAsync();

            return result;
        }

        private IQueryable<UserProfile> GetFilteredQueryable(string? name, string? managerName, SmeType? smeType, DateTime? smeFromDate, DateTime? smeToDate)
        {
            var query = _Db.UserProfiles.Include(x => x.SmeProfile).Include(x => x.User).AsQueryable();

            if (name != null)
                query = query.Where(w => w.SmeProfile.SmeName.Contains(name));

            if (managerName != null)
                query = query.Where(w => w.SmeProfile.ManagerName.Contains(managerName));

            if (smeType.HasValue)
                query = query.Where(w => w.SmeProfile.SmeType == smeType.Value);

            if (smeFromDate != null)
                query = query.Where(w => w.SmeProfile.CreatedAt >= smeFromDate.Value);

            if (smeToDate != null)
                query = query.Where(w => w.CreatedAt <= smeToDate.Value);

            return query;
        }
    }
}
