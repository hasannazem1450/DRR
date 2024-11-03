using DRR.Domain.Profile;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Reservations
{
    public class Reservation : Entity<int>
    {
        public Reservation(int doctorId, string reservationDate, int visitTypeId, int? doctorTreatmentCenterId, int cancleTimeDuration)
        {
            DoctorId = doctorId;
            ReservationDate = reservationDate;
            VisitTypeId= visitTypeId;
            DoctorTreatmentCenterId = doctorTreatmentCenterId;
            CancleTimeDuration = cancleTimeDuration;
        }

        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string ReservationDate { get; set; }
        public int VisitTypeId { get; set; }
        public int? DoctorTreatmentCenterId { get; set; }
        public int CancleTimeDuration { get; set; }



        public VisitType VisitType { get; set; }
        public Office Office { get; set; }
        public Clinic Clinic { get; set; }


        public ICollection<SmeProfile> SmeProfiles { get; set; }
        
    }

}
