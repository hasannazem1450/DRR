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
    public class UpdatePositionCommandHandler : CommandHandler<UpdatePositionCommand, UpdatePositionCommandResponse>
    {

        private readonly IPositionRepository _positionRepository;

        public UpdatePositionCommandHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public override async Task<UpdatePositionCommandResponse> Executor(UpdatePositionCommand command)
        {
            var position = new Position(command.Name)
            {
                Id = command.Id,
            };

            await _positionRepository.Update(position);

            return new UpdatePositionCommandResponse();
        }
    }
}
