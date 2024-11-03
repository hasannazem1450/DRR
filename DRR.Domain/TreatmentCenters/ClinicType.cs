using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.TreatmentCenters
{
    public class ClinicType : Entity<int>
    {
        public ClinicType(string type)
        {
            Type = type;

        }

        public int Id { get; set; }

        public string Type { get; set; }

        public ICollection<Clinic> Clinics { get; set; }


    }

}
