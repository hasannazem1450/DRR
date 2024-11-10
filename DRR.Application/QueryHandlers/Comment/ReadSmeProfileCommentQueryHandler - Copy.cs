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
    public class ReadSmeProfileCommentQueryHandler : IQueryHandler <ReadSmeProfileCommentQuery, ReadSmeProfileCommentQueryResponse>
    {
        private readonly ICommentService _commentService;


        public ReadSmeProfileCommentQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<ReadSmeProfileCommentQueryResponse> Execute(ReadSmeProfileCommentQuery query,
            CancellationToken cancellationToken)
        {
            var commentDtos = await _commentService.ReadCommentBySmeProfileId(query.SmeProfileId);

            var result = new ReadSmeProfileCommentQueryResponse()
            {
                List = commentDtos,
            };

            return result;
        }

      
    }
}
