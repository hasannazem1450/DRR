using DRR.Application.Contracts.Queries.Comment;
using DRR.Application.Contracts.Services.Comment;
using DRR.Application.Services.Comment;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Comment
{
    public class ReadDoctorCommentQueryHandler : IQueryHandler <ReadDoctorCommentQuery, ReadDoctorCommentQueryResponse>
    {
        private readonly ICommentService _commentService;


        public ReadDoctorCommentQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<ReadDoctorCommentQueryResponse> Execute(ReadDoctorCommentQuery query,
            CancellationToken cancellationToken)
        {
            var commentDtos = await _commentService.ReadCommentByDoctorId(query.DoctorId);

            var result = new ReadDoctorCommentQueryResponse()
            {
                List = commentDtos,
            };

            return result;
        }

      
    }
}
