using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Services.Specialists;
using DRR.Domain.Specialists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DRR.Application.MessageCodes.ExceptionCodes;

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
                Maxa = s.Maxa,
                MaxaName = s.MaxaName,
                LogoFile = s.LogoFile,
            }).ToList();

            return result;
        }

        public async Task<SpecialistDto> ConvertToDto(Domain.Specialists.Specialist specialist)
        {
            var result = new SpecialistDto
            {
                Id = specialist.Id,
                Name = specialist.Name,
                Maxa = specialist.Maxa,
                MaxaName = specialist.MaxaName,
                LogoFile = specialist.LogoFile,

            };

            return result;
        }

        public async Task<int> GetFileSizeKb(string base64)
        {
            var result = 0;

            try
            {
                var token = ";base64,";

                var stringLength = base64.Split(token).LastOrDefault().Length;

                var sizeInBytes = 4 * Math.Ceiling((double)(stringLength / 3)) * 0.5624896334383812;
                var sizeInKb = sizeInBytes / 1000;

                result = (int)sizeInKb;
            }
            catch (Exception)
            {
            }

            return result;
        }

    }
}
