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
    public class CreateCommentCommandHandler : CommandHandler<CreateCommentCommand , CreateCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler (ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public override async Task<CreateCommentCommandResponse> Executor(CreateCommentCommand command)
        {
            var comment = new Domain.Comments.Comment(command.Desc,command.SmeProfileId, command.DoctorId, command.CommentDate, command.IsAccept ,command.IsSuggest,command.LikeNumber)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _commentRepository.Create(comment);

            return new CreateCommentCommandResponse();
        }
    }
}
