using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Reserv
{
    public class CreatePatientReservationCommand : Command
    {
        public int PatientId { get; set; }
        public int ReservationId { get; set; }
        public int? DiscountCodeId { get; set; }
        public int TurnId { get; set; }
    }
    public class CreatePatientReservationCommandResponse : CommandResponse
    {
    }
}
