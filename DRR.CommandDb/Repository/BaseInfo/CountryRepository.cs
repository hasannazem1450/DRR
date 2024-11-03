using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.Country;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.CommandDB;
using DRR.Domain.BaseInfo;

namespace DRR.CommandDb.Repository.BaseInfo
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public CountryRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<Country>> ReadCountryByDto(CountryDto countryDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Country> ReadCountryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
