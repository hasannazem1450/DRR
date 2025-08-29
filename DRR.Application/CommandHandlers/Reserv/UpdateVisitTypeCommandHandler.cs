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
    public class UpdateVisitTypeCommandHandler : CommandHandler<UpdateVisitTypeCommand, UpdateVisitTypeCommandResponse>
    {
        private readonly IVisitTypeRepository _visitTypeRepository;


        public UpdateVisitTypeCommandHandler(IVisitTypeRepository visitTypeRepository)
        {
            _visitTypeRepository = visitTypeRepository;
        }

        public override async Task<UpdateVisitTypeCommandResponse> Executor(UpdateVisitTypeCommand command)
        {
            var visitType = await _visitTypeRepository.ReadVisitTypeById(command.Id);
            visitType.Update(command.VisitTypeName);
            await _visitTypeRepository.Update(visitType);

            return new UpdateVisitTypeCommandResponse();

        }
    }
}