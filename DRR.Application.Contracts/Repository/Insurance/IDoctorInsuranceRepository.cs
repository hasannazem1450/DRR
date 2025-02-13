using DRR.Application.Contracts.Commands.Customer;
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
        Task<List<Domain.Insurances.Insurance>> ReadInsurancesByDoctorId(int doctorid);
        Task<List<Domain.Customer.Doctor>> ReadDoctorsByInsuranceId(int insuranceid);
        Task<List<DoctorInsurance>> ReadDoctorsInsurances();

        Task Delete(int id);

        Task Update(Domain.Insurances.DoctorInsurance doctorInsurance);

        Task Create(Domain.Insurances.DoctorInsurance doctorInsurance);
    }

}
