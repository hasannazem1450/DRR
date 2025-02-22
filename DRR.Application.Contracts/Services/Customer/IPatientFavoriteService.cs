using DRR.Application.Contracts.Commands.Customer;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Customer
{
    public interface IPatientFavoriteService : IService
    {
        Task<List<PatientFavoriteDto>> ConvertToDto(List<PatientFavorite> pf);
        Task<PatientFavoriteDto> ConvertToDto(PatientFavorite pf);
    }
}
