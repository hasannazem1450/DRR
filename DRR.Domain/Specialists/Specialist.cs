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
        public Specialist(string name,string maxa, string maxaName, string logoFile)
        {
            Name = name;
            Maxa = maxa;
            LogoFile = logoFile;
            MaxaName = maxaName;
        }
        public void Update(string name, string maxa, string maxaName, string logoFile)
        {
            Name = name;
            Maxa = maxa;
            LogoFile = logoFile;
            MaxaName = maxaName;
        }

        public string Name { get; set; }
        public string Maxa { get; set; }
        public string MaxaName { get; set; }
        public string LogoFile { get; set; }
        public ICollection<Doctor> Doctors { get; set; }



    }

}
