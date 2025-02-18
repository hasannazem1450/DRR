﻿using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDB;
using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.VisitCosts
{
    public class VisitCostRepository : BaseRepository, IVisitCostRepository
    {
        public VisitCostRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<VisitCost> ReadVisitCostById(int id)
        {
            var result = await _Db.VisitCosts
                .Include(ot => ot.VisitType)
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<VisitCost>> ReadVisitCostByDoctorId(int id)
        {
            var result = await _Db.VisitCosts
                .Include(ot => ot.VisitType)
                .Where(c => c.DoctorId == id).ToListAsync();

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
            result.Price = VisitCost.Price;
            result.VisitTypeId = VisitCost.VisitTypeId;

            
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
