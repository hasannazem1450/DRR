using DRR.Application.Contracts.Commands.Profile.UserProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Profile.UserProfile
{
    public class CreateUserProfileCommandHandler : CommandHandler<CreateUserProfileCommand, CreateUserProfileCommandResponse>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public override async Task<CreateUserProfileCommandResponse> Executor(CreateUserProfileCommand command)
        {
            var userProfile = new Domain.Profile.UserProfile(command.UserId.ToString(), command.ProfileId)
            {
            };

            await _userProfileRepository.Create(userProfile);

            return new CreateUserProfileCommandResponse();
        }
    }
}
