using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Queries.RoleManager;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.BaseInfo.City
{
    public class ReadCityQuery : Query
    {
        public int ProvinceId { get; set; }
    }

    public class ReadCityQueryResponse : QueryResponse
    {
        public ReadCityQueryResponse()
        {
            List = new List<CityDto>();
        }
        public List<CityDto> List { get; set; }
    }
}
