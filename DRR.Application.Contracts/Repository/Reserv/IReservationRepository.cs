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
        Task<List<Reservation>> ReadReservationtop4firstpage();
        Task<List<Reservation>> ReadFirstFreeTurnsByDoctorId(int doctorId);
        Task<Reservation> ReadReservationById(int id);
        Task<List<Reservation>> ReadReservationByDoctorId(int id);
        Task<List<Reservation>> ReadReservationByDoctorIdByTreatmentCenterId(int did, Guid tid);
        Task<List<Reservation>> ReadReservationByOfficeTypeId(int id);
        Task<List<Reservation>> ReadReservationByDoctorTreatmentCenterId(int? id);

        Task Delete(int id);

        Task Update(Reservation reservation);

        Task Create(Reservation reservation);
    }

}
