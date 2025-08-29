using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDB;
using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Reservations
{
    public class VisitTypeRepository : BaseRepository, IVisitTypeRepository
    {
        public VisitTypeRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<VisitType>> ReadVisitTypes()
        {
            var result = await _Db.VisitTypes
                .ToListAsync();

            return result;
        }
        public async Task<VisitType> ReadVisitTypeById(int id)
        {
            var result = await _Db.VisitTypes.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

       
        public async Task Create(VisitType VisitType)
        {
            await _Db.VisitTypes.AddAsync(VisitType);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(VisitType VisitType)
        {
            var result = await this.ReadVisitTypeById(VisitType.Id);


            result.Id = VisitType.Id;
           

            _Db.VisitTypes.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.VisitTypes.FirstOrDefaultAsync(n => n.Id == id);

            _Db.VisitTypes.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
