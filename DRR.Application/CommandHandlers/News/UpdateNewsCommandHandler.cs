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
    public class UpdateNewsCommandHandler : CommandHandler<UpdateNewsCommand, UpdateNewsCommandResponse>
    {

        private readonly INewsRepository _newsRepository;


        public UpdateNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public override async Task<UpdateNewsCommandResponse> Executor(UpdateNewsCommand command)
        {
            var news = new Domain.News.News(command.Title, command.HeadLine, command.Description, command.Photo)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _newsRepository.Update(news);

            return new UpdateNewsCommandResponse();
        }
    }
}
