using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.Event.Exceptions;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Services.Event;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Common.Enums;

namespace DRR.Application.Services.TreatmentCenter
{
    public class ClinicService : IClinicService
    {
       

        public async Task<ClinicDto> ConvertToDto(Clinic clinic ,int doctorsCount)
        {
            var result = new ClinicDto
            {
                Id = clinic.Id,
                ClinicName = clinic.Name,
                Address = clinic.Address,
                Geolon = clinic.Geolon,
                Geolat = clinic.Geolat,
                Phone = clinic.Phone,
                ProvinceId = clinic.City.ProvinceId,
                CityId = clinic.City.Id,
                CityName = clinic.City.Name,
                SiamCode = clinic.SiamCode,
                Desc = clinic.Desc,
                ClinicTypeName = clinic.ClinicType.Type,
                ClinicTypeId = clinic.ClinicType.Id,
                DoctorsCount = doctorsCount
            };

            return result;
        }



        public async Task<List<ClinicDto>> FilterByName(List<ClinicDto> Clinics, string name)
        {
            var result = Clinics.Where(w => w.ClinicName.Contains(name)).ToList();

            return result;
        }

        public async Task<List<ClinicDto>> FilterByProvinceOrCity(List<ClinicDto> Clinics, string pcname)
        {
            var result = Clinics.Where(w => w.CityName == pcname).ToList();

            return result;
        }


    }
}