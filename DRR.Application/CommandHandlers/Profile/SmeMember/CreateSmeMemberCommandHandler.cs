using DRR.Application.Contracts.Commands.Profile.SmeMember;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Profile.SmeMember
{
    public class CreateSmeMemberCommandHandler : CommandHandler<CreateSmeMemberCommand, CreateSmeMemberCommandResponse>
    {

        private readonly ISmeMemberRepository _smeMemberRepository;

        public CreateSmeMemberCommandHandler(ISmeMemberRepository smeMemberRepository)
        {
            _smeMemberRepository = smeMemberRepository;
        }

        public override async Task<CreateSmeMemberCommandResponse> Executor(CreateSmeMemberCommand command)
        {
            var smeMember = new Domain.Profile.SmeMember(command.Name, command.ProfilePhoto)
            {
                SmeProfileId = command.SmeProfileId,
                PositionId = command.PositionId,
            };

            await _smeMemberRepository.Create(smeMember);
            
            return new CreateSmeMemberCommandResponse();
        }
    }
}
