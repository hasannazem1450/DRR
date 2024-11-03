using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDB;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.TreatmentCentres
{
    class ClinicTypeRepository : BaseRepository, IClinicTypeRepository
    {
        public ClinicTypeRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<ClinicType> ReadClinicTypeById(int id)
        {
            var result = await _Db.ClinicTypes.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task Create(ClinicType ClinicType)
        {
            await _Db.ClinicTypes.AddAsync(ClinicType);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.TreatmentCenters.ClinicType ClinicType)
        {
            var result = await this.ReadClinicTypeById(ClinicType.Id);

            result.Type = ClinicType.Type;


            _Db.ClinicTypes.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.ClinicTypes.FirstOrDefaultAsync(n => n.Id == id);

            _Db.ClinicTypes.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
