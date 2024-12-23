using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDB;
using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.VisitCosts
{
    class VisitCostRepository : BaseRepository, IVisitCostRepository
    {
        public VisitCostRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<VisitCost> ReadVisitCostById(int id)
        {
            var result = await _Db.VisitCosts.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<VisitCost>> ReadVisitCostByDoctorId(int id)
        {
            var result = await _Db.VisitCosts.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task<List<VisitCost>> ReadVisitCostByVisitTypeId(int id)
        {
            var result = await _Db.VisitCosts.Where(c => c.VisitTypeId == id).ToListAsync();

            return result;
        }
        
        public async Task Create(VisitCost VisitCost)
        {
            await _Db.VisitCosts.AddAsync(VisitCost);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(VisitCost VisitCost)
        {
            var result = await this.ReadVisitCostById(VisitCost.Id);

            result.DoctorId = VisitCost.DoctorId;
            result.VisitTypeId = VisitCost.VisitTypeId;
            result.Price = VisitCost.Price;

            
            _Db.VisitCosts.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.VisitCosts.FirstOrDefaultAsync(n => n.Id == id);

            _Db.VisitCosts.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
