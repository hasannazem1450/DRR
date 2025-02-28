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
            var query = _Db.DoctorTreatmentCenters
                .Include(x => x.Doctor).ThenInclude(s=> s.Specialist)
                .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
                .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Office).ThenInclude(c => c.OfficeType)
                .Include(x=> x.Reservations).ThenInclude(t => t.Turns)
                .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
                .AsQueryable();

            var result = await query.ToListAsync(); 

            return result;
        }

        public async Task<DoctorTreatmentCenter> ReadDoctorTreatmentCenterById(int id)
        {
            var query = _Db.DoctorTreatmentCenters
                .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
                .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
                .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Office).ThenInclude(c => c.OfficeType)
                .Include(x => x.Reservations).ThenInclude(t => t.Turns)
                .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
                .AsQueryable();


            var result = await query.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorId(int id)
        {
            var query = _Db.DoctorTreatmentCenters
               .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
               .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
               .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
               .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
               .Include(x => x.Office).ThenInclude(c => c.OfficeType)
               .Include(x => x.Reservations).ThenInclude(t => t.Turns)
               .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
               .AsQueryable();
            var result = await query.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByOfficeId(Guid? id)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .Include(x => x.Reservations).ThenInclude(t => t.Turns)
              .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
              .AsQueryable();

            var result = await query.Where(c => c.OfficeId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByClinicId(Guid? id)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .Include(x => x.Reservations).ThenInclude(t => t.Turns)
              .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
              .AsQueryable();

            var result = await query.Where(c => c.ClinicId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorIdHozoori(int id)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .Include(x => x.Reservations).ThenInclude(t => t.Turns)
              .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
              .AsQueryable();

            var result = await query.Where(c => c.Doctor.Id == id && (c.Clinic != null || c.Office.OfficeType.Id == 1)).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorIdOnline(int id)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .Include(x => x.Reservations).ThenInclude(t => t.Turns)
              .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
              .AsQueryable();

            var result = await query.Where(c => c.Doctor.Id == id && (c.Clinic == null && c.Office.OfficeType.Id != 1)).ToListAsync();

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
