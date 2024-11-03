using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.CommandDB;
using DRR.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using DRR.Domain.Profile.Follow;
using Microsoft.EntityFrameworkCore;

namespace DRR.CommandDb.Repository.Profile
{
    public class FollowProfileRepository : BaseRepository, IFollowProfileRepository
    {
        public FollowProfileRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<FollowProfile> ReadById(int id)
        {
            var result = await _Db.FollowProfiles.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<List<FollowProfile>> Read()
        {
            var result = await _Db.FollowProfiles.ToListAsync();

            return result;
        }

        public async Task Delete(int id)
        {
            var followProfile = await _Db.FollowProfiles.FirstOrDefaultAsync(s => s.Id == id);

            _Db.FollowProfiles.Remove(followProfile);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(FollowProfile followProfile)
        {
            var result = await _Db.FollowProfiles.FirstOrDefaultAsync(s => s.Id == followProfile.Id);

            //result.Name = smeMember.Name;
            //result.ProfilePhoto = smeMember.ProfilePhoto;
            //result.SmeProfileId = smeMember.SmeProfileId;
            //result.PositionId = smeMember.PositionId;

            _Db.FollowProfiles.Update(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(FollowProfile followProfile)
        {
            await _Db.FollowProfiles.AddAsync(followProfile);
            await _Db.SaveChangesAsync();
        }
    }
}
