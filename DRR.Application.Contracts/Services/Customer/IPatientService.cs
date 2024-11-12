using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.Customer
{
    public interface IPatientService : IService
    {
        Task<PatientDto> ReadById(int id);
        Task<List<PatientDto>> ReadPatientBySmeProfileId(int SmeProfileId);
    }
}
