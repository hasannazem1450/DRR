using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using DRR.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Profile.FollowProfile
{
    public class UpdateFollowProfileCommandHandler : CommandHandler<UpdateFollowProfileCommand, UpdateFollowProfileCommandResponse>
    {
        private readonly IFollowProfileRepository _followProfileRepository;

        public UpdateFollowProfileCommandHandler(IFollowProfileRepository followProfileRepository)
        {
            _followProfileRepository = followProfileRepository;
        }

        public override async Task<UpdateFollowProfileCommandResponse> Executor(UpdateFollowProfileCommand command)
        {
            var followProfile = new Domain.Profile.Follow.FollowProfile();

            await _followProfileRepository.Update(followProfile);

            return new UpdateFollowProfileCommandResponse();
        }
    }
}
