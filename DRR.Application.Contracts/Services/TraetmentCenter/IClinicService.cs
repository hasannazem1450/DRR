using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracs.Common.Enums;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.TraetmentCenter
{
    public interface IClinicService : IService
    {
        Task<ClinicDto> ConvertToDto(Clinic Clinic ,int doctorsCout);
        Task<List<ClinicDto>> FilterByName(List<ClinicDto> Clinics, string name);
        Task<List<ClinicDto>> FilterByProvinceOrCity(List<ClinicDto> Clinics, string pcname);
    }
}