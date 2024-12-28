using DRR.Application.Contracts.Commands.Reserv;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Reserv
{
    public interface IReservationRepository : IRepository
    {

        Task<Reservation> ReadReservationById(int id);
        Task<List<Reservation>> ReadReservationByDoctorId(int id);
        Task<List<Reservation>> ReadReservationByVisitTypeId(int id);
        Task<List<Reservation>> ReadReservationByDoctorTreatmentCenterId(int? id);

        Task Delete(int id);

        Task Update(Reservation reservation);

        Task Create(Reservation reservation);
    }

}
