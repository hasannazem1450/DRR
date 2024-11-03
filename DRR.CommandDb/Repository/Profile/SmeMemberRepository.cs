using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Repository.Profile;
using DRR.CommandDB;
using DRR.Domain.Profile;
using Microsoft.EntityFrameworkCore;

namespace DRR.CommandDb.Repository.Profile
{
    public class SmeMemberRepository : BaseRepository, ISmeMemberRepository
    {
        public SmeMemberRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<SmeMember> ReadById(int id)
        {
            var result = await _Db.SmeMembers.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<List<SmeMember>> Read()
        {
            var result = await _Db.SmeMembers.ToListAsync();

            return result;
        }

        public async Task Delete(int id)
        {
            var smeMember = await _Db.SmeMembers.FirstOrDefaultAsync(s => s.Id == id);

            _Db.SmeMembers.Remove(smeMember);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(SmeMember smeMember)
        {
            var result = await _Db.SmeMembers.FirstOrDefaultAsync(s => s.Id == smeMember.Id);

            result.Name = smeMember.Name;
            result.ProfilePhoto = smeMember.ProfilePhoto;
            result.SmeProfileId = smeMember.SmeProfileId;
            result.PositionId = smeMember.PositionId;

            _Db.SmeMembers.Update(result);

            await _Db.SaveChangesAsync();
        }

        public async Task Create(SmeMember smeMember)
        {
            await _Db.SmeMembers.AddAsync(smeMember);
        }
    }
}
