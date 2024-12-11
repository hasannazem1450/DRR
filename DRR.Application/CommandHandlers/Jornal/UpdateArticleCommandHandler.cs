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
    public class UpdateArticleCommandHandler : CommandHandler<UpdateArticleCommand , UpdateArticleCommandResponse>
    {
        private readonly IArticleRepository _articleRepository;


        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public override async Task<UpdateArticleCommandResponse> Executor(UpdateArticleCommand command)
        {
            var article = await _articleRepository.ReadArticleById(command.Id);
            
            if (article == null)
                throw new ArticleNotFoundException();
            article.Update(command.Title, command.Desc ,command.ShortDesc, command.ArticleTypeId,command.Link ,command.DRRFileId,command.Authors,command.SmeProfileId);
            
            await _articleRepository.Update(article);

            return new UpdateArticleCommandResponse();
        }
    }
}

