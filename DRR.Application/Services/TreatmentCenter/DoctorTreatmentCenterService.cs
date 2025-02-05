using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Services.TraetmentCenter;
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