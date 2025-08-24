using DRR.Application.Contracts.Commands.Comment;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Comment;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Repository.Comments;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Services.Comment;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.Jornal;
using DRR.Application.Services.Customer;
using DRR.CommandDb.Repository.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Comment
{
    public class ReadAllCommentQueryHandler : IQueryHandler<ReadAllCommentQuery, ReadAllCommentQueryResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IArticleCommentRepository _articlecommentRepository;
        private readonly ICommentReplyRepository _commentreplayRepository;
        private readonly ICommentService _commentService;
        private readonly IArticleCommentService _articlecommentService;

        public ReadAllCommentQueryHandler(ICommentRepository commentRepository, IArticleCommentRepository articlecommentRepository,
            ICommentReplyRepository commentreplayRepository, ICommentService commentService, IArticleCommentService articlecommentService)
        {
            _commentRepository = commentRepository;
            _articlecommentRepository = articlecommentRepository;
            _commentreplayRepository = commentreplayRepository;
            _commentService = commentService;
            _articlecommentService = articlecommentService;
        }
        public async Task<ReadAllCommentQueryResponse> Execute(ReadAllCommentQuery query,
            CancellationToken cancellationToken)
        {
          
            var comments = await _commentRepository.Search(query);
            var articlecomments = await _articlecommentRepository.Search(query);


            var senditems = new AllCommentDto {
            CommentDtos = await _commentService.ConvertToDto(comments),
            ArticleCommentDtos = await _articlecommentService.ConvertToDto(articlecomments)
            }; 

            var result = new ReadAllCommentQueryResponse
            {
                PageNumber = query.pageNumber,
                PageSize = query.pagesize,
                TotalRecords = query.TotalRecords,
                AllCommentDto = senditems
            };

            return result;
        }
    }
}
