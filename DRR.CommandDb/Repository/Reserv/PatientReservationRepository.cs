using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDB;
using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Reserv
{
    public class PatientReservationRepository : BaseRepository, IPatientReservationRepository
    {
        public PatientReservationRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<PatientReservation> ReadPatientReservationById(int id)
        {

            var query = _Db.PatientReservations
                 .Include(p => p.Patient)
                 .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(c => c.Clinic)
                 .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(o => o.Office)
                 .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(d => d.Doctor)
                 .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(v => v.VisitCost).ThenInclude(vt => vt.VisitType)
                 .Include(d => d.DiscountCode)
                 .AsQueryable();

            var result = await query.Where(c => c.Id == id).FirstOrDefaultAsync();

            return result;
        }
        public async Task<List<PatientReservation>> ReadAllPatientReservations()
        {
            var query = _Db.PatientReservations
                .Include(p => p.Patient)
                .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(c => c.Clinic)
                .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(o => o.Office)
                .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(d => d.Doctor)
                .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(v => v.VisitCost).ThenInclude(vt => vt.VisitType)
                .Include(d => d.DiscountCode)
                .AsQueryable();

            var result = await query.ToListAsync();

            return result;
           
        }
        public async Task<List<PatientReservation>> ReadPatientReservationByPatientId(int id)
        {

            var query = _Db.PatientReservations
               .Include(p => p.Patient)
               .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(c => c.Clinic)
               .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(o => o.Office)
               .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(d => d.Doctor)
               .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(v => v.VisitCost).ThenInclude(vt => vt.VisitType)
               .Include(d => d.DiscountCode)
               .AsQueryable();

            var result = await query.Where(c => c.PatientId == id).ToListAsync();

            return result;
        }
        public async Task<List<PatientReservation>> ReadPatientReservationByReservationId(int id)
        {
            var query = _Db.PatientReservations
   .Include(p => p.Patient)
   .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(c => c.Clinic)
   .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(o => o.Office)
   .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(dtc => dtc.DoctorTreatmentCenter).ThenInclude(d => d.Doctor)
   .Include(t => t.Turn).ThenInclude(r => r.Reservation).ThenInclude(v => v.VisitCost).ThenInclude(vt => vt.VisitType)
   .Include(d => d.DiscountCode)
   .AsQueryable();

            var result = await query.Where(c => c.Turn.ReservationId == id).ToListAsync();

            return result;


        }
        public async Task Create(PatientReservation PatientReservation)
        {
            await _Db.PatientReservations.AddAsync(PatientReservation);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Reserv.PatientReservation PatientReservation)
        {
            var result = await this.ReadPatientReservationById(PatientReservation.Id);


            result.PatientId = PatientReservation.PatientId;
            result.DiscountCodeId = PatientReservation.DiscountCodeId;

          
            _Db.PatientReservations.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.PatientReservations.FirstOrDefaultAsync(n => n.Id == id);

            _Db.PatientReservations.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
