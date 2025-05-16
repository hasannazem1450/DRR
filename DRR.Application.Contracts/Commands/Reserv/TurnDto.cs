using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Reserv
{
    public class TurnDto
    {
        public int TurnNumber { get; set; }
        public string Stime { get; set; }
        public string Etime { get; set; }
        public bool IsFree { get; set; }
        public int GradeIsDone { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
