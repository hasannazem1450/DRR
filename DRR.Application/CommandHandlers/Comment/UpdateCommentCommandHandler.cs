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
    public class UpdateCommentCommandHandler : CommandHandler<UpdateCommentCommand, UpdateCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;


        public UpdateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public override async Task<UpdateCommentCommandResponse> Executor(UpdateCommentCommand command)
        {
            var comment = new Domain.Comments.Comment(command.Desc, command.SmeProfileId, command.DoctorId, command.CommentDate, command.IsAccept)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _commentRepository.Update(comment);

            return new UpdateCommentCommandResponse();
        }
    }
}
