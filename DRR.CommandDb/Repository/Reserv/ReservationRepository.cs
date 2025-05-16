using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDB;
using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Utilities.Extensions;

namespace DRR.CommandDb.Repository.Reserv
{
    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<List<Reservation>> ReadReservationtop4firstpage()
        {
            var intdatenow = Convert.ToInt32(DateTime.Now.ToPersianString().TrimForSlash());
            var query = _Db.Reservations
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Doctor)
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Office)
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Clinic)
               .Include(v => v.VisitCost).ThenInclude(t => t.VisitType)
               .Include(t => t.Turns)
               .AsQueryable();
            var result = await query.Where(c => c.ReservationDate == intdatenow)?.OrderBy(x => x.ReservationDate).Take(10).ToListAsync();


            return result;
        }
        public async Task<List<Reservation>> ReadFirstFreeTurnsByDoctorId(int doctorId)
        {
            var intdatenow = Convert.ToInt32(DateTime.Now.ToPersianString().TrimForSlash());
            var query = _Db.Reservations
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Doctor)
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Office)
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Clinic)
               .Include(v => v.VisitCost).ThenInclude(t => t.VisitType)
               .Include(t => t.Turns)
               .AsQueryable();
            var result = await query.Where(c => c.ReservationDate >= intdatenow)?.OrderBy(x => x.ReservationDate).Take(10).ToListAsync();


            return result;
        }
        public async Task<Reservation> ReadReservationById(int id)
        {
            var result = await _Db.Reservations
                .Include(v => v.VisitCost)
                .Include(t => t.Turns)
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Reservation>> ReadReservationByDoctorId(int id)
        {
            var intdatenow = Convert.ToInt32(DateTime.Now.ToPersianString().TrimForSlash());
            var query = _Db.Reservations
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Doctor)
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Office)
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Clinic)
               .Include(v => v.VisitCost).ThenInclude(t => t.VisitType)
               .Include(t => t.Turns)
               .AsQueryable();
            var result = await query.Where(c => c.DoctorTreatmentCenter.DoctorId == id 
            && c.ReservationDate >= intdatenow).OrderBy(x => x.ReservationDate).ToListAsync();


            return result;
        }
        public async Task<List<Reservation>> ReadReservationByDoctorIdByTreatmentCenterId(int did , Guid tid)
        {
            var intdatenow = Convert.ToInt32(DateTime.Now.ToPersianString().TrimForSlash());
            var query = _Db.Reservations
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Doctor)
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Office)
               .Include(s => s.DoctorTreatmentCenter).ThenInclude(d => d.Clinic)
               .Include(v => v.VisitCost).ThenInclude(t => t.VisitType)
               .Include(t => t.Turns)
               .AsQueryable();
            var result = await query.Where(c => c.DoctorTreatmentCenter.DoctorId == did
            && c.ReservationDate >= intdatenow && (c.DoctorTreatmentCenter.OfficeId == tid || c.DoctorTreatmentCenter.ClinicId ==tid)).OrderBy(x => x.ReservationDate).ToListAsync();


            return result;
        }
        public async Task<List<Reservation>> ReadReservationByOfficeTypeId(int id)
        {
            var query = _Db.Reservations
   .Include(s => s.DoctorTreatmentCenter).ThenInclude(o => o.Office)
   .AsQueryable();
            var result = await query
                .Where(c => c.DoctorTreatmentCenter.Office.OfficeTypeId == id).ToListAsync();

            return result;
        }
        public async Task<List<Reservation>> ReadReservationByDoctorTreatmentCenterId(int? id)
        {
            var result = await _Db.Reservations.Where(c => c.DoctorTreatmentCenterId == id).ToListAsync();

            return result;
        }
        public async Task Create(Reservation reservation)
        {
            await _Db.Reservations.AddAsync(reservation);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Reservation Reservation)
        {
            var result = await this.ReadReservationById(Reservation.Id);

            result.DoctorTreatmentCenter.DoctorId = Reservation.DoctorTreatmentCenter.DoctorId;
            result.ReservationDate = Reservation.ReservationDate;
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
