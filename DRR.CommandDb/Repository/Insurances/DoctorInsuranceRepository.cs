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
    public class DoctorInsuranceRepository : BaseRepository, IDoctorInsuranceRepository
    {
        public DoctorInsuranceRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<DoctorInsurance> ReadDoctorInsuranceById(int id)
        {
            var result = await _Db.DoctorInsurances.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<DoctorInsurance>> ReadDoctorInsuranceByDoctorId(int id)
        {
            var result = await _Db.DoctorInsurances.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorInsurance>> ReadDoctorInsuranceByInsuranceId(int? id)
        {
            var result = await _Db.DoctorInsurances.Where(c => c.InsuranceId == id).ToListAsync();

            return result;
        }
        public async Task Create(DoctorInsurance DoctorInsurance)
        {
            await _Db.DoctorInsurances.AddAsync(DoctorInsurance);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Insurances.DoctorInsurance DoctorInsurance)
        {
            var result = await this.ReadDoctorInsuranceById(DoctorInsurance.Id);


            result.DoctorId = DoctorInsurance.DoctorId;
            result.InsuranceId = DoctorInsurance.InsuranceId;
            result.ContractSituation = DoctorInsurance.ContractSituation;
            result.InsurancePercent = DoctorInsurance.InsurancePercent;
            result.VisitCostId = DoctorInsurance.VisitCostId;


            _Db.DoctorInsurances.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.DoctorInsurances.FirstOrDefaultAsync(n => n.Id == id);

            _Db.DoctorInsurances.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
