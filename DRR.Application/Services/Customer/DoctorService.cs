using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Domain.Customer;
using DRR.Domain.Specialists;
using DRR.Utilities.Extensions;

namespace DRR.Application.Services.Customer
{
    public class DoctorService :IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDRRFileService _dRRFileService;

        public DoctorService(IDRRFileService dRRFileService)
        {
            _dRRFileService = dRRFileService;
        }
        public async Task<DoctorDto> ReadById(int id)
        {
            var doctor = await _doctorRepository.ReadDoctorById(id);

            var result = await ConvertToDto(doctor);

            return result;
        }
        public async Task<List<DoctorDto>> ReadDoctorBySmeProfileId(int smeProfileId)
        {
            var doctor = await _doctorRepository.ReadDoctorById(smeProfileId);

            var result = new DoctorDto()
            {
                Id = doctor.Id,
                DoctorName = doctor.DoctorName,
                DoctorFamily = doctor.DoctorFamily,
              
                DocExperiance = doctor.DocExperiance,
                DocInstaLink = doctor.DocInstaLink,
               
                Desc = doctor.Desc,
                SmeProfile = doctor.SmeProfile,
                specialist = doctor.Specialist.Name

            };

            var resualtlist = new List<DoctorDto>();
            resualtlist.Add(result);
            return (resualtlist);
        }

        public async Task<List<DoctorDto>> FilterByName(List<DoctorDto> doctors, string name)
        {
            var result = doctors.Where(w => w.DoctorName.Contains(name) || w.DoctorFamily.Contains(name)).ToList();

            return result;
        }
        public async Task<List<DoctorDto>> FilterByProvince(List<DoctorDto> doctors, int provinceId)
        {
            var result = doctors.Where(w => w.DoctorTreatmentCenters.Office.City.Province.Id == provinceId ||
            w.DoctorTreatmentCenters.Clinic.City.Province.Id == provinceId).ToList();

            return result;
        }
        public async Task<List<DoctorDto>> FinalFilter(List<DoctorDto> doctors, ReadDoctorQueryFilters filters)
        {


            var result = doctors;

            if (filters.DoctorName.IsNotNullOrEmpty())
                result = result.Where(w => w.DoctorName.Contains(filters.DoctorName)).ToList();

            if (filters.DoctorFamily.IsNotNullOrEmpty())
                result = result.Where(w => w.DoctorFamily.Contains(filters.DoctorFamily)).ToList();

            if (filters.Bimeh.IsNotNullOrEmpty())
                result = result.Where(w => w.DoctorInsurance.Insurance.Name.Contains(filters.Bimeh)).ToList();

            
            if (filters.CityName.IsNotNullOrEmpty())
                result = result.Where(w => w.DoctorTreatmentCenters.Clinic.City.Name.Contains(filters.CityName )||
                    w.DoctorTreatmentCenters.Office.City.Name.Contains(filters.CityName)).ToList();

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

        public async Task<List<DoctorDto>> ConvertToDto(List<Doctor> doctors)
        {
            var result = doctors.Select(s => new DoctorDto
            {
                Id = s.Id,
                DoctorName = s.DoctorName,
                DoctorFamily = s.DoctorFamily,
               
                DocExperiance = s.DocExperiance,
                DocInstaLink = s.DocInstaLink,
              
                Desc = s.Desc,
                SmeProfile = s.SmeProfile,
               

            }).ToList();

            return result;
        }

        public async Task<DoctorDto> ConvertToDto(Doctor doctor)
        {
            var result = new DoctorDto
            {
                Id = doctor.Id,
                DoctorName = doctor.DoctorName,
                DoctorFamily = doctor.DoctorFamily,
               
                DocExperiance = doctor.DocExperiance,
                DocInstaLink = doctor.DocInstaLink,
               
                Desc = doctor.Desc,
                SmeProfile = doctor.SmeProfile,
            };

            return result;
        }
    }
}
