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
    public class PatientInsuranceRepository : BaseRepository, IPatientInsuranceRepository
    {
        public PatientInsuranceRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<PatientInsurance> ReadPatientInsuranceById(int id)
        {
            var result = await _Db.PatientInsurances.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }
        public async Task<List<PatientInsurance>> ReadPatientInsuranceByPatientId(int id)
        {
            var result = await _Db.PatientInsurances.Where(c => c.PatientId == id).ToListAsync();

            return result;
        }

        public async Task<List<PatientInsurance>> ReadPatientInsuranceByInsuranceId(int? id)
        {
            var result = await _Db.PatientInsurances.Where(c => c.InsuranceId == id).ToListAsync();

            return result;
        }
        public async Task<List<PatientInsurance>> ReadPatientInsuranceByInsuranceTypeId(int? id)
        {
            var result = await _Db.PatientInsurances.Where(c => c.Insurance.InsuranceTypeId == id).ToListAsync();

            return result;
        }
        public async Task Create(PatientInsurance PatientInsurance)
        {
            await _Db.PatientInsurances.AddAsync(PatientInsurance);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Insurances.PatientInsurance PatientInsurance)
        {
            var result = await this.ReadPatientInsuranceById(PatientInsurance.Id);

            result.PatientId = PatientInsurance.PatientId;
            result.Insurance.InsuranceTypeId = PatientInsurance.Insurance.InsuranceTypeId;
            result.InsuranceId = PatientInsurance.InsuranceId;


            _Db.PatientInsurances.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.PatientInsurances.FirstOrDefaultAsync(n => n.Id == id);

            _Db.PatientInsurances.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
