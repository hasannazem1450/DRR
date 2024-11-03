using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.BaseInfo.City
{
    public class CreateCityCommand : Command
    {
        public string Name { get; set; }
        public int? Code { get; set; }
        public int ProvinceId { get; set; }
    }

    public class CreateCityCommandResponse : CommandResponse
    {
    }
}
