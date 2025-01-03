using DRR.Domain.Customer;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Specialists
{
    
    public class Specialist : Entity<int>
    {
        public Specialist()
        {
          

        }
        public Specialist(string name)
        {
            Name = name;
           
        }
        public void Update(string name)
        {
            Name = name;

        }

        public string Name { get; set; }
       
        public ICollection<Doctor> Doctors { get; set; }



    }

}
