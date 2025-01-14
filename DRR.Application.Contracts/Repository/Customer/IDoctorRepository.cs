using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Customer
{
    public interface IDoctorRepository : IRepository
    {
        Task<List<Doctor>> ReadAllDoctors();
        Task<Doctor> ReadDoctorById(int id);
        Task<List<Doctor>> ReadDoctorBySmeProfileId(int id);

        Task<List<Doctor>> ReadDoctorBySpecialistId(int id);

        Task Delete(int id);

        Task Update(Domain.Customer.Doctor doctor);

        Task Create(Domain.Customer.Doctor doctor);
    }

}
