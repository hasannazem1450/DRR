using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;
using DRR.Domain.Reserv;
using System;

namespace DRR.Domain.TreatmentCenters
{
    public class DoctorTreatmentCenter : Entity<int>
    {
        public DoctorTreatmentCenter(int doctorId, Guid? clinicId, Guid? officeId, string desc)
        {
            DoctorId = doctorId;
            ClinicId = clinicId;
            OfficeId = officeId;
            Desc = desc;
        }
        public void Update(int doctorId, Guid? clinicId, Guid? officeId, string desc)
        {
            DoctorId = doctorId;
            ClinicId = clinicId;
            OfficeId = officeId;
            Desc = desc;
        }

        public int DoctorId { get; set; }
        public Guid? ClinicId { get; set; }
        public Guid? OfficeId { get; set; }
        public string Desc { get; set; }


        public Doctor Doctor { get; set; }
        public Office Office { get; set; }
        public Clinic Clinic { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
       



    }

}
