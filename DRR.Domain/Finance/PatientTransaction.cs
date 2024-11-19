using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Domain.Reservations;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Finance
{
    public class PatientTransaction : Entity<int>
    {
        public PatientTransaction(int patientId, string transactionDate, int paymentNumber, int patientReservationId)
        {

            PatientId = patientId;
            TransactionDate = transactionDate;
            PaymentNumber = paymentNumber;
            PatientReservationId = patientReservationId;
        }

        public int PatientId { get; set; }
        public string TransactionDate { get; set; }
        public int PaymentNumber { get; set; }
        public int PatientReservationId { get; set; }

        
        public PatientReservation PatientReservation { get; set; }
        public Patient Patient { get; set; }


        public ICollection<SmeProfile> SmeProfiles { get; set; }


    }

}
