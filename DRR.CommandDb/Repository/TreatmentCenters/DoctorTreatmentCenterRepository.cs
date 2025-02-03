using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDB;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.TreatmentCentres
{
    public class DoctorTreatmentCenterRepository : BaseRepository, IDoctorTreatmentCenterRepository
    {
        public DoctorTreatmentCenterRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<DoctorTreatmentCenter>> ReadAllDoctorTreatmentCenters()
        {
            var result = await _Db.DoctorTreatmentCenters
                .Include(x=> x.Doctor)
                .Include(x => x.Clinic)
                .Include(x => x.Office)
                .ToListAsync();

            return result;
        }

        public async Task<DoctorTreatmentCenter> ReadDoctorTreatmentCenterById(int id)
        {
            var result = await _Db.DoctorTreatmentCenters.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorId(int id)
        {
            var result = await _Db.DoctorTreatmentCenters.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByOfficeId(Guid? id)
        {
            var result = await _Db.DoctorTreatmentCenters.Where(c => c.OfficeId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByClinicId(Guid? id)
        {
            var result = await _Db.DoctorTreatmentCenters.Where(c => c.ClinicId == id).ToListAsync();

            return result;
        }
        public async Task Create(DoctorTreatmentCenter DoctorTreatmentCenter)
        {
            await _Db.DoctorTreatmentCenters.AddAsync(DoctorTreatmentCenter);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.TreatmentCenters.DoctorTreatmentCenter DoctorTreatmentCenter)
        {
            var result = await this.ReadDoctorTreatmentCenterById(DoctorTreatmentCenter.Id);

            result.DoctorId = DoctorTreatmentCenter.DoctorId;
            result.ClinicId = DoctorTreatmentCenter.ClinicId;
            result.OfficeId = DoctorTreatmentCenter.OfficeId;
            result.Desc = DoctorTreatmentCenter.Desc;


            _Db.DoctorTreatmentCenters.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.DoctorTreatmentCenters.FirstOrDefaultAsync(n => n.Id == id);

            _Db.DoctorTreatmentCenters.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
