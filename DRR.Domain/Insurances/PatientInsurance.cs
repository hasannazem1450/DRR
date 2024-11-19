using DRR.Domain.Customer;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;



namespace DRR.Domain.Insurances
{
    public class PatientInsurance : Entity<int>
    {
        public PatientInsurance( int patientId,int insuranceId)
        {
            
            PatientId = patientId;
            InsuranceId = insuranceId;
        }

        public int Id { get; set; }
       
        public int PatientId { get; set; }
        public int InsuranceId { get; set; }
                
        public Insurance Insurance { get; set; }
        public Patient Patient { get; set; }

       

    }

}
