using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Domain.Finance;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Reservations
{
    public class PatientReservation : Entity<int>
    {
        public PatientReservation(int patientId, int reservationId, int visitCostId, int? discountCodeId)
        {
            PatientId = patientId;
            ReservationId = reservationId;
            VisitCostId = visitCostId;
            DiscountCodeId = discountCodeId;


        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ReservationId { get; set; }
        public int VisitCostId { get; set; }
        public int? DiscountCodeId { get; set; }


        public Reservation Reservation { get; set; }
        public Patient Patient { get; set; }
        public VisitCost VisitCost { get; set; }
        public DiscountCode DiscountCode { get; set; }



        public ICollection<SmeProfile> SmeProfiles { get; set; }
    }

}
