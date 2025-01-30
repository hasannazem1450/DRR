using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracs.Common.Enums;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.TraetmentCenter
{
    public interface IOfficeService : IService
    {
        Task<List<OfficeDto>> ConvertToDto(List<Office> Offices);
        Task<OfficeDto> ConvertToDto(Office Office);
        Task<List<OfficeDto>> FilterByName(List<OfficeDto> Offices, string name);
        Task<List<OfficeDto>> FilterByProvinceOrCity(List<OfficeDto> Offices, string pcname);
    }
}