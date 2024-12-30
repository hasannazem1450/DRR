using DRR.Application.Contracts.Commands.BaseInfo.Country;
using DRR.Domain.BaseInfo;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.BaseInfo
{
    public interface ICountryRepository :IRepository
    {
        Task<List<Country>> ReadCountryByDto(CountryDto countryDto);
        Task<Country> ReadCountryById(int id);
    }
}
