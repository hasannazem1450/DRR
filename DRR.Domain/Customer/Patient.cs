﻿using DRR.Domain.Profile;
using DRR.Domain.BaseInfo;
using DRR.Domain.Reservations;
using DRR.Domain.Comments;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Customer
{
    public class Patient : Entity<int>
    {
        public Patient(string patientName, string patientFamily, string nationalId, int birthNumber, string birthDate, int cityId, int? glId, string patientPhone, string necessaryPhone, string? email, bool gender)
        {
            PatientName = patientName;
            PatientFamily = patientFamily;
            NationalId = nationalId;
            BirthNumber = birthNumber;
            BirthDate = birthDate;
            CityId = cityId;
            GlId = glId;
            PatientPhone = patientPhone;
            NecessaryPhone = necessaryPhone;
            Email = email;
            Gender = gender;
        }

        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientFamily { get; set; }
        public string NationalId { get; set; }
        public int BirthNumber { get; set; }
        public string BirthDate { get; set; }
        public int CityId { get; set; }
        public int? GlId { get; set; }
        public string PatientPhone { get; set; }
        public string NecessaryPhone { get; set; }
        public string? Email { get; set; }
        public bool Gender { get; set; }



        public City City { get; set; }
        


        public ICollection<SmeProfile> SmeProfiles { get; set; }
        public ICollection<PatientReservation> PatientReservations { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PatientFavorite> PatientFavorite { get; set; }






    }

}
