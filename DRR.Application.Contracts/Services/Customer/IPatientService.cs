using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.Customer
{
    public interface IPatientService : IService
    {
        Task<PatientDto> ReadById(int id); 
        Task<List<PatientDto>> ReadPatientBySmeProfileId(int SmeProfileId);
        Task<List<PatientDto>> FilterByName(List<PatientDto> patients, string name);
        Task<List<PatientDto>> FilterByProvince(List<PatientDto> patients, int provinceId);
        Task<List<PatientDto>> FinalFilter(List<PatientDto> patients, ReadPatientQueryFilters filters);
        Task<List<PatientDto>> ConvertToDto(List<Patient> patients);
        Task<PatientDto> ConvertToDto(Patient patient);
    }
}
