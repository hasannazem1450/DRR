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
        private readonly ITurnRepository _turnRepository;


        public CreatePatientReservationCommandHandler(IPatientReservationRepository prRepository, ITurnRepository turnRepository)
        {
            _prRepository = prRepository;
            _turnRepository = turnRepository;
        }

        public override async Task<CreatePatientReservationCommandResponse> Executor(CreatePatientReservationCommand command)
        {
            var pr = new PatientReservation(command.PatientId, command.ReservationId, command.DiscountCodeId , command.TurnId);


            await _prRepository.Create(pr);
            var turn = await _turnRepository.ReadTurnById(command.TurnId);
            //turn.IsFree = false;
            await _turnRepository.UpdateGet(turn);

            return new CreatePatientReservationCommandResponse();
        }
    }
}
