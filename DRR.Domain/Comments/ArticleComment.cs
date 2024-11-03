using DRR.Domain.Profile;
using DRR.Domain.Articles;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Comments
{
    public class ArticleComment : Entity<int>
    {
        public ArticleComment(string desc, int userId, int articleId, string commentDate, bool isAccept)
        {
            Desc = desc;
            UserId = userId;
            ArticleId = articleId;
            CommentDate = commentDate;
            IsAccept = isAccept;
        }

        public int Id { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public string CommentDate { get; set; }
        public bool IsAccept { get; set; }


        public int SmeProfileId { get; protected set; }
        public SmeProfile SmeProfile { get; protected set; }
        public Article Article { get; set; }



    }

}
