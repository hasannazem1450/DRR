﻿using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.TreatmentCenters
{
    public class DoctorTreatmentCenter : Entity<int>
    {
        public DoctorTreatmentCenter(int doctorId, int? clinicId, int? officeId, string desc)
        {
            DoctorId = doctorId;
            ClinicId = clinicId;
            OfficeId = officeId;
            Desc = desc;
        }

        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int? ClinicId { get; set; }
        public int? OfficeId { get; set; }
        public string Desc { get; set; }


        public Doctor Doctor { get; set; }
        public Office Office { get; set; }
        public Clinic Clinic { get; set; }

        public ICollection<SmeProfile> SmeProfiles { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

    }

}