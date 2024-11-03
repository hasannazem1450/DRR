using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.Application.Contracts.Services;

namespace DRR.Application.Services.BaseInfo.City
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityDto>> ReadCityByDto(CityDto cityDto)
        {
            var read = await _cityRepository.ReadCityByDto(cityDto);

            var result = read.Select(item => new CityDto()
                {
                    Id = item.Id, CityCode = item.Code, CityName = item.Name, Province = item.Province,
                })
                .ToList();

            return result;
        }

        public async Task<CityDto> ReadCityById(int id)
        {
            var city= await _cityRepository.ReadCityById(id);

            var result = new CityDto()
            {
                Id = city.Id,
                CityCode = city.Code,
                CityName = city.Name,
                Province = city.Province,
            };

            return result;
        }

        public async Task<List<CityDto>> ReadCityByProvinceId(int id)
        {
            var city = await _cityRepository.ReadCityByProvinceId(id);

            var result = new List<CityDto>();

            foreach (var item in city)
            {
                var dto = new CityDto()
                {
                    Id = item.Id,
                    CityCode = item.Code,
                    CityName = item.Name,
                    Province = item.Province,
                };

                result.Add(dto);
            }

            return result;
        }
    }
}
