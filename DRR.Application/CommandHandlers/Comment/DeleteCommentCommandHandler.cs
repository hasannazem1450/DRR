using DRR.Application.Contracts.Commands.Comment;
using DRR.Application.Contracts.Repository.Comments;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Comment
{
    public class DeleteCommentCommandHandler:CommandHandler<DeleteCommentCommand, DeleteCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;


        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public override async Task<DeleteCommentCommandResponse> Executor(DeleteCommentCommand command)
        {
            await _commentRepository.Delete(command.Id);

            return new DeleteCommentCommandResponse();
        }
    }
}
