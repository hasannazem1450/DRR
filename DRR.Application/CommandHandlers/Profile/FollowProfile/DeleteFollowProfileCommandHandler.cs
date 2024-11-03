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
    public class DeleteFollowProfileCommandHandler : CommandHandler<DeleteFollowProfileCommand, DeleteFollowProfileCommandResponse>
    {
        private readonly IFollowProfileRepository _followProfileRepository;

        public DeleteFollowProfileCommandHandler(IFollowProfileRepository followProfileRepository)
        {
            _followProfileRepository = followProfileRepository;
        }

        public override async Task<DeleteFollowProfileCommandResponse> Executor(DeleteFollowProfileCommand command)
        {

            await _followProfileRepository.Delete(command.Id);

            return new DeleteFollowProfileCommandResponse();
        }
    }
}
