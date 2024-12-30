using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.Province;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.BaseInfo.Province
{
    public class ReadProvinceQuery : Query
    {

    }

    public class ReadProvinceDropdownQuery : Query 
    {
        public ReadProvinceDropdownQuery()
        {
            List = new List<ProvinceDtoDropdown>();
        }
        public List<ProvinceDtoDropdown> List { get; set; }
    }

    public class ReadProvinceQueryResponse : QueryResponse
    {
        public ReadProvinceQueryResponse()
        {
            List = new List<ProvinceDto>();
        }
        public List<ProvinceDto> List { get; set; }
    }

    public class ReadProvinceDropdownQueryResponse : QueryResponse
    {
        public ReadProvinceDropdownQueryResponse()
        {
            List = new List<ProvinceDtoDropdown>();
        }
        public List<ProvinceDtoDropdown> List { get; set; }
    }
}
