using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Queries.BaseInfo.City;
using DRR.Application.Contracts.Queries.RoleManager;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.Application.Contracts.Services;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.QueryHandlers.BaseInfo.City
{
    public class ReadCityQueryHandler : IQueryHandler<ReadCityQuery, ReadCityQueryResponse>
    {
        private readonly ICityService _cityService;

        public ReadCityQueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<ReadCityQueryResponse> Execute(ReadCityQuery query, CancellationToken cancellationToken)
        {
            var cityDto = await _cityService.ReadCityByProvinceId(query.ProvinceId);

            var result = new ReadCityQueryResponse()
            {
                List = cityDto,
            };

            return result;
        }
    }
}
