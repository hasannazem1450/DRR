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
    public class SmeRankRepository : BaseRepository, ISmeRankRepository
    {
        public SmeRankRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<SmeRank> ReadSmeRankById(int id)
        {
            var result = await _Db.SmeRanks.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }
    }
}
