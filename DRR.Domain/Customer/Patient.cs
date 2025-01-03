using DRR.Domain.Profile;
using DRR.Domain.BaseInfo;
using DRR.Domain.Reserv;
using DRR.Domain.Comments;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;
using DRR.Domain.Event;
using System.Drawing;

namespace DRR.Domain.Customer
{
    public class Patient : Entity<int>
    {
        public Patient(string patientName, string patientFamily, string nationalId, int birthNumber, string birthDate, int cityId, double geolon, double geolat, string patientPhone, string necessaryPhone, string? email, bool gender, int smeProfileId)
        {
            PatientName = patientName;
            PatientFamily = patientFamily;
            NationalId = nationalId;
            BirthNumber = birthNumber;
            BirthDate = birthDate;
            CityId = cityId;
            Geolon = geolon;
            Geolat = geolat;
            PatientPhone = patientPhone;
            NecessaryPhone = necessaryPhone;
            Email = email;
            Gender = gender;
            SmeProfileId = smeProfileId;
        }

        public void Update(string patientName, string patientFamily, string nationalId, int birthNumber, string birthDate, int cityId, double geolon, double geolat, string patientPhone, string necessaryPhone, string? email, bool gender, int smeProfileId)
        {
            PatientName = patientName;
            PatientFamily = patientFamily;
            NationalId = nationalId;
            BirthNumber = birthNumber;
            BirthDate = birthDate;
            CityId = cityId;
            Geolon = geolon;
            Geolat = geolat;
            PatientPhone = patientPhone;
            NecessaryPhone = necessaryPhone;
            Email = email;
            Gender = gender;
            SmeProfileId = smeProfileId;
        }

        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
        public string PatientName { get; set; }
        public string PatientFamily { get; set; }
        public string NationalId { get; set; }
        public int BirthNumber { get; set; }
        public string BirthDate { get; set; }
        public int CityId { get; set; }
        public double Geolon { get; set; }
        public double Geolat { get; set; }
        public string PatientPhone { get; set; }
        public string NecessaryPhone { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public int SmeProfileId { get; set; }



        public City City { get; set; }
        public SmeProfile SmeProfile { get; set; }

        public ICollection<PatientFavorite> PatientFavorites { get; protected set; }
        public ICollection<PatientReservation> PatientReservations { get; protected set; }
    }

}
