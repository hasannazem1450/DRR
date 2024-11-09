using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Comment
{
    public class UpdateCommentCommandHandler:CommandHandler<UpdateCommentCommand, UpdateCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;


        public UpdateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public override async Task<UpdateCommentCommandResponse> Executor(UpdateCommentCommand command)
        {
            var comment = new Domain.Comment.Comment(command.Desc, command.DoctorId, command.CommentDate, command.IsAccept)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _commentRepository.Update(comment);

            return new UpdateCommentCommandResponse();
        }
    }
}
