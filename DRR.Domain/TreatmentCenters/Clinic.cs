using DRR.Domain.BaseInfo;
using DRR.Domain.Profile;
using DRR.Domain.Reservations;
using DRR.Domain.Customer;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Domain.TreatmentCenters
{

    public class Clinic : Entity<int>
    {
        public Clinic(string name, string address, int glId, string phone, int cityId, string siamCode, string desc, int clinicTypeId)
        {
            Name = name;
            Address = address;
            GLId = glId;
            Phone = phone;
            CityId = cityId;
            SiamCode = siamCode;
            Desc = desc;
            ClinicTypeId = clinicTypeId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int GLId { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string SiamCode { get; set; }
        public string Desc { get; set; }
        public int ClinicTypeId { get; set; }


        public City City { get; set; }
        public ClinicType ClinicType { get; set; }


        public ICollection<SmeProfile> SmeProfiles { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

    }

}