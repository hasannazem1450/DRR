using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var ads = new Domain.News.Ads(command.Title, command.HeadLine, command.Description, command.Photo)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _adsRepository.Update(ads);

            return new UpdateAdsCommandResponse();
        }
    }
}
