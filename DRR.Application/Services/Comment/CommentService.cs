using DRR.Application.Contracts.Commands.Comment;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Repository.Comments;
using DRR.Application.Contracts.Services.Comment;
using DRR.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Comment
{
    public class CommentService: ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> ReadById(int id)
        {
            var Comment = await _commentRepository.ReadCommentById(id);

            return new CommentDto()
            {
                Id = Comment.Id,
                Desc = Comment.Desc,
                DoctorId = Comment.DoctorId,
                Doctor = Comment.Doctor,
                CommentDate = Comment.CommentDate,
                IsAccept = Comment.IsAccept,
                SmeProfileId = Comment.SmeProfileId,
                SmeProfile= Comment.SmeProfile,
                IsSuggest = Comment.IsSuggest,
                LikeNumber = Comment.LikeNumber
            };
        }

        public async Task<List<CommentDto>> ReadCommentBySmeProfileId(int SmeProfileId)
        {
            var comment = await _commentRepository.ReadCommentBySmeProfileId(SmeProfileId);

            var result = new List<CommentDto>();

            foreach (var item in comment)
            {
                var dto = new CommentDto()
                {
                    Id = item.Id,
                    Desc = item.Desc,
                    SmeProfileId = item.SmeProfileId,
                    DoctorId = item.DoctorId,
                    Doctor = item.Doctor,
                    CommentDate = item.CommentDate,
                    IsAccept = item.IsAccept,
                    SmeProfile = item.SmeProfile,
                    IsSuggest = item.IsSuggest,
                    LikeNumber = item.LikeNumber
                };

                result.Add(dto);
            }

            return result;
        }

        public async Task<List<CommentDto>> ReadCommentByDoctorId(int DoctorId)
        {
            var comment = await _commentRepository.ReadCommentByDoctorId(DoctorId);

            var result = new List<CommentDto>();

            foreach (var item in comment)
            {
                var dto = new CommentDto()
                {
                    Id = item.Id,
                    Desc = item.Desc,
                    SmeProfileId = item.SmeProfileId,
                    DoctorId = item.DoctorId,
                    Doctor = item.Doctor,
                    CommentDate = item.CommentDate,
                    
                    IsAccept = item.IsAccept,
                    SmeProfile = item.SmeProfile,
                    IsSuggest = item.IsSuggest,
                    LikeNumber = item.LikeNumber
                };

                result.Add(dto);
            }

            return result;
        }

        public async Task<List<CommentDto>> ConvertToDto(List<DRR.Domain.Comments.Comment> comments)
        {
            var result = comments.Select(s => ConvertToDto(s).Result).ToList();

            return result;
        }

        public async Task<CommentDto> ConvertToDto(DRR.Domain.Comments.Comment comment)
        {
            var result = new CommentDto
            {
                Id = comment.Id,
                Desc = comment.Desc,
                SmeProfileId = comment.SmeProfileId,
                DoctorId = comment.DoctorId,
                Doctor = comment.Doctor,
                CommentDate = comment.CommentDate,

                IsAccept = comment.IsAccept,
                SmeProfile = comment.SmeProfile,
                IsSuggest = comment.IsSuggest,
                LikeNumber = comment.LikeNumber
            };

            return result;
        }
    }
}
