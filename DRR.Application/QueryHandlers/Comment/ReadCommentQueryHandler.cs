using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Comment
{
    public class ReadCommentQueryHandler: IQueryHandler <ReadCommentQuery, ReadCommentQueryResponse>
    {
        private readonly ICommentService _commentService;


        public ReadCommentQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<ReadCommentQueryResponse> Execute(ReadSmeProfileCommentQuery query,
            CancellationToken cancellationToken)
        {
            var commentDtos = await _CommentService.ReadCommentBySmeProfileId(query.SmeProfileId);

            var result = new ReadCommentQueryResponse()
            {
                List = commentDtos,
            };

            return result;
        }

        public async Task<ReadCommentQueryResponse> Execute(ReadDoctorCommentQuery query,
           CancellationToken cancellationToken)
        {
            var commentDtos = await _CommentService.ReadCommentByDoctorId(query.DoctorId);

            var result = new ReadCommentQueryResponse()
            {
                List = commentDtos,
            };

            return result;
        }
    }
}
