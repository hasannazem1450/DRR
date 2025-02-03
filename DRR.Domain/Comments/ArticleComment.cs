using DRR.Domain.Profile;
using DRR.Domain.Articles;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Comments
{
    public class ArticleComment : Entity<int>
    {
        public ArticleComment(string desc, int articleId, string commentDate, bool isAccept, int smeProfileId)
        {
            Desc = desc;
            ArticleId = articleId;
            CommentDate = commentDate;
            IsAccept = isAccept;
            SmeProfileId = smeProfileId;
        }

        public string Desc { get; set; }
        public int ArticleId { get; set; }
        public string CommentDate { get; set; }
        public bool IsAccept { get; set; }


        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; protected set; }
        public virtual Article Article { get; set; }

        public void Update(string desc, int articleId, string commentDate, bool isAccept, int smeProfileId)
        {
            Desc = desc;
            ArticleId = articleId;
            CommentDate = commentDate;
            IsAccept = isAccept;
            SmeProfileId = smeProfileId;
        }

    }

}
