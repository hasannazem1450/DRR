using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Domain.BaseInfo;
using DRR.Domain.Customer;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.TreatmentCenter
{
    public class DoctorTreatmentCenterService : IDoctorTreatmentCenterService
    {
        public async Task<List<DoctorTreatmentCenterDto>> FilterByProvinceName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(x => x.Office.City.Province.Name == name).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterByCityName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(x => x.Office.City.Name == name).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterBySpecialistIds(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            List<int> csis = name.Split(',').Select(int.Parse).ToList();
            var result = dtc.Where(x => csis.Contains(x.Doctor.SpecialistId)).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterBySpecialistName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(x => x.Doctor.Specialist.Name.Contains(name)).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterByClinicTypeName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(x => x.Clinic.ClinicType.Type == name).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterByOfficeTypeName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(x => x.Office.OfficeType.Type == name).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterByDoctorTreatmentCenterName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(w => w.Office.Name.Contains(name) || w.Clinic.Name.Contains(name)).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterByDesc(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(w => w.Desc.Contains(name)).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> ConvertToDto(List<DoctorTreatmentCenter> doctorTreatmentCenters)
        {
            var result = doctorTreatmentCenters.Select(s => new DoctorTreatmentCenterDto
            {
                DoctorId = s.DoctorId,
                ClinicId = s.ClinicId,
                OfficeId = s.OfficeId,
                Desc = s.Desc,
                DoctorName = s.Doctor.DoctorName,
                ClinicName = s.Clinic?.Name,
                OfficeName = s.Office?.Name
            }).ToList();

            return result;
        }
        public async Task<DoctorTreatmentCenterDto> ConvertToDto(DoctorTreatmentCenter doctorTreatmentCenter)
        {
            var result = new DoctorTreatmentCenterDto
            {
                DoctorId = doctorTreatmentCenter.DoctorId,
                ClinicId = doctorTreatmentCenter.ClinicId,
                OfficeId = doctorTreatmentCenter.OfficeId,
                Desc = doctorTreatmentCenter.Desc,
                DoctorName = doctorTreatmentCenter.Doctor.DoctorName,
                ClinicName = doctorTreatmentCenter.Clinic.Name,
                OfficeName = doctorTreatmentCenter.Office.Name
            };

            return result;
        }
    }
}