using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Customer
{
    public interface IDoctorService : IService
    {
        Task<DoctorDto> ReadById(int id);
        Task<List<DoctorDto>> ReadDoctorBySmeProfileId(int smeProfileId);
        Task<List<DoctorDto>> FilterByName(List<DoctorDto> doctors, string name);
        Task<List<DoctorBoxDto>> FilterBoxByName(List<DoctorBoxDto> doctors, string name);
        Task<List<Doctor>> FilterBoxByProvince(List<Doctor> doctors, int provinceId);
        Task<List<Doctor>> FilterBoxByCity(List<Doctor> doctors, int cityId);
        Task<List<Doctor>> FilterBoxBySpecialist(List<Doctor> doctors, string specialistIds);
        Task<List<Doctor>> FilterBoxByBimeAsli(List<Doctor> doctors, string BimeAsli);
        Task<List<Doctor>> FilterBoxByBimehTakmili(List<Doctor> doctors, string BimehTakmili);
        Task<List<Doctor>> FilterBoxByJustOnline(List<Doctor> doctors, bool JustOnline);
        Task<List<Doctor>> FilterBoxByHasTurn(List<Doctor> doctors, bool HasTurn);
        Task<List<Doctor>> FilterBoxByAcceptInsurance(List<Doctor> doctors, bool AcceptInsurance);
        Task<List<Doctor>> FilterBoxByGender(List<Doctor> doctors, bool Gender);
        Task<List<Doctor>> FilterBoxByDate(List<Doctor> doctors, string Sdate, string Edate);
        Task<List<Doctor>> FilterBoxByOnlineTypeId(List<Doctor> doctors, int onlineTypeId);
        Task<List<Doctor>> FilterBoxByOfficeOrClinicHozoori(List<Doctor> doctors, bool OfficeOrClinicHozoori);
        Task<List<DoctorDto>> FinalFilter(List<DoctorDto> doctors, ReadDoctorQueryFilters filters);
        Task<List<DoctorDto>> ConvertToDto(List<Doctor> doctors);
        Task<DoctorDto> ConvertToDto(Doctor doctor);
        Task<List<DoctorBoxDto>> ConvertToBoxDto(List<Doctor> doctors, SearchDoctorsQuery query);
        Task<DoctorBoxDto> ConvertToBoxDto(Doctor doctor);
    }
}
