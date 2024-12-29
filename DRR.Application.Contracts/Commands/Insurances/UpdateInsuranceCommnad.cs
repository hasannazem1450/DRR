using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Application.Contracts.Commands.Insurances
{
    public class UpdateInsuranceCommnad : Command
    {
        public int InsuranceTypeId { get; set; }
        public string Name { get; set; }

        public InsuranceType InsuranceType { get; set; }
    }
    public class UpdateInsuranceCommnadResponse : CommandResponse
    {
    }
}
