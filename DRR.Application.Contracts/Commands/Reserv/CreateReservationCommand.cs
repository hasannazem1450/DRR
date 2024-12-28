using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Reserv
{
    public class CreateReservationCommand :Command
    {
        public string ReservationDate { get; set; }
        public int VisitTypeId { get; set; }
        public int DoctorTreatmentCenterId { get; set; }
        public int CancleTimeDuration { get; set; }
        public string ReservationTime { get; set; }
        public int VisitCostId { get; set; }


    }

    public class CreateReservationCommandResponse : CommandResponse
    {
    }
}
