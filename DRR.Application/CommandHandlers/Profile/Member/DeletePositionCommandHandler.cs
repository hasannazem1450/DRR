using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.Position;
using DRR.Application.Contracts.Repository.Profile.Member;
using DRR.Domain.Profile.Member;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Profile.Member
{

    public class DeletePositionCommandHandler : CommandHandler<DeletePositionCommand, DeletePositionCommandResponse>
    {

        private readonly IPositionRepository _positionRepository;

        public DeletePositionCommandHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public override async Task<DeletePositionCommandResponse> Executor(DeletePositionCommand command)
        {

            await _positionRepository.Delete(command.Id);

            return new DeletePositionCommandResponse();
        }
    }
}
