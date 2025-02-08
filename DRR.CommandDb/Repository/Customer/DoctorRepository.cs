using DRR.Application.Contracts.Repository.Customer;
using DRR.CommandDB;
using DRR.Domain.Customer;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Customer
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        public DoctorRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<List<Doctor>> ReadAllDoctors()
        {
            var query = _Db.Doctors
               .Include(s => s.SmeProfile)
               .Include(sp => sp.Specialist)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(o => o.Office.City)
               .Include(dtc2 => dtc2.DoctorTreatmentCenters).ThenInclude(c => c.Clinic.City)
               .Include(di => di.DoctorInsurances).ThenInclude(i => i.Insurance)
               .Include(r => r.Reservations).ThenInclude(v=> v.VisitCost).ThenInclude(vt => vt.VisitType)
               .Include(r => r.Reservations).ThenInclude(v=> v.Turns)
               .AsQueryable();

            var result = await query.ToListAsync();

            return result;
        }
        public async Task<Doctor> ReadDoctorById(int id)
        {
            var result = await _Db.Doctors.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }
        public async Task<List<Doctor>> ReadDoctorBySmeProfileId(int smeProfileId)
        {
            var result = await _Db.Doctors.Where(c => c.SmeProfileId == smeProfileId).ToListAsync();

            return result;
        }
        public async Task<List<Doctor>> ReadDoctorBySpecialistId(int id)
        {
            var result = await _Db.Doctors.Where(c => c.SpecialistId == id).ToListAsync();

            return result;
        }
       
        public async Task Create(Doctor Doctor)
        {
            await _Db.Doctors.AddAsync(Doctor);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Customer.Doctor Doctor)
        {
            var result = await this.ReadDoctorById(Doctor.Id);


            result.DoctorName = Doctor.DoctorName;
            result.DoctorFamily = Doctor.DoctorFamily;
            result.NationalId = Doctor.NationalId;
            result.SpecialistId = Doctor.SpecialistId;
            result.CodeNezam = Doctor.CodeNezam;
            result.DocExperiance = Doctor.DocExperiance;
            result.DocInstaLink = Doctor.DocInstaLink;
            result.Mobile = Doctor.Mobile;
            result.Desc = Doctor.Desc;


            _Db.Doctors.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Doctors.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Doctors.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
