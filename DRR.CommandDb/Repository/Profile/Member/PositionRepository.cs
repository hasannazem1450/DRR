using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Repository.Profile.Member;
using DRR.CommandDB;
using DRR.Domain.Profile.Member;
using Microsoft.EntityFrameworkCore;

namespace DRR.CommandDb.Repository.Profile.Member
{
    public class PositionRepository : BaseRepository, IPositionRepository
    {
        public PositionRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task Create(Position position)
        {
            await _Db.Positions.AddAsync(position);

            await _Db.SaveChangesAsync();
        }

        public async Task Update(Position position)
        {
            var result = await _Db.Positions.FirstOrDefaultAsync(p => p.Id == position.Id);

            result.Name = position.Name;

            _Db.Positions.Update(result);

            await _Db.SaveChangesAsync();
        }

        public async Task<List<Position>> Read()
        {
            var result = await _Db.Positions.ToListAsync();

            return result;
        }

        public async Task<Position> ReadById(int id)
        {
            var result = await _Db.Positions.FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public async Task Delete(int id)
        {
            var position = await _Db.Positions.FirstOrDefaultAsync(p => p.Id == id);
            
            _Db.Positions.Remove(position);

            await _Db.SaveChangesAsync();
        }
    }
}
