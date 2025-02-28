using DRR.Domain.Customer;
using DRR.Domain.Finance;
using DRR.Domain.Reserv;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Reserv
{
    public class PatientReservationDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ReservationId { get; set; }
        public int TurnId { get; set; }
        public int? DiscountCodeId { get; set; }

        public Reservation Reservation { get; set; }
        public Patient Patient { get; set; }
        public Turn Turn { get; set; }
        public DiscountCode DiscountCode { get; set; }
        public DoctorTreatmentCenter DoctorTreatmentCenter { get; set; }
        public Doctor Doctor { get; set; }
    }
}
