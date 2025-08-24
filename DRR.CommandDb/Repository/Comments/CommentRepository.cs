using DRR.Application.Contracts.Repository.Comments;
using DRR.CommandDB;
using DRR.Domain.Comments;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Specialists;
using DRR.Utilities.Extensions;
using DRR.Application.Contracts.Queries.Comment;

namespace DRR.CommandDb.Repository.Comments
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Comment> ReadCommentById(int id)
        {
            var result = await _Db.Comments.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Comment>> ReadCommentBySmeProfileId(int SmeprofileId)
        {
            var result = await _Db.Comments.Where(c => c.SmeProfileId == SmeprofileId).ToListAsync();

            return result;
        }
        public async Task<List<Comment>> ReadCommentByDoctorId(int DoctorId)
        {
            var result = await _Db.Comments.Where(c => c.DoctorId == DoctorId).ToListAsync();

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
            result.SmeProfileId = Comment.SmeProfileId;
            result.DoctorId = Comment.DoctorId;
            result.CommentDate = Comment.CommentDate;
            result.IsAccept = Comment.IsAccept;
            result.IsSuggest = Comment.IsSuggest;
            result.LikeNumber = Comment.LikeNumber;

            _Db.Comments.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Comments.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Comments.Remove(result);

            await _Db.SaveChangesAsync();
        }
        public async Task<List<Comment>> Search(ReadAllCommentQuery query)
        {
            var q = _Db.Comments
               .Where(w => !w.IsDeleted);
            if (query.SearchInComment != null && query.SearchInComment.Length > 2)
            {
                var searchCommentTerms = query.SearchInComment.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();




                foreach (var searchTerm in searchCommentTerms.Where(w => w.IsNotNullOrEmpty()))
                    q = q.Where(w =>
                        w.Desc.Contains(searchTerm) ||
                        w.Doctor.DoctorName.Contains(searchTerm) ||
                        w.Doctor.DoctorFamily.Contains(searchTerm)
                    );
            }
            

            query.TotalRecords = q.Count();

            var result = await q.Skip((query.pageNumber - 1) * query.pagesize).Take(query.pagesize).ToListAsync();

            return result;
            
        }

    }

}
