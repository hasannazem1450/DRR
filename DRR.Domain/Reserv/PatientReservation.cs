using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Domain.Finance;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;
using DRR.Domain.TreatmentCenters;

namespace DRR.Domain.Reserv
{
    public class PatientReservation : Entity<int>
    {
        public PatientReservation(int patientId, int reservationId,int turnId, int? discountCodeId)
        {
            PatientId = patientId;
            ReservationId = reservationId;
            TurnId = turnId;
            DiscountCodeId = discountCodeId;

        }


        public void Update(int patientId, int reservationId, int turnId, int? discountCodeId)
        {
            PatientId = patientId;
            ReservationId = reservationId;
            TurnId = turnId;
            DiscountCodeId = discountCodeId;

        }

        public int PatientId { get; set; }
        public int ReservationId { get; set; }
        public int TurnId {  get; set; }
        public int? DiscountCodeId { get; set; }

        public Reservation Reservation { get; set; }
        public Patient Patient { get; set; }
        public Turn Turn { get; set; }
        public DiscountCode DiscountCode { get; set; }


    }
}
