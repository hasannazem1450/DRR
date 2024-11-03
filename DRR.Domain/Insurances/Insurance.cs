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
        public Insurance(string name)
        {
            Name = name;
           
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
      
        
        public ICollection<PatientInsurance> Insurances { get; set; }


    }

}
