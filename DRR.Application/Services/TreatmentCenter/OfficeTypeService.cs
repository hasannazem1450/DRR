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
    public class OfficeTypeService : IOfficeTypeService
    {

        public async Task<List<OfficeTypeDto>> ConvertToDto(List<OfficeType> officeTypes)
        {
            var result = officeTypes.Select(s => new OfficeTypeDto
            {
                Id = s.Id,
                Type = s.Type,
            }).ToList();

            return result;
        }
        public async Task<OfficeTypeDto> ConvertToDto(OfficeType officeType)
        {
            var result = new OfficeTypeDto
            {
                Id = officeType.Id,
                Type = officeType.Type,
            };

            return result;
        }
    }
}