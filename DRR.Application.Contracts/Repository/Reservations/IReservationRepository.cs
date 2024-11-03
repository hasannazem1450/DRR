using DRR.Domain.Reservations;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Reservations
{
    public interface IReservationRepository : IRepository
    {

        Task<Reservation> ReadReservationById(int id);
        Task<List<Reservation>> ReadReservationByDoctorId(int id);
        Task<List<Reservation>> ReadReservationByVisitTypeId(int id);
        Task<List<Reservation>> ReadReservationByDoctorTreatmentCenterId(int? id);

        Task Delete(int id);

        Task Update(Domain.Reservations.Reservation reservation);

        Task Create(Domain.Reservations.Reservation reservation);
    }

}
