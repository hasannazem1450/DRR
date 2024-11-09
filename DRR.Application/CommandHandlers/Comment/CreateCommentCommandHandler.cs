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
            var comment = new Domain.Comments.Comment(command.Desc, command.DoctorId, command.CommentDate, command.IsAccept)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _commentRepository.Create(comment);

            return new CreateCommentCommandResponse();
        }
    }
}
