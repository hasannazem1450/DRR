using DRR.Application.Contracts.Commands.Comment;
using DRR.Application.Contracts.Commands.News;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Comment
{
    public interface ICommentService: IService
    {
        Task<CommentDto> ReadById(int id); 
        Task<List<CommentDto>> ReadCommentBySmeProfileId(int SmeProfileId); 
        Task<List<CommentDto>> ReadCommentByDoctorId(int DoctorId);
    }
}
