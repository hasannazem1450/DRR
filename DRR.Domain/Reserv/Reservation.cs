using DRR.Domain.Customer;
using DRR.Domain.Profile;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Reserv
{
    public class Reservation : Entity<int>
    {
        public Reservation(string reservationDate, string reservationTime, int visitTypeId, int doctorTreatmentCenterId, int cancleTimeDuration ,int visitCostId)
        {
            ReservationDate = reservationDate;
            ReservationTime = reservationTime;
            VisitTypeId = visitTypeId;
            DoctorTreatmentCenterId = doctorTreatmentCenterId;
            CancleTimeDuration = cancleTimeDuration;
            VisitCostId = visitCostId;
        }
        public void Update(string reservationDate, string reservationTime, int visitTypeId, int doctorTreatmentCenterId, int cancleTimeDuration, int visitCostId)
        {
            ReservationDate = reservationDate;
            ReservationTime = reservationTime;
            VisitTypeId = visitTypeId;
            DoctorTreatmentCenterId = doctorTreatmentCenterId;
            CancleTimeDuration = cancleTimeDuration;
            VisitCostId = visitCostId;
        }

        public string ReservationDate { get; set; }
        public int VisitTypeId { get; set; }
        public int DoctorTreatmentCenterId { get; set; }
        public int CancleTimeDuration { get; set; }
        public string ReservationTime { get; set; }
        public int VisitCostId { get; set; }

        public VisitType VisitType { get; set; }
        public DoctorTreatmentCenter DoctorTreatmentCenter { get; set; }
        public VisitCost VisitCost { get; set; }


    }

}
