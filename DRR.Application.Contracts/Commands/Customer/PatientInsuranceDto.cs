using DRR.Domain.Customer;
using DRR.Domain.Insurances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class PatientInsuranceDto
    {
        public int PatientId { get; set; }
        public int InsuranceId { get; set; }
        public string Expiredate { get; set; }

        public Insurance Insurance { get; set; }
        public Patient Patient { get; set; }
    }
}
