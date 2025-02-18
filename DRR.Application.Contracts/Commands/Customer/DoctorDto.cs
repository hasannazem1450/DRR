﻿using DRR.Domain.Insurances;
using DRR.Domain.Profile;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorFamily { get; set; }
        public string specialist { get; set; }
        public string DocExperiance { get; set; }
        public string DocInstaLink { get; set; }
        public string Desc { get; set; }
     
        public virtual SmeProfile SmeProfile { get; set; }
        public DoctorInsurance DoctorInsurance { get; set; }
        public DoctorTreatmentCenter DoctorTreatmentCenters { get; set; }
    }
}
