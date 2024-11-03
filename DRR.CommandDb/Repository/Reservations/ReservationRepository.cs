using DRR.Application.Contracts.Repository.Reservations;
using DRR.CommandDB;
using DRR.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Reservations
{
    class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Reservation> ReadReservationById(int id)
        {
            var result = await _Db.Reservations.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Reservation>> ReadReservationByDoctorId(int id)
        {
            var result = await _Db.Reservations.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task<List<Reservation>> ReadReservationByVisitTypeId(int id)
        {
            var result = await _Db.Reservations.Where(c => c.VisitTypeId == id).ToListAsync();

            return result;
        }
        public async Task<List<Reservation>> ReadReservationByDoctorTreatmentCenterId(int? id)
        {
            var result = await _Db.Reservations.Where(c => c.DoctorTreatmentCenterId == id).ToListAsync();

            return result;
        }
        public async Task Create(Reservation Reservation)
        {
            await _Db.Reservations.AddAsync(Reservation);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Reservations.Reservation Reservation)
        {
            var result = await this.ReadReservationById(Reservation.Id);

            result.DoctorId = Reservation.DoctorId;
            result.ReservationDate = Reservation.ReservationDate;
            result.VisitTypeId = Reservation.VisitTypeId;
            result.DoctorTreatmentCenterId = Reservation.DoctorTreatmentCenterId;
            result.CancleTimeDuration = Reservation.CancleTimeDuration;

            _Db.Reservations.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Reservations.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Reservations.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
