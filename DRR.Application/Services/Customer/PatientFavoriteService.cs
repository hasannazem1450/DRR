using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Customer
{
    public class PatientFavoriteService : IPatientFavoriteService
    {

        public async Task<List<PatientFavoriteDto>> ConvertToDto(List<PatientFavorite> pf)
        {
            var result = pf.Select(s => new PatientFavoriteDto
            {
                Id = s.Id,
                PatientId = s.PatientId,
                DoctorId = s.DoctorId,
                ArticleId = s.ArticleId,

            }).ToList();

            return result;
        }

        public async Task<PatientFavoriteDto> ConvertToDto(PatientFavorite pf)
        {
            var result = new PatientFavoriteDto
            {
                Id = pf.Id,
                PatientId= pf.PatientId,
                DoctorId = pf.DoctorId,
                ArticleId = pf.ArticleId,
               
            };

            return result;
        }
    }
}
