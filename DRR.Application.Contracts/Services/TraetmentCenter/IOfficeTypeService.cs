using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.Province;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.TraetmentCenter
{
    public interface IOfficeTypeService : IService
    {
        Task<List<OfficeTypeDto>> ConvertToDto(List<OfficeType> OfficeTypes);
        Task<OfficeTypeDto> ConvertToDto(OfficeType OfficeType);
    }
}
