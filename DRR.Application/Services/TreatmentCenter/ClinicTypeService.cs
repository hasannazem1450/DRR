using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.TreatmentCenter
{
    public class ClinicTypeService : IClinicTypeService
    {
       
        public async Task<List<ClinicTypeDto>> ConvertToDto(List<ClinicType> clinicTypes)
        {
            var result = clinicTypes.Select(s => new ClinicTypeDto
            {
                Id = s.Id,
                Type = s.Type,
            }).ToList();

            return result;
        }
        public async Task<ClinicTypeDto> ConvertToDto(ClinicType clinicType)
        {
            var result = new ClinicTypeDto
            {
                Id = clinicType.Id,
                Type = clinicType.Type,
            };

            return result;
        }
    }
}
