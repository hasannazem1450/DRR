using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.CommandDb.Repository.Reserv;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Reserv
{
    public class UpdateVisitCostCommandHandler : CommandHandler<UpdateVisitCostCommand, UpdateVisitCostCommandResponse>
    {
        private readonly IVisitCostRepository _visitCostRepository;


        public UpdateVisitCostCommandHandler(IVisitCostRepository visitCostRepository)
        {
            _visitCostRepository = visitCostRepository;
        }

        public override async Task<UpdateVisitCostCommandResponse> Executor(UpdateVisitCostCommand command)
        {
            var visitCost = await _visitCostRepository.ReadVisitCostById(command.Id);
            visitCost.Update(command.DoctorId, command.Price, command.VisitTypeId);
            await _visitCostRepository.Update(visitCost);

            return new UpdateVisitCostCommandResponse();

        }
    }
}