using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services
{
    public interface ICityService : IService
    {
        Task<List<CityDto>> ReadCityByDto(CityDto cityDto);
        Task<CityDto> ReadCityById(int id);
        Task<List<CityDto>> ReadCityByProvinceId(int id);
    }
}
