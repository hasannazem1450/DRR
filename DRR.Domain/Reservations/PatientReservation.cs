using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Domain.Finance;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Reservations
{
    public class PatientReservation : Entity<int>
    {
        public PatientReservation(int patientId, int reservationId, int? discountCodeId)
        {
            PatientId = patientId;
            ReservationId = reservationId;
            DiscountCodeId = discountCodeId;


        }

        public int PatientId { get; set; }
        public int ReservationId { get; set; }
        public int? DiscountCodeId { get; set; }


        public Reservation Reservation { get; set; }
        public Patient Patient { get; set; }
        public DiscountCode DiscountCode { get; set; }

    }

}
