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
    class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Comment> ReadCommentById(int id)
        {
            var result = await _Db.Comments.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Comment>> ReadCommentByUserId(int id)
        {
            var result = await _Db.Comments.Where(c => c.UserId == id).ToListAsync();

            return result;
        }
        public async Task<List<Comment>> ReadCommentByDoctorId(int id)
        {
            var result = await _Db.Comments.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task Create(Comment Comment)
        {
            await _Db.Comments.AddAsync(Comment);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Comments.Comment Comment)
        {
            var result = await this.ReadCommentById(Comment.Id);

            result.Desc = Comment.Desc;
            result.UserId = Comment.UserId;
            result.DoctorId = Comment.DoctorId;
            result.CommentDate = Comment.CommentDate;
            result.IsAccept = Comment.IsAccept;


            _Db.Comments.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Comments.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Comments.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
