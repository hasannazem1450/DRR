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
    public class DeleteSmeMemberCommandHandler : CommandHandler<DeleteSmeMemberCommand, DeleteSmeMemberCommandResponse>
    {

        private readonly ISmeMemberRepository _smeMemberRepository;

        public DeleteSmeMemberCommandHandler(ISmeMemberRepository smeMemberRepository)
        {
            _smeMemberRepository = smeMemberRepository;
        }

        public override async Task<DeleteSmeMemberCommandResponse> Executor(DeleteSmeMemberCommand command)
        {

            await _smeMemberRepository.Delete(command.Id);

            return new DeleteSmeMemberCommandResponse();
        }
    }
}
