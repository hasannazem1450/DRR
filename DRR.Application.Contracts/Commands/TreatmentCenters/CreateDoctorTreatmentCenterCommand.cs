using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class CreateDoctorTreatmentCenterCommand : Command
    {
        public int DoctorId { get; set; }
        public int? ClinicId { get; set; }
        public int? OfficeId { get; set; }
        public string Desc { get; set; }
    }

    public class CreateDoctorTreatmentCenterCommandResponse : CommandResponse
    {
    }
}