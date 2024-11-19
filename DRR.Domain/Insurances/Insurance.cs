using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Insurances
{
    public class Insurance : Entity<int>
    {
        public Insurance(string name,int insuranceTypeId)
        {
            InsuranceTypeId = insuranceTypeId;
            Name = name;
           
        }

        public int InsuranceTypeId { get; set; }
        public string Name { get; set; }

        public InsuranceType InsuranceType { get; set; }


        public ICollection<PatientInsurance> Insurances { get; set; }
        public ICollection<DoctorInsurance> DoctorInsurances { get; set; }


    }

}
