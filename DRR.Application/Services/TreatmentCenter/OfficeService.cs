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
        

        public async Task<OfficeDto> ConvertToDto(Office Office, int dosctorCount)
        {
            var result = new OfficeDto
            {
                Id = Office.Id,
                Name = Office.Name,
                Address = Office.Address,
                Geolon = Office.Geolon,
                Geolat = Office.Geolat,
                ProvinceId = Office.City.ProvinceId,
                CityId = Office.City.Id,
                CityName = Office.City.Name,
                Phone = Office.Phone,
                PostalCode = Office.PostalCode,
                OfficeTypeName = Office.OfficeType.Type,
                OfficeTypeId = Office.OfficeType.Id,
                DoctorsCount = dosctorCount
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