using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.TreatmentCenters
{
    public class UpdateDoctorTreatmentCenterCommand : Command
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Guid? ClinicId { get; set; }
        public Guid? OfficeId { get; set; }
        public string Desc { get; set; }
        public int CityId { get; set; }
    }

    public class UpdateDoctorTreatmentCenterCommandResponse : CommandResponse
    {
    }
}
