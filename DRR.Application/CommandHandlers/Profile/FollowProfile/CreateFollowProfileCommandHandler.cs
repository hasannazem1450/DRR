using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Application.Contracts.Repository.Profile.IFollowProfileRepository;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Application.CommandHandlers.Profile.FollowProfile
{
    public class CreateFollowProfileCommandHandler : CommandHandler<CreateFollowProfileCommand, CreateFollowProfileCommandResponse>
    {

        private readonly IFollowProfileRepository _followProfileRepository;

        public CreateFollowProfileCommandHandler(IFollowProfileRepository followProfileRepository)
        {
            _followProfileRepository = followProfileRepository;
        }

        public override async Task<CreateFollowProfileCommandResponse> Executor(CreateFollowProfileCommand command)
        {
            var followProfile = new Domain.Profile.Follow.FollowProfile(command.FollowProfileId,command.MyProfileId,command.FollowProfileName,command.FollowProfileLogo) { };

            await _followProfileRepository.Create(followProfile);

            return new CreateFollowProfileCommandResponse();
        }
    }
}
