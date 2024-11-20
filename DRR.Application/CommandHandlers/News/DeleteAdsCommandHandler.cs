using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Repository.News;
using DRR.Application.Contracts.Repository.Profile.Member;
using DRR.Domain.Profile.Member;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.News
{
    public class DeleteAdsCommandHandler : CommandHandler<DeleteAdsCommand, DeleteAdsCommandResponse>
    {

        private readonly IAdsRepository _adsRepository;


        public DeleteAdsCommandHandler(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public override async Task<DeleteAdsCommandResponse> Executor(DeleteAdsCommand command)
        {
            await _adsRepository.Delete(command.Id);

            return new DeleteAdsCommandResponse();
        }
    }
}
