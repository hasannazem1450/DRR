using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Customer
{
    public interface IPatientFavoriteRepository : IRepository
    {
        Task<List<PatientFavorite>> ReadAllPatientFavorites();
        Task<PatientFavorite> ReadPatientFavoriteById(int id);
        Task<List<PatientFavorite>> ReadPatientFavoriteByPatientId(int id);
        Task<List<PatientFavorite>> ReadPatientFavoriteByDoctorId(int id);
        Task<List<PatientFavorite>> ReadPatientFavoriteByArticleId(int id);

        Task Delete(int id);

        Task Update(Domain.Customer.PatientFavorite patientFavorite);

        Task Create(Domain.Customer.PatientFavorite patientFavorite);
    }

}
