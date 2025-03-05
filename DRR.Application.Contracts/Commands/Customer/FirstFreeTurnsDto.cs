using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class FirstFreeTurnsDto
    {
        public int TurnId { get; set; }
        public string TreatmentCenterName { get; set; }
        public string ReservationDate { get; set; }
        public string ReservationDateFull { get; set; }
        public string ReservationTime { get; set; }
        public string TreatmentCenterAddress { get; set; }
        public string ReservationType { get; set; }
        public string VisitCostPrice { get; set; }
    }
}
