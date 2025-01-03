using DRR.Application.Contracts.Repository.Insurance;
using DRR.CommandDB;
using DRR.Domain.Insurances;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.InsuranceTypes
{
    public class InsuranceTypeRepository : BaseRepository, IInsuranceTypeRepository
    {
        public InsuranceTypeRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<InsuranceType> ReadInsuranceTypeById(int id)
        {
            var result = await _Db.InsuranceTypes.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task Create(InsuranceType InsuranceType)
        {
            await _Db.InsuranceTypes.AddAsync(InsuranceType);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Insurances.InsuranceType InsuranceType)
        {
            var result = await this.ReadInsuranceTypeById(InsuranceType.Id);

            result.Type = InsuranceType.Type;


            _Db.InsuranceTypes.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.InsuranceTypes.FirstOrDefaultAsync(n => n.Id == id);

            _Db.InsuranceTypes.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
