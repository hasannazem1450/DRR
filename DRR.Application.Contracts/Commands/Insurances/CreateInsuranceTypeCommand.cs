using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Application.Contracts.Commands.Insurances
{
    public class CreateInsuranceTypeCommand : Command
    {
        public string Type { get; set; }
    }
    public class CreateInsuranceTypeCommandResponse : CommandResponse
    {
    }
}
