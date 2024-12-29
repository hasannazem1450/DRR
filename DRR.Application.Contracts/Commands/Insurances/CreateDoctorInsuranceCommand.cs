using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Customer;
using DRR.Domain.Insurances;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Application.Contracts.Commands.Insurances
{
    public class CreateDoctorInsuranceCommand : Command
    {
        public int DoctorId { get; set; }
        public int InsuranceId { get; set; }
        public string ContractSituation { get; set; }
        public decimal InsurancePercent { get; set; }
        public int VisitCostId { get; set; }
        public bool IsActive { get; set; }

        public Insurance Insurance { get; set; }
        public Doctor Doctor { get; set; }
        public VisitCost VisitCost { get; set; }
    }
    public class CreateDoctorInsuranceCommandResponse : CommandResponse
    {
    }
}
