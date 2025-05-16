using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDB;
using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Services.Reserv;

namespace DRR.CommandDb.Repository.Reserv
{
    internal class TurnRepository : BaseRepository, ITurnRepository
    {
        private ITurnService _turnService;
        public TurnRepository(BaseProjectCommandDb db , ITurnService turnService) : base(db)
        {
            _turnService = turnService;
        }

        public async Task<List<TurnDto>> GetTurnsByReservationId(int reservationId)
        {
            var query = _Db.Turns.AsQueryable();
            if (query != null)
                query = query.Where(q => q.IsDeleted == false && q.ReservationId == reservationId);



            var rl = await query.ToListAsync();
            var result = await _turnService.ConvertToDto(rl);
            return result;

        }

        public async Task<TurnDto> ReadTurnByIdDto(int id)
        {
            var query = _Db.Turns.AsQueryable();
            if (query != null)
                query = query.Where(q => q.IsDeleted == false && q.Id == id);
            var r = await query.SingleOrDefaultAsync();
            var result = await _turnService.ConvertToDto(r);
            return result;

        }
        public async Task<Turn> ReadTurnById(int id)
        {
            var query = _Db.Turns.AsQueryable();
            if (query != null)
                query = query.Where(q => q.IsDeleted == false && q.Id == id);
            var result = await query.SingleOrDefaultAsync();
            
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