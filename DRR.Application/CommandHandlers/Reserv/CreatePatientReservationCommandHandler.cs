using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Domain.Customer;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Reserv
{
    public class CreatePatientReservationCommandHandler : CommandHandler<CreatePatientReservationCommand, CreatePatientReservationCommandResponse>
    {
        private readonly IPatientReservationRepository _prRepository;


        public CreatePatientReservationCommandHandler(IPatientReservationRepository prRepository)
        {
            _prRepository = prRepository;
        }

        public override async Task<CreatePatientReservationCommandResponse> Executor(CreatePatientReservationCommand command)
        {
            var pr = new PatientReservation(command.PatientId, command.ReservationId, command.DiscountCodeId , command.TurnId);


            await _prRepository.Create(pr);

            return new CreatePatientReservationCommandResponse();
        }
    }
}
