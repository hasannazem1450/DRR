using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Reserv
{
    public class CreateReservationDateToDateCommand :Command
    {
        public string ReservationFromDate { get; set; }
        public string ReservationToDate { get; set; }
        public int DoctorTreatmentCenterId { get; set; }
        public int CancleTimeDuration { get; set; }
        public string ReservationTime { get; set; }
        public string ReservationTimeEnd { get; set; }
        public int VisitCostId { get; set; }
        public int TotalTurnCount { get; set; }
        public int Numberofturnsinlimit {  get; set; }
        public int Timeofturnsinlimit {  get; set; }
        public bool[] DayArray { get; set; } = new bool[7];

    }

}
