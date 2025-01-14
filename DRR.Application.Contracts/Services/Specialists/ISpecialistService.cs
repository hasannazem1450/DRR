using DRR.Application.Contracts.Commands.Specialists;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Specialists
{
    public interface ISpecialistService : IService
    {
        Task<List<SpecialistDto>> ConvertToDto(List<Domain.Specialists.Specialist> Specialists);
        Task<SpecialistDto> ConvertToDto(Domain.Specialists.Specialist Specialist);
        Task<int> GetFileSizeKb(string base64);
    }
}
