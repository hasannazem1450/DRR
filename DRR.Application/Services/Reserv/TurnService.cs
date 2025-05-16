using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Domain.Reserv;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Reserv
{
    public class TurnService : ITurnService
    {
        public async Task<List<TurnDto>> ConvertToDto(List<Turn> turns)
        {
            var result = turns.Select(s => ConvertToDto(s).Result).ToList();

            return result;

        }

        public async Task<TurnDto> ConvertToDto(Turn turn)
        {
            DateTime dts;
            bool ress = true;
            ress = DateTime.TryParse(turn.Stime, out dts);
            DateTime dte;
            bool rese = true;
            rese = DateTime.TryParse(turn.Etime, out dte);
            var result = new TurnDto
            {
                TurnNumber = turn.TurnNumber,
                Stime = dts.ToString("HH:mm"),
                Etime = dts.ToString("HH:mm"),
                IsFree = turn.IsFree,
                GradeIsDone = turn.GradeIsDone,
                ReservationId = turn.ReservationId
               
            };

            return result;
        }
    }
}
