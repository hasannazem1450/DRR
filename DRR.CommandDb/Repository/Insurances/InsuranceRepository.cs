using DRR.Application.Contracts.Repository.Insurance;
using DRR.CommandDB;
using DRR.Domain.Insurances;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Insurances
{
    public class InsuranceRepository : BaseRepository, IInsuranceRepository
    {
        public InsuranceRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Insurance> ReadInsuranceById(int id)
        {
            var result = await _Db.Insurances.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task Create(Insurance Insurance)
        {
            await _Db.Insurances.AddAsync(Insurance);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Insurances.Insurance Insurance)
        {
            var result = await this.ReadInsuranceById(Insurance.Id);

            result.Name = Insurance.Name;


            _Db.Insurances.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Insurances.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Insurances.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
