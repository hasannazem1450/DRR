using DRR.Domain.Customer;
using DRR.Domain.Event;
using DRR.Domain.Profile;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRR.Domain.Reserv
{
    public class Reservation : Entity<int>
    {
        public Reservation(int reservationDate, string reservationTime, int doctorTreatmentCenterId, int cancleTimeDuration ,int visitCostId , int totalTurnCount)
        {
            ReservationDate = reservationDate;
            ReservationTime = reservationTime;
            DoctorTreatmentCenterId = doctorTreatmentCenterId;
            CancleTimeDuration = cancleTimeDuration;
            VisitCostId = visitCostId;
            TotalTurnCount = totalTurnCount;
        }
        public void Update(int reservationDate, string reservationTime, int doctorTreatmentCenterId, int cancleTimeDuration, int visitCostId , int totalTurnCount)
        {
            ReservationDate = reservationDate;
            ReservationTime = reservationTime;
            DoctorTreatmentCenterId = doctorTreatmentCenterId;
            CancleTimeDuration = cancleTimeDuration;
            VisitCostId = visitCostId;
            TotalTurnCount = totalTurnCount;
        }

        public int ReservationDate { get; set; }
        public int DoctorTreatmentCenterId { get; set; }
        public int CancleTimeDuration { get; set; }
        public string ReservationTime { get; set; }
        public int VisitCostId { get; set; }
        public int TotalTurnCount { get; set; }
        //[NotMapped]
        //public virtual int? OfficeTypeId { get; set; }
        public DoctorTreatmentCenter DoctorTreatmentCenter { get; set; }
        public VisitCost VisitCost { get; set; }
        public ICollection<Turn> Turns { get; protected set; }



    }

}
