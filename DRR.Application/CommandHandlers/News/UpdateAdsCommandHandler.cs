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
    public class UpdateAdsCommandHandler : CommandHandler<UpdateAdsCommand, UpdateAdsCommandResponse>
    {

        private readonly IAdsRepository _adsRepository;


        public UpdateAdsCommandHandler(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public override async Task<UpdateAdsCommandResponse> Executor(UpdateAdsCommand command)
        {
            var ads = await _adsRepository.ReadById(command.Id);

            ads.Update(command.Title, command.HeadLine, command.Description, command.Photo);

            await _adsRepository.Update(ads);

            return new UpdateAdsCommandResponse();
        }
    }
}
