﻿using DRR.Domain.Customer;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class DoctorTreatmentCenterPackedDto
    {
        public int Id { get; set; }
        public Guid? ClinicId { get; set; }
        public Guid? OfficeId { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DoctorsCount { get; set; }
        public int SpecialistCount { get; set; }
    }
}
