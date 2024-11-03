using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Queries.BaseInfo.City;
using DRR.Application.Contracts.Queries.BaseInfo.Province;
using DRR.Application.Contracts.Services.BaseInfo.Province;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.QueryHandlers.BaseInfo.Province
{
    public class ReadProvinceQueryHandler : IQueryHandler<ReadProvinceDropdownQuery, ReadProvinceDropdownQueryResponse>
    {
        private readonly IProvinceService _provinceService;

        public ReadProvinceQueryHandler(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        public async Task<ReadProvinceDropdownQueryResponse> Execute(ReadProvinceDropdownQuery query, CancellationToken cancellationToken)
        {
            var provinceDto = await _provinceService.Read();

            var result = new ReadProvinceDropdownQueryResponse()
            {
                List = provinceDto,
            };

            return result;
        }
    }
}
