﻿using DRR.Domain.Profile;
using DRR.Domain.Customer;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Specialists
{
    
    public class Specialist : Entity<int>
    {
        public Specialist(string name)
        {
            Name = name;
           
        }

        public int Id { get; set; }
        public string Name { get; set; }
       
        public ICollection<SmeProfile> SmeProfiles { get; set; }
        public ICollection<Doctor> Doctors { get; set; }



    }

}