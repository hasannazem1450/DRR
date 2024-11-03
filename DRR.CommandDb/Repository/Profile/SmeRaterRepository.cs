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
    public class SmeRaterRepository : BaseRepository, ISmeRaterRepository
    {
        public SmeRaterRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<bool> IsExist(int id)
        {
            var result = await _Db.SmeRaters.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<SmeRater> ReadSmeRaterById(int id)
        {
            var result = await _Db.SmeRaters.FirstOrDefaultAsync(s => s.Id == id);
            
            return result;
        }
    }
}
