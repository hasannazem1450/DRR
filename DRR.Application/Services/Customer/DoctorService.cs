using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Domain.BaseInfo;
using DRR.Domain.Customer;
using DRR.Domain.Specialists;
using DRR.Domain.TreatmentCenters;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DRR.Application.Services.Customer
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorTreatmentCenterRepository _dtcRepository;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IDRRFileService _dRRFileService;

        public DoctorService(IDRRFileService dRRFileService, IDoctorTreatmentCenterRepository dtcRepository , IInsuranceRepository insuranceRepository)
        {
            _dRRFileService = dRRFileService;
            _dtcRepository = dtcRepository;
            _insuranceRepository = insuranceRepository;
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
        public async Task<List<DoctorBoxDto>> FilterBoxByName(List<DoctorBoxDto> doctors, string name)
        {
            var result = doctors.Where(w => w.DoctorName.Contains(name) || w.DoctorFamily.Contains(name)).ToList();

            return result;
        }
        public async Task<List<Doctor>> FilterBoxByProvince(List<Doctor> doctors, int provinceId)
        {
            var result = doctors.Where(x => x.DoctorTreatmentCenters.Any(x => x.Office?.City.ProvinceId == provinceId)).ToList();
            return result;
        }
        public async Task<List<Doctor>> FilterBoxByCity(List<Doctor> doctors, int cityId)
        {
            var result = doctors.Where(x => x.DoctorTreatmentCenters.Any(x => x.Office?.CityId == cityId)).ToList();

            return result;
        }
        public async Task<List<Doctor>> FilterBoxBySpecialist(List<Doctor> doctors, string specialistIds)
        {
            List<int> csis = specialistIds.Split(',').Select(int.Parse).ToList();
            var result = doctors.Where(x => csis.Contains(x.SpecialistId)).ToList();

            return result;
        }
        public async Task<List<Doctor>> FilterBoxByBimeAsli(List<Doctor> doctors, string BimeAsli)
        {
            List<Domain.Insurances.Insurance> li =  await _insuranceRepository.ReadAllInsurances();
            Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(BimeAsli);
            int levenshteinDistance = 1000;
            foreach (var item in li )
            {
                if (levenshteinDistance > lev.DistanceFrom(item.Name))
                {
                    levenshteinDistance = lev.DistanceFrom(item.Name);
                    BimeAsli = item.Name;
                }
            }
            var result = doctors.Where(x => x.DoctorInsurances.Any(x => x.Insurance.Name == BimeAsli)).ToList();

            return result;
        }
        public async Task<List<Doctor>> FilterBoxByBimehTakmili(List<Doctor> doctors, string BimehTakmili)
        {
            List<Domain.Insurances.Insurance> li = await _insuranceRepository.ReadAllInsurances();
            Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(BimehTakmili);
            int levenshteinDistance = 1000;
            foreach (var item in li)
            {
                if (levenshteinDistance > lev.DistanceFrom(item.Name))
                {
                    levenshteinDistance = lev.DistanceFrom(item.Name);
                    BimehTakmili = item.Name;
                }
            }
            var result = doctors.Where(x => x.DoctorInsurances.Any(x => x.Insurance.Name == BimehTakmili)).ToList();

            return result;
        }
        public async Task<List<Doctor>> FilterBoxByJustOnline(List<Doctor> doctors, bool JustOnline)
        {
            string JustOnlineCodes = "2,3,4";
            List<int> joc = JustOnlineCodes.Split(',').Select(int.Parse).ToList();
            var result = doctors.Where(x => x.DoctorTreatmentCenters.Any(x => joc.Contains(x.Office?.OfficeTypeId??0))).ToList();

            return result;
        }
        public async Task<List<Doctor>> FilterBoxByHasTurn(List<Doctor> doctors, bool HasTurn)
        {
            int actdate = DatetimeExtension.DateToNumber(DateTime.Now.ToPersianString());
            var result = doctors.Where(x => x.Reservations.Any(x => x.ReservationDate >= actdate)).ToList();

            return result;
        }
        public async Task<List<Doctor>> FilterBoxByAcceptInsurance(List<Doctor> doctors, bool AcceptInsurance)
        {
            var result = doctors.Where(x => x.DoctorInsurances.Any(x => x.InsuranceId >=1 )).ToList();
            return result;
        }

        public async Task<List<Doctor>> FilterBoxByGender(List<Doctor> doctors, bool Gender)
        {
            var result = doctors.Where(x => x.Gender == Gender).ToList();

            return result;
        }
        public async Task<List<Doctor>> FilterBoxByDate(List<Doctor> doctors, string Sdate, string Edate)
        {
            if (Sdate == null || Sdate == "")
            {
                Sdate = DateTime.Now.ToPersianString();
            }
            if (Edate == null || Edate == "")
            {
                Edate = "1500/01/01";
            }

            int isdate = DatetimeExtension.DateToNumber(Sdate);
            int iedate = DatetimeExtension.DateToNumber(Edate);

            var result = doctors.Where(x => x.DoctorTreatmentCenters.Any(y => y.Reservations.Any(z => z.ReservationDate >= isdate && z.ReservationDate <= iedate))).ToList();

            return result;
        }

        public async Task<List<Doctor>> FilterBoxByOnlineTypeId(List<Doctor> doctors, int onlineTypeId)
        {
            var result = doctors.Where(x => x.DoctorTreatmentCenters.Any(x => x.Office?.OfficeTypeId == onlineTypeId)).ToList();

            return result;
        }

        public async Task<List<Doctor>> FilterBoxByOfficeOrClinicHozoori(List<Doctor> doctors, bool OfficeOrClinicHozoori)
        {
            var result = doctors;
            if (OfficeOrClinicHozoori)
            result = doctors.Where(x => x.DoctorTreatmentCenters.Any(x => x.OfficeId == null)).ToList();
            else
            result = doctors.Where(x => x.DoctorTreatmentCenters.Any(x => x.ClinicId == null)).ToList();
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
                result = result.Where(w => w.DoctorTreatmentCenters.Clinic.City.Name.Contains(filters.CityName) ||
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
        public async Task<List<DoctorBoxDto>> ConvertToBoxDto(List<Doctor> doctors)
        {
            var result = doctors.Select(s => ConvertToBoxDto(s).Result).ToList();

            return result;
        }
        public async Task<DoctorBoxDto> ConvertToBoxDto(Doctor doctor)
        {
            var dtcl = await _dtcRepository.ReadDoctorTreatmentCenterByDoctorId(doctor.Id);
            DoctorBoxDto result;
            if (dtcl.Count > 0)
            {
                result = new DoctorBoxDto
                {
                    Id = doctor.Id,
                    DoctorName = doctor.DoctorName,
                    DoctorFamily = doctor.DoctorFamily,

                    DocExperiance = doctor.DocExperiance,
                    DocInstaLink = doctor.DocInstaLink,

                    Desc = doctor.Desc,
                    specialist = doctor.Specialist.Name,
                    DoctorTreatmentCenterList = dtcl,

                };
            }
            else
            {
                result = new DoctorBoxDto
                {
                    Id = doctor.Id,
                    DoctorName = doctor.DoctorName,
                    DoctorFamily = doctor.DoctorFamily,

                    DocExperiance = doctor.DocExperiance,
                    DocInstaLink = doctor.DocInstaLink,

                    Desc = doctor.Desc,

                };
            }

            return result;
        }
    }
}
