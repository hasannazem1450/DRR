using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.TraetmentCenter
{
    public interface IDoctorTreatmentCenterService : IService
    {
        Task<List<DoctorTreatmentCenterDto>> FilterByProvinceName(List<DoctorTreatmentCenterDto> dtc, string name);
        Task<List<DoctorTreatmentCenterDto>> FilterByCityName(List<DoctorTreatmentCenterDto> dtc, string name);
        Task<List<DoctorTreatmentCenterDto>> FilterBySpecialistIds(List<DoctorTreatmentCenterDto> dtc, string name);
        Task<List<DoctorTreatmentCenterDto>> FilterBySpecialistName(List<DoctorTreatmentCenterDto> dtc, string name);
        Task<List<DoctorTreatmentCenterDto>> FilterByClinicTypeName(List<DoctorTreatmentCenterDto> dtc, string name);
        Task<List<DoctorTreatmentCenterDto>> FilterByOfficeTypeName(List<DoctorTreatmentCenterDto> dtc, string name);
        Task<List<DoctorTreatmentCenterDto>> FilterByDoctorTreatmentCenterName(List<DoctorTreatmentCenterDto> dtc, string name);
        Task<List<DoctorTreatmentCenterDto>> FilterByDesc(List<DoctorTreatmentCenterDto> dodtcctors, string name);
        Task<List<DoctorTreatmentCenterDto>> ConvertToDto(List<DoctorTreatmentCenter> doctorTreatmentCenters);
        Task<DoctorTreatmentCenterDto> ConvertToDto(DoctorTreatmentCenter doctorTreatmentCenter);
        Task<DoctorTreatmentCenterPackedDto> ConvertToPackedDto(DoctorTreatmentCenter doctorTreatmentCenter);
        Task<List<DoctorTreatmentCenterPackedDto>> ConvertToPackedDto(List<DoctorTreatmentCenter> doctorTreatmentCenters);
    }
}