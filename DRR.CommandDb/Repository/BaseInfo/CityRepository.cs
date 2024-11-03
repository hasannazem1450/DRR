using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.CommandDB;
using DRR.Domain.BaseInfo;
using DRR.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DRR.CommandDb.Repository.BaseInfo
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<City>> ReadCityByDto(CityDto cityDto)
        {
            var query = _Db.Cities.AsQueryable();
            if (cityDto.CityCode != null)
                query = query.Where(q => q.Code == cityDto.CityCode);

            if (!cityDto.CityName.IsNotNullOrEmpty())
                query = query.Where(q => q.Name == cityDto.CityName);

            return await query.ToListAsync();

        }

        public async Task<City> ReadCityById(int id)
        {
            var result = await _Db.Cities.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<City>> ReadCityByProvinceId(int id)
        {
            var result = await _Db.Cities.Where(c => c.ProvinceId == id).ToListAsync();

            return result;
        }
        public async Task Create (City city)
        {
            await _Db.Cities.AddAsync(city);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.BaseInfo.City city)
        {
            var result = await this.ReadCityById(city.Id);

            result.Name = city.Name;
            result.ProvinceId = city.ProvinceId;
            result.Code = city.Code;
          

            _Db.Cities.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Cities.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Cities.Remove(result);

            await _Db.SaveChangesAsync();
        }
    }
}
