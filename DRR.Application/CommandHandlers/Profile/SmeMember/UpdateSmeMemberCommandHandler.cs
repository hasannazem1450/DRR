using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.SmeMember;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Profile.SmeMember
{
    public class UpdateSmeMemberCommandHandler : CommandHandler<UpdateSmeMemberCommand, UpdateSmeMemberCommandResponse>
    {

        private readonly ISmeMemberRepository _smeMemberRepository;

        public UpdateSmeMemberCommandHandler(ISmeMemberRepository smeMemberRepository)
        {
            _smeMemberRepository = smeMemberRepository;
        }

        public override async Task<UpdateSmeMemberCommandResponse> Executor(UpdateSmeMemberCommand command)
        {
            var smeMember = new Domain.Profile.SmeMember(command.Name, command.ProfilePhoto)
            {
                SmeProfileId = command.SmeProfileId,
                PositionId = command.PositionId,
            };

            await _smeMemberRepository.Update(smeMember);

            return new UpdateSmeMemberCommandResponse();
        }
    }
}
