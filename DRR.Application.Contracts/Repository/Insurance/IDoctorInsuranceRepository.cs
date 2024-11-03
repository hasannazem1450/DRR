using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Insurance
{
    public interface IDoctorInsuranceRepository : IRepository
    {
        
        Task<DoctorInsurance> ReadDoctorInsuranceById(int id);
        Task<List<DoctorInsurance>> ReadDoctorInsuranceByDoctorId(int id);
        Task<List<DoctorInsurance>> ReadDoctorInsuranceByInsuranceId(int? id);

        Task Delete(int id);

        Task Update(Domain.Insurances.DoctorInsurance doctorInsurance);

        Task Create(Domain.Insurances.DoctorInsurance doctorInsurance);
    }

}
