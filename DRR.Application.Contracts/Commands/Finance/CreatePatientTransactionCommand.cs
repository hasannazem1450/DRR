using DRR.Domain.Customer;
using DRR.Domain.Finance;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Finance
{
    public class CreatePatientTransactionCommand : Command
    {
        public int PatientId { get; set; }
        public string TransactionDate { get; set; }
        public int PaymentNumber { get; set; }
        public int PatientReservationId { get; set; }
    }

    public class CreatePatientTransactionCommandResponse : CommandResponse
    {
        public PatientTransaction PatientTransaction { get; set; }
    }
}
