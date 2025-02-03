using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Customer;
using DRR.Domain.TreatmentCenters;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class DoctorTreatmentCenterDto
    {
        public int DoctorId { get; set; }
        public Guid? ClinicId { get; set; }
        public Guid? OfficeId { get; set; }
        public string Desc { get; set; }
        public string DoctorName { get; set; }
        public string ClinicName { get; set; }
        public string OfficeName { get; set; }
        public Doctor Doctor { get; set; }
        public Clinic Clinic { get; set; }
        public Office Office { get; set; }  

    }
}
