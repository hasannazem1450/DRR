﻿using DRR.Domain.BaseInfo;
using DRR.Domain.Profile;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace DRR.Domain.TreatmentCenters
{
    public class Office : Entity<Guid>
    {
        public Office(string name, string address, double geolon , double geolat, string phone, int cityId, string postalCode, int officeTypeId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Geolon = geolon;
            Geolat = geolat;
            Phone = phone;
            CityId = cityId;
            PostalCode = postalCode;
            OfficeTypeId = officeTypeId;

        }
        public void Update(string name, string address, double geolon, double geolat, string phone, int cityId, string postalCode, int officeTypeId,City city , OfficeType officeType)
        {
            Name = name;
            Address = address;
            Geolon = geolon;
            Geolat = geolat;
            Phone = phone;
            CityId = cityId;
            PostalCode = postalCode;
            OfficeTypeId = officeTypeId;
            City = city;
            OfficeType = officeType;
            
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public double Geolon { get; set; }
        public double Geolat { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public int OfficeTypeId { get; set; }



        public City City { get; set; }
        public OfficeType OfficeType { get; set; }

        
    }

}
