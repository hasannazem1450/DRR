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
    public class CreateAdsCommandHandler : CommandHandler<CreateAdsCommand, CreateAdsCommandResponse>
    {

        private readonly IAdsRepository _adsRepository;


        public CreateAdsCommandHandler(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public override async Task<CreateAdsCommandResponse> Executor(CreateAdsCommand command)
        {
            var ads = new Domain.News.Ads(command.Title, command.HeadLine, command.Description, command.Photo)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _adsRepository.Create(ads);

            return new CreateAdsCommandResponse();
        }
    }
}
