using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Comments
{
    public class CommentReply : Entity<int>
    {
        public CommentReply(string desc, int smeProfileId, int doctorId, int commentId, string commentDate)
        {
            Desc = desc;
            SmeProfileId = smeProfileId;
            DoctorId = doctorId;
            CommentId = commentId;
            CommentDate = commentDate;
        }

        public void Update(string desc, int smeProfileId, int doctorId, int commentId, string commentDate)
        {
            Desc = desc;
            SmeProfileId = smeProfileId;
            DoctorId = doctorId;
            CommentId = commentId;
            CommentDate = commentDate;
        }

        public string Desc { get; set; }
        public int SmeProfileId { get; set; }
        public int CommentId { get; set; }
        public string CommentDate { get; set; }

        public int DoctorId { get; set; }
        public Comment Comment { get; set; }
        public Doctor Doctor { get; set; }
        public SmeProfile SmeProfile { get; set; }


    }

}
