using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Customer;
using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Application.Contracts.Commands.Insurances
{
    public class CreatePatientInsuranceCommnad : Command
    {
        public int PatientId { get; set; }
        public int InsuranceId { get; set; }
        public string Expiredate { get; set; }

        public Insurance Insurance { get; set; }
        public Patient Patient { get; set; }
    }
    public class CreatePatientInsuranceCommnadResponse : CommandResponse
    {
    }
}
