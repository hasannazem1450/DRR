using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessanger;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger
{
    public class DeleteSiteMessageImageCommandHandler : CommandHandler<DeleteSiteMessageImageCommand, DeleteSiteMessageImageCommandResponse>
    {
        private readonly ISiteMessageImageRepository _siteMessageImageRepository;

        public DeleteSiteMessageImageCommandHandler(ISiteMessageImageRepository siteMessageImageRepository)
        {
            _siteMessageImageRepository = siteMessageImageRepository;
        }

        public override async Task<DeleteSiteMessageImageCommandResponse> Executor(DeleteSiteMessageImageCommand command)
        {
            var siteMessageImage = await _siteMessageImageRepository.ReadById(command.Id);

            siteMessageImage.SetIsDeleted(true);

            await _siteMessageImageRepository.Update(siteMessageImage);

            var result = new DeleteSiteMessageImageCommandResponse();

            return result;
        }
    }
}
