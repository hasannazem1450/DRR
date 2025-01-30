using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class UpdateClinicTypeCommand : Command
    {
        public int Id { get; set; }
        public string Type { get; set; }
      
    }

    public class UpdateClinicTypeCommandResponse : CommandResponse
    {
    }
}
