using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.Position;
using DRR.Application.Contracts.Repository.Profile.Member;
using DRR.Domain.Identity.Exceptions;
using DRR.Domain.Profile.Member;
using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace DRR.Application.CommandHandlers.Profile.Member
{

    public class CreatePositionCommandHandler : CommandHandler<CreatePositionCommand, CreatePositionCommandResponse>
    {

        private readonly IPositionRepository _positionRepository;

        public CreatePositionCommandHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public override async Task<CreatePositionCommandResponse> Executor(CreatePositionCommand command)
        {
            var position = new Position(command.Name);

            await _positionRepository.Create(position);

            return new CreatePositionCommandResponse();
        }
    }
}
