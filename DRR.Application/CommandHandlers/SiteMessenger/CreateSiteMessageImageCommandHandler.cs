using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessanger;
using DRR.Domain.SiteMessenger;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger
{
    public class CreateSiteMessageImageCommandHandler : CommandHandler<CreateSiteMessageImageCommand, CreateSiteMessageImageCommandResponse>
    {
        private readonly ISiteMessageImageRepository _siteMessageImageRepository;

        public CreateSiteMessageImageCommandHandler(ISiteMessageImageRepository siteMessageImageRepository)
        {
            _siteMessageImageRepository = siteMessageImageRepository;
        }

        public override async Task<CreateSiteMessageImageCommandResponse> Executor(CreateSiteMessageImageCommand command)
        {
            var siteMessageImage = new SiteMessageImage(command.SiteMessageId, command.ImageId);

            await _siteMessageImageRepository.Create(siteMessageImage);

            var result = new CreateSiteMessageImageCommandResponse
            {
                Id = siteMessageImage.Id
            };

            return result;
        }
    }
}
