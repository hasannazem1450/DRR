using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.BaseInfo.Province
{
    public class ProvinceDto
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public int? ProvinceCode { get; set; }

        public virtual ICollection<Domain.BaseInfo.City> Cities { get; set; }
        public Domain.BaseInfo.Country Country { get; set; }

        public virtual ICollection<Domain.Profile.SmeProfile> SmeProfiles { get; set; }
    }
}
