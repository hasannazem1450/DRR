using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Insurances
{
    public class InsuranceType : Entity<int>
    {
        public InsuranceType(string type)
        {
            Type = type;
            
        }

        public int Id { get; set; }
      
        public string Type { get; set; }
        
        public ICollection<PatientInsurance> Insurances { get; set; }


    }

}
