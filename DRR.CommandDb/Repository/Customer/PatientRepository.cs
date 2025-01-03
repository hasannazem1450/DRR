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
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Patient> ReadPatientById(int id)
        {
            var result = await _Db.Patients.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Patient>> ReadPatientBySmeProfileId(int id)
        {
            var result = await _Db.Patients.Where(c => c.SmeProfileId == id).ToListAsync();

            return result;
        }


        public async Task<List<Patient>> ReadPatientByCityId(int id)
        {
            var result = await _Db.Patients.Where(c => c.CityId == id).ToListAsync();

            return result;
        }
        public async Task Create(Patient Patient)
        {
            await _Db.Patients.AddAsync(Patient);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Customer.Patient Patient)
        {
            var result = await this.ReadPatientById(Patient.Id);

            result.PatientName = Patient.PatientName;
            result.PatientFamily = Patient.PatientFamily;
            result.NationalId = Patient.NationalId;
            result.BirthNumber = Patient.BirthNumber;
            result.BirthDate = Patient.BirthDate;
            result.CityId = Patient.CityId;
            result.Geolat = Patient.Geolat;
            result.Geolon = Patient.Geolon;
            result.PatientPhone = Patient.PatientPhone;
            result.NecessaryPhone = Patient.NecessaryPhone;
            result.Email = Patient.Email;
            result.Gender = Patient.Gender;



            _Db.Patients.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Patients.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Patients.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
