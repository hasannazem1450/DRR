using DRR.Application.Contracts.Repository.Comments;
using DRR.CommandDB;
using DRR.Domain.Comments;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Comments
{
    class CommentReplyRepository : BaseRepository, ICommentReplyRepository
    {
        public CommentReplyRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<CommentReply> ReadCommentReplyById(int id)
        {
            var result = await _Db.CommentReplys.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<CommentReply>> ReadCommentReplyByUserId(int id)
        {
            var result = await _Db.CommentReplys.Where(c => c.UserId == id).ToListAsync();

            return result;
        }
        public async Task<List<CommentReply>> ReadCommentReplyByCommentId(int id)
        {
            var result = await _Db.CommentReplys.Where(c => c.CommentId == id).ToListAsync();

            return result;
        }
        public async Task Create(CommentReply CommentReply)
        {
            await _Db.CommentReplys.AddAsync(CommentReply);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Comments.CommentReply CommentReply)
        {
            var result = await this.ReadCommentReplyById(CommentReply.Id);


            result.Desc = CommentReply.Desc;
            result.UserId = CommentReply.UserId;
            result.CommentId = CommentReply.CommentId;
            result.CommentDat = CommentReply.CommentDat;

            
            _Db.CommentReplys.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.CommentReplys.FirstOrDefaultAsync(n => n.Id == id);

            _Db.CommentReplys.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
