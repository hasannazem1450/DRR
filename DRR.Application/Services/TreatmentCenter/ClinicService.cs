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
        public async Task<List<ClinicDto>> ConvertToDto(List<Clinic> Clinics)
        {
            var result = Clinics.Select(s => new ClinicDto
            {
                Id = s.Id,
                ClinicName = s.Name,
                Address = s.Address,
                Geolon = s.Geolon,
                Geolat = s.Geolat,
                Phone = s.Phone,
                CityName = s.City.Name,
                ProvinceName = s.City.Province.Name,
                SiamCode = s.SiamCode,
                Desc = s.Desc,
                ClinicTypeName = s.ClinicType.Type
            }).ToList();

            return result;
        }

        public async Task<ClinicDto> ConvertToDto(Clinic Clinic)
        {
            var result = new ClinicDto
            {
                Id = Clinic.Id,
                ClinicName = Clinic.Name,
                Address = Clinic.Address,
                Geolon = Clinic.Geolon,
                Geolat = Clinic.Geolat,
                Phone = Clinic.Phone,
                CityName = Clinic.City.Name,
                ProvinceName = Clinic.City.Province.Name,
                SiamCode = Clinic.SiamCode,
                Desc = Clinic.Desc,
                ClinicTypeName = Clinic.ClinicType.Type
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
            var result = Clinics.Where(w => w.ProvinceName == pcname || w.CityName == pcname).ToList();

            return result;
        }


    }
}