using DRR.Domain.Reserv;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Reserv
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string ReservationDate { get; set; }
        public int VisitTypeId { get; set; }
        public int DoctorTreatmentCenterId { get; set; }
        public int CancleTimeDuration { get; set; }
        public string ReservationTime { get; set; }
        public int VisitCostId { get; set; }
        public VisitType VisitType { get; set; }
        public DoctorTreatmentCenter DoctorTreatmentCenter { get; set; }
        public VisitCost VisitCost { get; set; }

    }
}
