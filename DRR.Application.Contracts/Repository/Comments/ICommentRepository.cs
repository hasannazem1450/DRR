using DRR.Domain.Comments;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Comments
{
    public interface ICommentRepository : IRepository
    {
        Task<Comment> ReadCommentById(int id);
        Task<List<Comment>> ReadCommentByUserId(int id);
        Task<List<Comment>> ReadCommentByDoctorId(int id);

        Task Delete(int id);

        Task Update(Domain.Comments.Comment comment);

        Task Create(Domain.Comments.Comment comment);
    }

}
