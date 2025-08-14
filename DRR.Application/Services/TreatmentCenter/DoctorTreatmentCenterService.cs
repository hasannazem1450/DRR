using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.CommandDb.Repository.TreatmentCentres;
using DRR.Domain.BaseInfo;
using DRR.Domain.Customer;
using DRR.Domain.Reserv;
using DRR.Domain.TreatmentCenters;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.TreatmentCenter
{
    public class DoctorTreatmentCenterService : IDoctorTreatmentCenterService
    {
        private readonly IDoctorTreatmentCenterRepository _doctorTreatmentCenterRepository;
        public DoctorTreatmentCenterService(IDoctorTreatmentCenterRepository doctorTreatmentCenterRepository)
        {
            _doctorTreatmentCenterRepository = doctorTreatmentCenterRepository;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterByProvinceName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(x => x.Office.City.Province.Name.Contains(name)).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterByCityName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(x => x.Office.City.Name.Contains(name)).ToList();

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
            var result = dtc.Where(x => x.Clinic.ClinicType.Type.Contains(name)).ToList();

            return result;
        }
        public async Task<List<DoctorTreatmentCenterDto>> FilterByOfficeTypeName(List<DoctorTreatmentCenterDto> dtc, string name)
        {
            var result = dtc.Where(x => x.Office.OfficeType.Type.Contains(name)).ToList();

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
            var result = doctorTreatmentCenters.Select(s => ConvertToDto(s).Result).ToList();

            return result;
        }
        public async Task<DoctorTreatmentCenterDto> ConvertToDto(DoctorTreatmentCenter doctorTreatmentCenter)
        {
            string nearestdate = "";
            string nearesttime = "";
            string price = "";
            int intdatetoday = DatetimeExtension.DateToNumber(DateTime.Now.ToPersianString());
            if (doctorTreatmentCenter.Reservations.Where(x => x.ReservationDate >= intdatetoday).Count() > 0)
            {
                nearestdate = DatetimeExtension.NumberToDate(doctorTreatmentCenter.Reservations.Where(x => x.ReservationDate >= intdatetoday).OrderBy(x => x.ReservationDate).First().ReservationDate);
                nearestdate = nearestdate.ToGregorianDateTime()?.ToPersianDateStringFull();
                if (doctorTreatmentCenter.Reservations.Where(x => x.ReservationDate >= intdatetoday).OrderBy(x => x.ReservationDate).First().Turns.Where(x => x.IsFree == true).Count() > 0)
                {
                    nearesttime = doctorTreatmentCenter.Reservations.Where(x => x.ReservationDate >= intdatetoday).OrderBy(x => x.ReservationDate).First().Turns.Where(x => x.IsFree == true).First().Stime;

                }
                if (doctorTreatmentCenter.Reservations.Where(x => x.ReservationDate >= intdatetoday).OrderBy(x => x.ReservationDate).Count() > 0)
                    price = doctorTreatmentCenter.Reservations.Where(x => x.ReservationDate >= intdatetoday).OrderBy(x => x.ReservationDate).First().VisitCost.Price.ToString();

            }


            var result = new DoctorTreatmentCenterDto
            {
                Id = doctorTreatmentCenter.Id,
                DoctorId = doctorTreatmentCenter.DoctorId,
                ClinicId = doctorTreatmentCenter.ClinicId,
                OfficeId = doctorTreatmentCenter.OfficeId,
                Desc = doctorTreatmentCenter.Desc,
                DoctorName = doctorTreatmentCenter.Doctor.DoctorName + " " + doctorTreatmentCenter.Doctor.DoctorFamily,
                ClinicName = doctorTreatmentCenter.Clinic?.Name,
                OfficeName = doctorTreatmentCenter.Office?.Name,
                Doctor = doctorTreatmentCenter.Doctor,
                Clinic = doctorTreatmentCenter.Clinic ?? null,
                Office = doctorTreatmentCenter.Office ?? null,
                NearestDate = nearestdate,
                NearestTime = nearesttime,
                Price = price,
            };

            return result;
        }

        public async Task<DoctorTreatmentCenterPackedDto> ConvertToPackedDto(DoctorTreatmentCenter doctorTreatmentCenter)
        {

            var dtcr = _doctorTreatmentCenterRepository.ReadDoctorTreatmentCenterCountOfDoctorsAndSpecialistsByGuId(doctorTreatmentCenter.ClinicId ?? doctorTreatmentCenter.OfficeId ?? new Guid());
            //dtcr.Result.Select(d => d.DoctorId).Distinct().Count();
            //dtcr.Result.Select(d => d.Doctor.SpecialistId).Distinct().Count(); 
            var result = new DoctorTreatmentCenterPackedDto
            {
                Id = doctorTreatmentCenter.Id,
                ClinicId = doctorTreatmentCenter.ClinicId,
                OfficeId = doctorTreatmentCenter.OfficeId,
                Desc = doctorTreatmentCenter.Desc,
                Name = doctorTreatmentCenter.Clinic?.Name + doctorTreatmentCenter.Office?.Name,
                Address = doctorTreatmentCenter.Clinic?.Address + doctorTreatmentCenter.Office?.Address,
                DoctorsCount = dtcr.Result.Select(d => d.DoctorId).Distinct().Count(),
                SpecialistCount = dtcr.Result.Select(d => d.Doctor.SpecialistId).Distinct().Count()

            };

            return result;
        }

        public async Task<DoctorTreatmentCenterPackedDto4FirstPage> ConvertToDoctorTreatmentCenterPackedDto4FirstPage(DoctorTreatmentCenter doctorTreatmentCenter)
        {
            if (doctorTreatmentCenter.ClinicId != null)
            {
                var dtcr = _doctorTreatmentCenterRepository.ReadDoctorTreatmentCenterCountOfDoctorsAndSpecialistsByGuId(doctorTreatmentCenter.ClinicId ?? doctorTreatmentCenter.OfficeId ?? new Guid());
                //dtcr.Result.Select(d => d.DoctorId).Distinct().Count();
                //dtcr.Result.Select(d => d.Doctor.SpecialistId).Distinct().Count(); 
                var result = new DoctorTreatmentCenterPackedDto4FirstPage
                {
                    Id = doctorTreatmentCenter.Id,
                    ClinicId = doctorTreatmentCenter.ClinicId,
                    Desc = doctorTreatmentCenter.Desc,
                    Name = doctorTreatmentCenter.Clinic?.Name + doctorTreatmentCenter.Office?.Name,
                    Address = doctorTreatmentCenter.Clinic?.Address + doctorTreatmentCenter.Office?.Address,
                    DoctorsCount = dtcr.Result.Select(d => d.DoctorId).Distinct().Count(),
                    SpecialistCount = dtcr.Result.Select(d => d.Doctor.SpecialistId).Distinct().Count()

                };
                return result;
            }
            else
            {
                return null;
            }
                
        }

        public async Task<DoctorOfficePackedDto4FirstPage> ConvertToDoctorOfficePackedDto4FirstPage(DoctorTreatmentCenter doctorTreatmentCenter)
        {
            if (doctorTreatmentCenter.OfficeId != null)
            {
                var dtcr = _doctorTreatmentCenterRepository.ReadDoctorTreatmentCenterCountOfDoctorsAndSpecialistsByGuId(doctorTreatmentCenter.ClinicId ?? doctorTreatmentCenter.OfficeId ?? new Guid());

                var result = new DoctorOfficePackedDto4FirstPage
                {
                    Id = doctorTreatmentCenter.Id,
                    OfficeId = doctorTreatmentCenter.Office.Id,
                    Desc = doctorTreatmentCenter.Desc,
                    Name = doctorTreatmentCenter.Office.Name + doctorTreatmentCenter.Office?.Name,
                    Address = doctorTreatmentCenter.Office.Address + doctorTreatmentCenter.Office?.Address,
                    DoctorName = dtcr.Result.Select(d => d.Doctor.DoctorName).Distinct().FirstOrDefault(),
                    SpecialistName = dtcr.Result.Select(d => d.Doctor.Specialist.Name).Distinct().FirstOrDefault()

                };

                return result;
            }
            else
                return null;
        }

        public async Task<List<DoctorTreatmentCenterPackedDto>> ConvertToPackedDto(List<DoctorTreatmentCenter> doctorTreatmentCenters)
        {
            var result = doctorTreatmentCenters.Select(s => ConvertToPackedDto(s).Result).ToList();

            return result;
        }

        public async Task<List<DoctorTreatmentCenterPackedDto4FirstPage>> ConvertToDoctorTreatmentCenterPackedDto4FirstPage(List<DoctorTreatmentCenter> doctorTreatmentCenters)
        {
            var result = doctorTreatmentCenters.Select(s => ConvertToDoctorTreatmentCenterPackedDto4FirstPage(s).Result).ToList();

            return result;
        }

        public async Task<List<DoctorOfficePackedDto4FirstPage>> ConvertToDoctorOfficePackedDto4FirstPage(List<DoctorTreatmentCenter> doctorTreatmentCenters)
        {
            var result = doctorTreatmentCenters.Select(s => ConvertToDoctorOfficePackedDto4FirstPage(s).Result).ToList();

            return result;
        }

        public async Task<DoctorTreatmentCenterSSRDto> ConvertToSSRDto(List<DoctorTreatmentCenter> doctorTreatmentCenters)
        {
            var doctorTreatmentCenter = doctorTreatmentCenters.First();

            var result = new DoctorTreatmentCenterSSRDto
            {
                Id = doctorTreatmentCenter.Id,
                CenterId = doctorTreatmentCenter.Clinic == null ? doctorTreatmentCenter.Office.Id : doctorTreatmentCenter.Clinic.Id,
                CenterName = doctorTreatmentCenter.Clinic?.Name + doctorTreatmentCenter.Office?.Name,
                CenterAddress = doctorTreatmentCenter.Clinic?.Address + doctorTreatmentCenter.Office?.Address,
                CenterLat = doctorTreatmentCenter.Clinic == null ? doctorTreatmentCenter.Office.Geolat : doctorTreatmentCenter.Clinic.Geolat,
                CenterLon = doctorTreatmentCenter.Clinic == null ? doctorTreatmentCenter.Office.Geolon : doctorTreatmentCenter.Clinic.Geolon,
                Doctors = doctorTreatmentCenters.Select(d => d.Doctor).Distinct().ToList(),
                Specialists = doctorTreatmentCenters.Select(d => d.Doctor.Specialist).Distinct().ToList(),
                DoctorInsurances = null,

            };

            return result;
        }

        //public async Task<List<DoctorTreatmentCenterSSRDto>> ConvertToSSRDto(List<DoctorTreatmentCenter> doctorTreatmentCenters)
        //{
        //    var result = doctorTreatmentCenters.Select(s => ConvertToSSRDto(s).Result).ToList();

        //    return result;
        //}
    }
}