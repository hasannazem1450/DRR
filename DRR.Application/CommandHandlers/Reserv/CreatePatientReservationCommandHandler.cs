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
            var pr = new PatientReservation(command.PatientId, command.DiscountCodeId , command.TurnId);


            
            var turn = await _turnRepository.ReadTurnById(command.TurnId);
            if (turn.IsFree == true)
            await _turnRepository.UpdateGet(turn);
            else
                throw new Exception ("این وقت گرفته شده");

            await _prRepository.Create(pr);

            return new CreatePatientReservationCommandResponse();
        }
    }
}
