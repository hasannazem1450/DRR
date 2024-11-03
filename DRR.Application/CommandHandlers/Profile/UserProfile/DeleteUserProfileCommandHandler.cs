using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Profile.UserProfile
{
    
    public class DeleteUserProfileCommandHandler : CommandHandler<DeleteUserProfileCommand, DeleteUserProfileCommandResponse>
    {

        private readonly IUserProfileRepository _userProfileRepository;

        public DeleteUserProfileCommandHandler(IUserProfileRepository smeMemberRepository)
        {
            _userProfileRepository = smeMemberRepository;
        }

        public override async Task<DeleteUserProfileCommandResponse> Executor(DeleteUserProfileCommand command)
        {

            await _userProfileRepository.Delete(command.Id);

            return new DeleteUserProfileCommandResponse();
        }
    }
}
