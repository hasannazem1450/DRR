using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Insurance
{
    public interface IPatientInsuranceRepository : IRepository
    {

        Task<PatientInsurance> ReadPatientInsuranceById(int id);
        Task<List<PatientInsurance>> ReadPatientInsuranceByPatientId(int id);
        Task<List<PatientInsurance>> ReadPatientInsuranceByInsuranceId(int? id);
        Task<List<PatientInsurance>> ReadPatientInsuranceByInsuranceTypeId(int? id);

        Task Delete(int id);

        Task Update(Domain.Insurances.PatientInsurance patientInsurance);

        Task Create(Domain.Insurances.PatientInsurance patientInsurance);
    }

}
