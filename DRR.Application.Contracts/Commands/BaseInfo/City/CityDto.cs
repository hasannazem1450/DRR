using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.BaseInfo;

namespace DRR.Application.Contracts.Commands.BaseInfo.City
{
    public class CityDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int? CityCode { get; set; }
        public virtual Domain.BaseInfo.Province Province { get; set; }
    }
}
