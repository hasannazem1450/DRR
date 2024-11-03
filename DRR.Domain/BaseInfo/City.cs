using DRR.Domain.Profile;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.BaseInfo
{

    public class City : Entity<int>
    {
        public City(string name, int? code, int provinceId)
        {
            Name = name;
            Code = code;
            ProvinceId = provinceId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Code { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        public ICollection<SmeProfile> SmeProfiles { get; set; }
        public ICollection<Clinic> Clinics { get; set; }

    }
}