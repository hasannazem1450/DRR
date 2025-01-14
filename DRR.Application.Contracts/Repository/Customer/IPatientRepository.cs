using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Customer
{
    public interface IPatientRepository : IRepository
    {
        Task<Patient> ReadPatientById(int id);
        Task<List<Patient>> ReadPatients();
        Task<List<Patient>> ReadPatientBySmeProfileId(int id);
        Task<List<Patient>> ReadPatientByCityId(int id);

        Task Delete(int id);

        Task Update(Domain.Customer.Patient patient);

        Task Create(Domain.Customer.Patient patient);
    }

}
