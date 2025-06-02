using DRR.Domain.Insurances;
using DRR.Domain.Profile;
using DRR.Domain.Reserv;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class DoctorBoxDto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorFamily { get; set; }
        public string specialist { get; set; }
        public string DocExperiance { get; set; }
        public string DocInstaLink { get; set; }
        public string Desc { get; set; }
        public string UniqueSSR { get; set; }
        public Reservation reservations { get; set; }
        public Domain.Comments.Comment comments { get; set; }
        public DoctorInsurance DoctorInsurances { get; set; }
        public List<DoctorTreatmentCenter> DoctorTreatmentCenterList { get; set; }
    }
}
