using DRR.Domain.Customer;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace DRR.Domain.Comments
{
    public class Comment : Entity<int>
    {
        public Comment(string desc, int smeProfileId, int doctorId, string commentDate, bool isAccept, bool isSuggest, int likeNumber)
        {
            Desc = desc;
            SmeProfileId = smeProfileId;
            DoctorId = doctorId;
            CommentDate = commentDate;
            IsAccept = isAccept;
            IsSuggest = isSuggest;
            LikeNumber = likeNumber;
        }

        public string Desc { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string CommentDate { get; set; }
        public bool IsAccept { get; set; }
        public int SmeProfileId { get; set; }
        public bool IsSuggest { get; set; }
        public int LikeNumber { get; set; }
        public SmeProfile SmeProfile { get; set; }


        public void Update(string desc, int smeProfileId, int doctorId, string commentDate, bool isAccept, bool isSuggest, int likeNumber)
        {
            Desc = desc;
            SmeProfileId = smeProfileId;
            DoctorId = doctorId;
            CommentDate = commentDate;
            IsAccept = isAccept; IsSuggest = isSuggest;
            LikeNumber = likeNumber;
        }

    }

}
