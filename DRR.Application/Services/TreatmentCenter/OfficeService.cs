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
    public class OfficeService : IOfficeService
    {
        public async Task<List<OfficeDto>> ConvertToDto(List<Office> Offices)
        {
            var result = Offices.Select(s => new OfficeDto
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Geolon = s.Geolon,
                Geolat = s.Geolat,
                CityName = s.City.Name,
                Phone = s.Phone,
                PostalCode = s.PostalCode,
                OfficeTypeName = s.OfficeType.Type
            }).ToList();

            return result;
        }

        public async Task<OfficeDto> ConvertToDto(Office Office)
        {
            var result = new OfficeDto
            {
                Id = Office.Id,
                Name = Office.Name,
                Address = Office.Address,
                Geolon = Office.Geolon,
                Geolat = Office.Geolat,
                CityName = Office.City.Name,
                Phone = Office.Phone,
                PostalCode = Office.PostalCode,
                OfficeTypeName = Office.OfficeType.Type
            };

            return result;
        }


        public async Task<List<OfficeDto>> FilterByName(List<OfficeDto> Offices, string name)
        {
            var result = Offices.Where(w => w.Name.Contains(name)).ToList();

            return result;
        }

        public async Task<List<OfficeDto>> FilterByProvinceOrCity(List<OfficeDto> Offices, string pcname)
        {
            var result = Offices.Where(w => w.CityName == pcname || w.City.Province.Name == pcname).ToList();

            return result;
        }

       
    }
}