using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.Jornal.Exceptions;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Application.Contracts.Repository.Articles;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Jornal
{
    public class DeleteArticleCommandHandler : CommandHandler<DeleteArticleCommand, DeleteArticleCommandResponse>
    {
        private readonly IArticleRepository _articleRepository;


        public DeleteArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public override async Task<DeleteArticleCommandResponse> Executor(DeleteArticleCommand command)
        {
            var article = await _articleRepository.ReadArticleById(command.Id);

            if (article == null)
                throw new ArticleNotFoundException();

            article.SetIsDeleted(true);

            await _articleRepository.Update(article);

            return new DeleteArticleCommandResponse();
        }
    }
}
