using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Domain.Reserv;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Reserv
{
    internal class CreateVisitCostCommandHandler : CommandHandler<CreateVisitCostCommand, CreateVisitCostCommandResponse>
    {
        private readonly IVisitCostRepository _visitCostRepository;


        public CreateVisitCostCommandHandler(IVisitCostRepository visitCostRepository)
        {
            _visitCostRepository = visitCostRepository;
        }

        public override async Task<CreateVisitCostCommandResponse> Executor(CreateVisitCostCommand command)
        {

            var ev = new VisitCost(command.DoctorId, command.Price, command.VisitTypeId);

            await _visitCostRepository.Create(ev);

            return new CreateVisitCostCommandResponse();
        }
    }
}