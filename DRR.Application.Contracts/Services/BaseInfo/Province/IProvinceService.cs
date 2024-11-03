using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.Province;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.BaseInfo.Province
{
    public interface IProvinceService : IService
    {
        //Task<List<ProvinceDto>> Read();
        Task<List<ProvinceDtoDropdown>> Read();
    }
}
