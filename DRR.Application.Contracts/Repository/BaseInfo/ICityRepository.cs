using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Domain.BaseInfo;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.BaseInfo
{
    public interface ICityRepository: IRepository
    {
        Task<List<City>> ReadCityByDto(CityDto cityDto);
        Task<City> ReadCityById(int id);
        Task<List<City>> ReadCityByProvinceId(int id);
        Task Create(City city);
        Task Update(Domain.BaseInfo.City city);
        Task Delete(int id);
    }
}
