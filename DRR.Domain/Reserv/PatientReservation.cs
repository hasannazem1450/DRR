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
        public PatientReservation(int patientId, int reservationId,int? discountCodeId,int turnId)
        {
            PatientId = patientId;
            DiscountCodeId = discountCodeId;
            TurnId = turnId;

        }


        public void Update(int patientId, int? discountCodeId,int turnId)
        {
            PatientId = patientId;
            DiscountCodeId = discountCodeId;
            TurnId = turnId ;

        }

        public int PatientId { get; set; }
        public int ReservationId { get; set; }
        public int? DiscountCodeId { get; set; }
        public int TurnId { get; set; }
        public Turn Turn { get; set; }
        public Patient Patient { get; set; }
        public DiscountCode DiscountCode { get; set; }


    }
}
