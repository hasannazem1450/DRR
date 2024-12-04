using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Application.Contracts.Repository.Articles;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Jornal
{
    public class CreateArticleCommandHandler : CommandHandler<CreateArticleCommand, CreateArticleCommandResponse>
    {
        private readonly IArticleRepository _articleRepository;


        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public override async Task<CreateArticleCommandResponse> Executor(CreateArticleCommand command)
        {
            var article = new Domain.Articles.Article(command.Title, command.Desc, command.ShortDesc, command.ArticleTypeId,
                command.Link , command.DRRFileId , command.Authors , command.SmeProfileId);

            await _articleRepository.Create(article);

            return new CreateArticleCommandResponse();
        }
    }
}
