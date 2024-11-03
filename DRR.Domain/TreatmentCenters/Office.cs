using DRR.Domain.BaseInfo;
using DRR.Domain.Profile;
using DRR.Domain.Reservations;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;


namespace DRR.Domain.TreatmentCenters
{
    public class Office : Entity<int>
    {
        public Office(string name, string address, int glId, string phone, int cityId, string postalCode, int officeTypeId)
        {
            Name = name;
            Address = address;
            GLId = glId;
            Phone = phone;
            CityId = cityId;
            PostalCode = postalCode;
            OfficeTypeId = officeTypeId;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int GLId { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public int OfficeTypeId { get; set; }



        public City City { get; set; }
        public OfficeType OfficeType { get; set; }


        public ICollection<SmeProfile> SmeProfiles { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        
    }

}
