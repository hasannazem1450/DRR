using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDB;
using DRR.Domain.Reserv;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Reserv
{
    internal class TurnRepository : BaseRepository, ITurnRepository
    {
        public TurnRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<Turn>> GetTurnsByReservationId(int reservationId)
        {
            var query = _Db.Turns.AsQueryable();
            if (query != null)
                query = query.Where(q => q.IsDeleted == false && q.ReservationId == reservationId);



            return await query.ToListAsync();

        }

        public async Task<Turn> ReadTurnById(int id)
        {
            var result = await _Db.Turns.FirstOrDefaultAsync(n => n.Id == id);

            return result;

        }
       
        public async Task Create(Turn Turn)
        {
            await _Db.Turns.AddAsync(Turn);
            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Turns.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Turns.Remove(result);

            await _Db.SaveChangesAsync();
        }
        public async Task UpdateGet(Turn Turn)
        {
            var result = await this.ReadTurnById(Turn.Id);

            result.TurnNumber = Turn.TurnNumber;
            result.Stime = Turn.Stime;
            result.Etime = Turn.Etime;
            result.IsFree = false;
            result.GradeIsDone = Turn.GradeIsDone;
            result.ReservationId = Turn.ReservationId;

            _Db.Turns.Update(result);

            await _Db.SaveChangesAsync();
        }

        public async Task UpdateCancel(Turn Turn)
        {
            var result = await this.ReadTurnById(Turn.Id);

            result.TurnNumber = Turn.TurnNumber;
            result.Stime = Turn.Stime;
            result.Etime = Turn.Etime;
            result.IsFree = true;
            result.GradeIsDone = Turn.GradeIsDone;
            result.ReservationId = Turn.ReservationId;

            _Db.Turns.Update(result);

            await _Db.SaveChangesAsync();
        }
       

    }

}