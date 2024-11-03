using DRR.Application.Contracts.Repository.Finance;
using DRR.CommandDB;
using DRR.Domain.Finance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Finance
{
    class DiscountCodeRepository : BaseRepository, IDiscountCodeRepository
    {
        public DiscountCodeRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<DiscountCode> ReadDiscountCodeById(int id)
        {
            var result = await _Db.DiscountCodes.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task Create(DiscountCode DiscountCode)
        {
            await _Db.DiscountCodes.AddAsync(DiscountCode);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Finance.DiscountCode DiscountCode)
        {
            var result = await this.ReadDiscountCodeById(DiscountCode.Id);

            result.Code = DiscountCode.Code;
            result.DiscountPercent = DiscountCode.DiscountPercent;
            result.IsUsed = DiscountCode.IsUsed;


            _Db.DiscountCodes.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.DiscountCodes.FirstOrDefaultAsync(n => n.Id == id);

            _Db.DiscountCodes.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
