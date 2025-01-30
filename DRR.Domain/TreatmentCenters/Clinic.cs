using DRR.Domain.BaseInfo;
using DRR.Domain.Profile;
using DRR.Domain.Reserv;
using DRR.Domain.Customer;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;
using System.Drawing;
using System;


namespace DRR.Domain.TreatmentCenters
{

    public class Clinic : Entity<Guid>
    {
        public Clinic(string name, string address, double geolon, double geolat, string phone, int cityId, string siamCode, string desc, int clinicTypeId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Geolon = geolon;
            Geolat = geolat;
            Phone = phone;
            CityId = cityId;
            SiamCode = siamCode;
            Desc = desc;
            ClinicTypeId = clinicTypeId;
        }
        public void Update(string name, string address, double geolon, double geolat, string phone, int cityId, string siamCode, string desc, int clinicTypeId)
        {
            Name = name;
            Address = address;
            Geolon = geolon;
            Geolat = geolat;
            Phone = phone;
            CityId = cityId;
            SiamCode = siamCode;
            Desc = desc;
            ClinicTypeId = clinicTypeId;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public double Geolon { get; set; }
        public double Geolat { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string SiamCode { get; set; }
        public string Desc { get; set; }
        public int ClinicTypeId { get; set; }


        public City City { get; set; }
        public ClinicType ClinicType { get; set; }



    }

}