using DRR.Domain.Customer;
using DRR.Domain.Insurances;
using DRR.Domain.Specialists;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class DoctorTreatmentCenterSSRDto
    {
        public int Id { get; set; }
        public List<Specialist> Specialists { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<DoctorInsurance> DoctorInsurances { get; set; }
        public Guid CenterId { get; set; }
        public string CenterName { get; set; }
        public string CenterAddress { get; set; }
        public double CenterLat { get; set; }
        public double CenterLon{ get; set; }
    }
}
