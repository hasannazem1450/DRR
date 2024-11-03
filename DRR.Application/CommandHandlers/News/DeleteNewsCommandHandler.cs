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
    public class DeleteNewsCommandHandler : CommandHandler<DeleteNewsCommand, DeleteNewsCommandResponse>
    {

        private readonly INewsRepository _newsRepository;


        public DeleteNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public override async Task<DeleteNewsCommandResponse> Executor(DeleteNewsCommand command)
        {
            await _newsRepository.Delete(command.Id);

            return new DeleteNewsCommandResponse();
        }
    }
}
