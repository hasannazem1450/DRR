using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Services.Specialists;
using DRR.Domain.Specialists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Specialists
{
    public class SpecialistService : ISpecialistService
    {
        public async Task<List<SpecialistDto>> ConvertToDto(List<Domain.Specialists.Specialist> specialists)
        {
            var result = specialists.Select(s => new SpecialistDto
            {
                Id = s.Id,
               Name = s.Name,
            }).ToList();

            return result;
        }

        public async Task<SpecialistDto> ConvertToDto(Domain.Specialists.Specialist specialist)
        {
            var result = new SpecialistDto
            {
                Id = specialist.Id,
                Name = specialist.Name,
               
            };

            return result;
        }

    }
}
