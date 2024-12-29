using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Insurances
{
    public class CreateInsuranceCommand : Command
    {
        public int InsuranceTypeId { get; set; }
        public string Name { get; set; }

        public InsuranceType InsuranceType { get; set; }
    }
    public class CreateInsuranceCommandResponse : CommandResponse
    {
    }
}
