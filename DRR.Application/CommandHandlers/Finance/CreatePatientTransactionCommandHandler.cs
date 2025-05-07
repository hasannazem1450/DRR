using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Finance;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Finance;
using DRR.Domain.Customer;
using DRR.Domain.Finance;
using DRR.Framework.Contracts.Abstracts;
using DRR.Utilities.Extensions;

namespace DRR.Application.CommandHandlers.Finance
{
    public class CreatePatientTransactionCommandHandler : CommandHandler<CreatePatientTransactionCommand, CreatePatientTransactionCommandResponse>
    {
        private readonly IPatientTransactionRepository _patientTransactionRepository;


        public CreatePatientTransactionCommandHandler(IPatientTransactionRepository patientTransactionRepository)
        {
            _patientTransactionRepository = patientTransactionRepository;
        }

        public override async Task<CreatePatientTransactionCommandResponse> Executor(CreatePatientTransactionCommand command)
        {
            var patientTransaction = new PatientTransaction(command.PatientId, DateTime.Now.ToPersianString(), command.PaymentNumber, command.PatientReservationId);


            await _patientTransactionRepository.Create(patientTransaction);

            return new CreatePatientTransactionCommandResponse() {PatientTransaction = patientTransaction };
        }
    }
}
