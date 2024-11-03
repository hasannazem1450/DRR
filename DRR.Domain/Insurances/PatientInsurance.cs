using DRR.Domain.Customer;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;



namespace DRR.Domain.Insurances
{
    public class PatientInsurance : Entity<int>
    {
        public PatientInsurance( int patientId, int? insuranceTypeId, int? insuranceId)
        {
            
            PatientId = patientId;
            InsuranceTypeId = insuranceTypeId;
            InsuranceId = insuranceId;
        }

        public int Id { get; set; }
       
        public int PatientId { get; set; }
        public int? InsuranceTypeId { get; set; }
        public int? InsuranceId { get; set; }
                
        public Insurance Insurance { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public Patient Patient { get; set; }


        public ICollection<SmeProfile> SmeProfiles { get; set; }
       

    }

}
