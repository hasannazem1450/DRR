using DRR.Domain.Customer;
using DRR.Domain.Insurances;
using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class DoctorInsuranceDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int InsuranceId { get; set; }
        public string ContractSituation { get; set; }
        public decimal InsurancePercent { get; set; }
        public int VisitCostId { get; set; }
        public bool IsActive { get; set; }
        public string DoctorName { get; set; }
        public string InsuranceName { get; set; }
    }
}
