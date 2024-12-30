using DRR.Application.Contracts.Commands.BaseInfo.Province;
using DRR.Domain.BaseInfo;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.BaseInfo
{
    public interface IProvinceRepository : IRepository
    {
        Task<List<Province>> ReadByDto(ProvinceDto provinceDto);
        Task<Province> ReadById(int id);
        Task<List<Province>> Read();
    }
}
