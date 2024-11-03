using DRR.Domain.Comments;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Comments
{
    public interface ICommentReplyRepository : IRepository
    {
        Task<CommentReply> ReadCommentReplyById(int id);
        Task<List<CommentReply>> ReadCommentReplyByUserId(int id);
        Task<List<CommentReply>> ReadCommentReplyByCommentId(int id);

        Task Delete(int id);

        Task Update(Domain.Comments.CommentReply commentReply);

        Task Create(Domain.Comments.CommentReply commentReply);
    }

}
