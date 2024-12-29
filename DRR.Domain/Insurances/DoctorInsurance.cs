using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Domain.Reserv;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Domain.Insurances
{
    public class DoctorInsurance : Entity<int>
    {
        public DoctorInsurance(int doctorId, int insuranceId, string contractSituation, decimal insurancePercent, int visitCostId, bool isActive)
        {

            DoctorId = doctorId;
            InsuranceId = insuranceId;
            ContractSituation = contractSituation;
            InsurancePercent = insurancePercent;
            VisitCostId = visitCostId;
            IsActive = isActive;

        }
        public void Update(int doctorId, int insuranceId, string contractSituation, decimal insurancePercent, int visitCostId,bool isActive)
        {

            DoctorId = doctorId;
            InsuranceId = insuranceId;
            ContractSituation = contractSituation;
            InsurancePercent = insurancePercent;
            VisitCostId = visitCostId;
            IsActive = isActive;
        }

        public int DoctorId { get; set; }
        public int InsuranceId { get; set; }
        public string ContractSituation { get; set; }
        public decimal InsurancePercent { get; set; }
        public int VisitCostId { get; set; }
        public bool IsActive { get; set; }

        public Insurance Insurance { get; set; }
        public Doctor Doctor { get; set; }
        public VisitCost VisitCost { get; set; }


    }

}
