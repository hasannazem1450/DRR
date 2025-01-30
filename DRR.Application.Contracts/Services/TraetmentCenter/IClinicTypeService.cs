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
    public interface IClinicTypeService : IService
    {
        Task<List<ClinicTypeDto>> ConvertToDto(List<ClinicType> clinicTypes);
        Task<ClinicTypeDto> ConvertToDto(ClinicType clinicType);
    }
}