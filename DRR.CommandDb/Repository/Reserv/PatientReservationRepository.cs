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
            var result = await _Db.PatientReservations.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<PatientReservation>> ReadPatientReservationByPatientId(int id)
        {
            var result = await _Db.PatientReservations.Where(c => c.PatientId == id).ToListAsync();

            return result;
        }
        public async Task<List<PatientReservation>> ReadPatientReservationByReservationId(int id)
        {
            var result = await _Db.PatientReservations.Where(c => c.ReservationId == id).ToListAsync();

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
            result.ReservationId = PatientReservation.ReservationId;
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
