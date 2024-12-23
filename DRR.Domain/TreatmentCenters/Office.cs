using DRR.Domain.BaseInfo;
using DRR.Domain.Profile;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;
using System.Data.Entity.Spatial;


namespace DRR.Domain.TreatmentCenters
{
    public class Office : Entity<int>
    {
        public Office(string name, string address, DbGeography geoloc ,string phone, int cityId, string postalCode, int officeTypeId)
        {
            Name = name;
            Address = address;
            Geoloc = geoloc;
            Phone = phone;
            CityId = cityId;
            PostalCode = postalCode;
            OfficeTypeId = officeTypeId;

        }
        public void Update(string name, string address, DbGeography geoloc, string phone, int cityId, string postalCode, int officeTypeId)
        {
            Name = name;
            Address = address;
            Geoloc = geoloc;
            Phone = phone;
            CityId = cityId;
            PostalCode = postalCode;
            OfficeTypeId = officeTypeId;

        }

        public string Name { get; set; }
        public string Address { get; set; }
        public DbGeography Geoloc { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public int OfficeTypeId { get; set; }



        public City City { get; set; }
        public OfficeType OfficeType { get; set; }

        
    }

}
