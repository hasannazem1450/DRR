using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Comments
{
    public class Comment : Entity<int>
    {
        public Comment(string desc, int userId, int doctorId, string commentDate, bool isAccept)
        {
            Desc = desc;
            UserId = userId;
            DoctorId = doctorId;
            CommentDate = commentDate;
            IsAccept = isAccept;
        }

        public int Id { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public string CommentDate { get; set; }
        public bool IsAccept { get; set; }


        public UserProfile UserProfile { get; set; }


        public ICollection<SmeProfile> SmeProfiles { get; set; }
        

    }

}
