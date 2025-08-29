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
    internal class CreateVisitTypeCommandHandler : CommandHandler<CreateVisitTypeCommand, CreateVisitTypeCommandResponse>
    {
        private readonly IVisitTypeRepository _visitTypeRepository;


        public CreateVisitTypeCommandHandler(IVisitTypeRepository visitTypeRepository)
        {
            _visitTypeRepository = visitTypeRepository;
        }

        public override async Task<CreateVisitTypeCommandResponse> Executor(CreateVisitTypeCommand command)
        {

            var vt = new VisitType(command.VisitTypeName);

            await _visitTypeRepository.Create(vt);

            return new CreateVisitTypeCommandResponse();
        }
    }
}