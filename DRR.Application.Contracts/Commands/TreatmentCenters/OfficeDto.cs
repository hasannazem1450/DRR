using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class OfficeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string Phone { get; set; }
        public string SiamCode { get; set; }
        public virtual Domain.BaseInfo.Province Province { get; set; }
    }
}
