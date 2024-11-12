using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Services.Customer;

namespace DRR.Application.Services.Customer
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDto> ReadById(int id)
        {
            var Patient = await _patientRepository.ReadPatientById(id);

            return new PatientDto()
            {
                Id = Patient.Id,
                PatientName = Patient.PatientName,
                PatientFamily = Patient.PatientFamily,
                NationalId = Patient.NationalId,
                BirthNumber = Patient.BirthNumber,
                BirthDate = Patient.BirthDate,
                City = Patient.City,
                GlId = Patient.GlId,
                PatientPhone = Patient.PatientPhone,
                NecessaryPhone = Patient.NecessaryPhone,
                Email = Patient.Email,
                Gender = Patient.Gender,
                SmeProfileId = Patient.SmeProfileId,
            };
        }

        public async Task<List<PatientDto>> ReadPatientBySmeProfileId(int SmeProfileId)
        {
            var patient = await _patientRepository.ReadPatientBySmeProfileId(SmeProfileId);

            var result = new List<PatientDto>();

            foreach (var item in patient)
            {
                var dto = new PatientDto()
                {
                    Id = item.Id,
                    PatientName = item.PatientName,
                    PatientFamily = item.PatientFamily,
                    NationalId = item.NationalId,
                    BirthNumber = item.BirthNumber,
                    BirthDate = item.BirthDate,
                    City = item.City,
                    GlId = item.GlId,
                    PatientPhone = item.PatientPhone,
                    NecessaryPhone = item.NecessaryPhone,
                    Email = item.Email,
                    Gender = item.Gender,
                    SmeProfileId = item.SmeProfileId
                };

                result.Add(dto);
            }

            return result;
        }
    }
}
