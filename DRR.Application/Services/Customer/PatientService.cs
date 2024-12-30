using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.Event.Exceptions;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Services.Customer;
using DRR.Utilities.Extensions;

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
                Geolat = Patient.Geolat,
                Geolon = Patient.Geolon,
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
                    Geolon = item.Geolon,
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

        public async Task<List<PatientDto>> FilterByName(List<PatientDto> patients, string name)
        {
            var result = patients.Where(w => w.PatientName.Contains(name) || w.PatientFamily.Contains(name)).ToList();

            return result;
        }
        public async Task<List<PatientDto>> FilterByProvince(List<PatientDto> patients, int provinceId)
        {
            var result = patients.Where(w => w.City.Province.Id == provinceId).ToList();

            return result;
        }
        public async Task<List<PatientDto>> FinalFilter(List<PatientDto> patients, ReadPatientQueryFilters filters)
        {
           

            var result = patients;

            if (filters.PatientName.IsNotNullOrEmpty())
                result = result.Where(w => w.PatientName.Contains(filters.PatientName)).ToList();

            if (filters.PatientFamily.IsNotNullOrEmpty())
                result = result.Where(w => w.PatientFamily.Contains(filters.PatientFamily)).ToList();

            if (filters.ProvinceId.HasValue)
                result = result.Where(w => w.City.ProvinceId == filters.ProvinceId.Value).ToList();

            if (filters.NationalId.IsNotNullOrEmpty())
                result = result.Where(w => w.NationalId.Contains(filters.NationalId)).ToList();

            //if (filters.BirthNumber >0)
            //    result = result.Where(w => w.BirthNumber == filters.BirthNumber)).ToList();

            //if (filters.BirthDate.IsNotNullOrEmpty())
            //    result = result.Where(w => w.ActivityTypes?.Any(a => filters.ActivityTypeIds.Contains(a.Value)) ?? true).ToList();

            //if (filters.FromPrice.HasValue)
            //    result = result.Where(w => filters.FromPrice.Value <= w.Price).ToList();

            //if (filters.ToPrice.HasValue)
            //    result = result.Where(w => w.Price <= filters.ToPrice.Value).ToList();

            return result;
        }
    }
}
