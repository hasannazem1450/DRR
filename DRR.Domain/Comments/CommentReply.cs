using DRR.Domain.Profile;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Comments
{
    public class CommentReply : Entity<int>
    {
        public CommentReply(string desc, int userId, int commentId, string commentDat)
        {
            Desc = desc;
            UserId = userId;
            CommentId = commentId;
            CommentDat = commentDat;
        }

        public int Id { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string CommentDat { get; set; }


        public Doctor Doctor { get; set; }


        public ICollection<SmeProfile> SmeProfiles { get; set; }


    }

}
