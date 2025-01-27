using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class DeleteOfficeCommand : Command
    {
        public int Id { get; set; }
    }

    public class DeleteOfficeCommandResponse : CommandResponse
    {
    }
}